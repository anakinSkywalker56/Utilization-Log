using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace C7
{
    public partial class Form1 : Form
    {
        private const string URL = "GOOGLE_SHEET_URL";

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.MICT_Logo_White;
            timeOut.Format = DateTimePickerFormat.Time;
            timeOut.ShowUpDown = true;
            TopMost = true;
            EnableKioskMode();
            shadowLayout();
        }
        public void shadowLayout()
        {
            var overlay = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                WindowState = FormWindowState.Maximized,
                BackColor = Color.Black,
                Opacity = 0.50,
            };
            overlay.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            if (checker() == false)
            {
                return;
            }

            disableControls();
            disableSubmit();
            
            var payload = new
            {
                date = DateTime.Today.ToString("yyyy-MM-dd"),
                pcNum = txtPcNum.Text.Trim(),
                name = txtName.Text.Trim(),
                course = txtCourse.Text.Trim(),
                subject = txtSubject.Text.Trim(),
                sched = txtSched.Text.Trim(),
                instructor = txtInstruc.Text.Trim(),
                timeInData = DateTime.Now.TimeOfDay.ToString(),
                timeOutData = timeOut.Value.TimeOfDay.ToString(),
            };

            SendPayload(payload);

            DialogResult dr = MessageBox.Show("Submitted successfully!", "Success", MessageBoxButtons.OK);
            if (dr == DialogResult.OK)
            {
                Close();
            }

        }

        public async void SendPayload(object data) {
            try
            {

                var handler = new System.Net.Http.HttpClientHandler()
                {
                    AllowAutoRedirect = true
                };

                using (var client = new System.Net.Http.HttpClient(handler))
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);
                    var content = new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URL, content);
                    string result = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void disableControls() { 
            txtName.Enabled = false;
            txtCourse.Enabled = false;
            txtInstruc.Enabled = false;
            txtSubject.Enabled = false;
            txtSched.Enabled = false;
            timeOut.Enabled = false;
            txtPcNum.Enabled = false;
        }

        public void disableSubmit() {
            submit.Enabled = false;
            submit.ForeColor = SystemColors.Control;
            submit.BackColor = Color.Green;
        }


        public bool checker()
        {

            return ValidateControls(this);
        }

        private bool ValidateControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        MessageBox.Show("This field cannot be empty,",
                                    "Valdiation Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                        tb.Focus();
                        return false;
                    }
                }
                if (ctrl.HasChildren)
                {
                    if (!ValidateControls(ctrl))
                        return false;
                }
            }
            return true;
        }
        private void EnableKioskMode()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.KeyPreview = true;
            this.KeyDown += (s, e) =>
            {
                if (e.Alt && e.KeyCode == Keys.F4)
                {
                    e.Handled = true;
                }
            };
        }
    }
}
