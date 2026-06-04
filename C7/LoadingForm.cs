using System;
using System.Drawing;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace C7
{
    public partial class LoadingForm : Form
    {
        private const int TOTAL_STEPS = 6;
        private const int PING_TIMEOUT_MS = 3000;
        private const string PING_HOST = "8.8.8.8";

        private int _currentStep = 0;
        private bool _isLowConn = false;
        private System.Windows.Forms.Timer _dotTimer;
        private Thread _initThread;

        private readonly string[] _stepMessages =
        {
            "Initializing application…",
            "Checking network connection…",
            "Loading configuration…",
            "Connecting to database…",
            "Preparing lab records…",
            "Almost ready…"
        };

        private readonly string[] _slowMessages =
        {
            "Slow connection detected – please wait…",
            "Network is taking longer than usual…",
            "Still connecting – hang tight!",
            "Loading over slow connection…",
            "Almost there – slow network mode…",
            "Finishing up despite slow connection…"
        };

        public LoadingForm()
        {
            InitializeComponent();
            SetupDotAnimation();
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {
            CenterToScreen();
            progressBar.Value = 0;
            lblPercent.Text = "0%";
            pnlConnBanner.Visible = false;


            _initThread = new Thread(RunInitialization);
            _initThread.IsBackground = true;
            _initThread.Start();
        }

        private void RunInitialization()
        {


            AdvanceStep(0, 600);

         
            AdvanceStep(0, 600);


            AdvanceStep(1, 200);
            _isLowConn = DetectLowConnection();
            UpdateConnectionBanner(_isLowConn);

            int delay = _isLowConn ? 1400 : 700;
            for (int i = 2; i < TOTAL_STEPS; i++)
            {
                AdvanceStep(i, delay);
            }


            if (_dotTimer != null)
            {
                SafeInvoke(new Action(() => _dotTimer.Stop()));
            }

            SafeInvoke(new Action(() =>
            {
                lblStatus.Text = "Done!";
                progressBar.Value = progressBar.Maximum;
                lblPercent.Text = "100%";
            }));

            Thread.Sleep(400);
        }

        private void AdvanceStep(int stepIndex, int delayMs)
        {
            SafeInvoke(new Action(() =>
            {
                _currentStep = stepIndex;
                string msg = _isLowConn ? _slowMessages[stepIndex] : _stepMessages[stepIndex];
                lblStatus.Text = msg;

                int pct = (int)Math.Round((stepIndex / (double)(TOTAL_STEPS - 1)) * 100);
                progressBar.Value = Math.Min(pct, progressBar.Maximum);
                lblPercent.Text = pct + "%";
            }));

            Thread.Sleep(delayMs);
        }

        private bool DetectLowConnection()
        {
            Ping ping = null;
            try
            {
                ping = new Ping();
                PingReply reply = ping.Send(PING_HOST, PING_TIMEOUT_MS);

                if (reply.Status != IPStatus.Success)
                    return true;

                return reply.RoundtripTime > 300;
            }
            catch
            {
                return true;
            }
            finally
            {
                if (ping != null)
                {
                    ping.Dispose();
                }
            }
        }

        private void UpdateConnectionBanner(bool isLow)
        {
            SafeInvoke(new Action(() =>
            {
                if (isLow)
                {
                    pnlConnBanner.Visible = true;
                    lblConnBanner.Text = "Low or slow connection detected. Loading may take longer.";
                    pnlConnBanner.BackColor = Color.FromArgb(255, 243, 205);
                    lblConnBanner.ForeColor = Color.FromArgb(133, 77, 14);
                }
                else
                {
                    pnlConnBanner.Visible = false;
                }
            }));
        }

        private int _dotCount = 0;
        private void SetupDotAnimation()
        {
            _dotTimer = new System.Windows.Forms.Timer();
            _dotTimer.Interval = 500;
            _dotTimer.Tick += (s, e) =>
            {
                _dotCount = (_dotCount + 1) % 4;
                lblDots.Text = new string('.', _dotCount);
            };
            _dotTimer.Start();
        }

        private void SafeInvoke(Action action)
        {
            if (this.InvokeRequired)
                this.Invoke(action);
            else
                action();
        }
    }
}
