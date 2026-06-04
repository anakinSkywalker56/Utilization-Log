using System;
using System.Drawing;
using System.Windows.Forms;

namespace C7
{
    public partial class Form1 : Form
    {
        private const string URL = "https://script.google.com/macros/s/AKfycbxlOPw0Emu0EeyDyUlSaEkyoC-Kmu5l4ZzcUhQif7g5p2-3CxHbnqngB8BUbz7mtgGG/exec";

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.MICT_Logo_White;

            timeOut.Format = DateTimePickerFormat.Custom;
            timeOut.CustomFormat = "hh:mm tt";
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
                sheetName = "N301",
                date = DateTime.Today.ToString("yyyy-MM-dd"),
                pcNum = txtPcNum.Text.Trim(),
                name = txtName.Text.Trim(),
                course = txtCourse.Text.Trim(),
                subject = txtSubject.Text.Trim(),
                sched = txtSched.Text.Trim(),
                instructor = txtInstruc.Text.Trim(),

               
                timeInData = DateTime.Now.ToString("hh:mm tt"),    
                timeOutData = timeOut.Value.ToString("hh:mm tt"), 
            };

            SendPayload(payload);
            LoadingForm load = new LoadingForm();
            load.Show();
            this.Hide();
        }

        public void SendPayload(object data)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            string json = serializer.Serialize(data);

            System.Threading.ThreadPool.QueueUserWorkItem(state =>
            {
                try
                {
                    using (var client = new System.Net.WebClient())
                    {
                        client.Headers[System.Net.HttpRequestHeader.ContentType] = "application/json";
                        client.UploadString(URL, "POST", json);
                    }

                    this.Invoke((MethodInvoker)delegate
                    {
                        DialogResult dr = MessageBox.Show("Submitted successfully!", "Success", MessageBoxButtons.OK);
                        if (dr == DialogResult.OK)
                        {
                            Close();
                        }
                    });
                }
                catch (Exception ex)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show("Error: " + ex.Message);
                        submit.Enabled = true;
                        submit.BackColor = SystemColors.Control;
                        submit.ForeColor = SystemColors.ControlText;
                    });
                }
            });
        }

        public void disableControls()
        {
            txtName.Enabled = false;
            txtCourse.Enabled = false;
            txtInstruc.Enabled = false;
            txtSubject.Enabled = false;
            txtSched.Enabled = false;
            timeOut.Enabled = false;
            txtPcNum.Enabled = false;
        }

        public void disableSubmit()
        {
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
                TextBox tb = ctrl as TextBox;
                if (tb != null)
                {
                    if (string.IsNullOrEmpty(tb.Text))
                    {
                        MessageBox.Show("This field cannot be empty.",
                                        "Validation Error",
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}