using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace C7
{
    public partial class Form1 : Form
    {
        private const string URL = "https://script.google.com/macros/s/AKfycbwIcZEGKQFD1lYNF9hBjUKbzk94SdvcqpwXQGzfkpFWm5LlwW-y_upssrCB8UAx_foa/exec";

        public Form1()
        {
            InitializeComponent();

            timeOut.Format = DateTimePickerFormat.Time;
            timeOut.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Checker();

        }
        public void saveData()
        {
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

                DialogResult dr = MessageBox.Show("Submitted successfully!", "Success", MessageBoxButtons.OK);
                if (dr == DialogResult.OK)
                {
                    Close();
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

        public void Checker()
        {
            foreach (Control ctrl in tableLayoutPanel1.Controls)
            {
                if (ctrl is TextBox txt && !string.IsNullOrWhiteSpace(txt.Tag?.ToString()))
                {
                    if (string.IsNullOrWhiteSpace(txt.Text))
                    {
                        MessageBox.Show(txt.Tag.ToString(), "Validation Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            saveData();
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
