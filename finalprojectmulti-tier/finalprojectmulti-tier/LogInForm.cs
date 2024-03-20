using finalprojectmulti_tier.Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace finalprojectmulti_tier
{
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    string enteredUserID = textBox1.Text;
                    string enteredPassword = textBox2.Text;

                    var user = context.Users.FirstOrDefault(u => u.UserID.ToString() == enteredUserID);

                    if (user != null)
                    {
                        if (user.Password == enteredPassword) // Verify the password
                        {
                            MessageBox.Show($"Welcome! You are a {user.JobTitle}");
                            CourseAssignmentForm courseAssignmentForm = new CourseAssignmentForm();
                            this.Hide();
                            courseAssignmentForm.Show();
                        }
                        else
                        {
                            MessageBox.Show("Password is incorrect. You are not allow to enter");
                            textBox1.Clear();
                            textBox2.Clear();
                        }
                    }

                    else
                    {
                        MessageBox.Show("UserID not found. You are not allow to enter");
                        textBox1.Clear();
                        textBox2.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
