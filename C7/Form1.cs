using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace C7
{
    public partial class Form1 : Form
    {
        private const string URL = "https://script.google.com/macros/s/AKfycbwIcZEGKQFD1lYNF9hBjUKbzk94SdvcqpwXQGzfkpFWm5LlwW-y_upssrCB8UAx_foa/exec";
        DateTime timeIn = new DateTime();

        public Form1()
        {
            InitializeComponent();

            timeOut.Format = DateTimePickerFormat.Time;
            timeOut.ShowUpDown = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            checker();

            disableControls();

            submit.Enabled = false;
            submit.ForeColor = SystemColors.Control;
            submit.BackColor = Color.Green;

            TimeSpan currentTime = timeIn.TimeOfDay;
            var payload = new
            {
                date = DateTime.Today.ToString("yyyy-MM-dd"),
                pcNum = txtPcNum.Text.Trim(),
                name = txtName.Text.Trim(),
                course = txtCourse.Text.Trim(),
                subject = txtSubject.Text.Trim(),
                sched = txtSched.Text.Trim(),
                instructor = txtInstruc.Text.Trim(),
                timeInData = currentTime.ToString(),
                timeOutData = timeOut.Value.TimeOfDay.ToString(),
            };

            try
            {
              
                var handler = new System.Net.Http.HttpClientHandler()
                {
                    AllowAutoRedirect = true
                };

                using (var client = new System.Net.Http.HttpClient(handler))
                {
                    string json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);
                    var content = new System.Net.Http.StringContent(json, System.Text.Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(URL, content);
                    string result = await response.Content.ReadAsStringAsync();
                    DialogResult dr = MessageBox.Show("Submitted successfully!", "Success", MessageBoxButtons.OK);
                    if (dr == DialogResult.OK)
                    {
                        this.Close();
                    }

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

        public void checker()
        {

            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    if (string.IsNullOrWhiteSpace(tb.Text))
                    {
                        MessageBox.Show(tb, "This field cannot be empty.");
                        return;
                    }
                }
            }
        }
    }
}
