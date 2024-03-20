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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace finalprojectmulti_tier
{
    public partial class CourseAssignmentForm : Form
    {
        public CourseAssignmentForm()
        {
            InitializeComponent();
            addTeacher();
            addCourse();
            addRegistration();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {

                    var teacherToAdd = new Teacher();
                    teacherToAdd.TeacherId = Int32.Parse(textBox1.Text);
                    teacherToAdd.FirstName = textBox2.Text;
                    teacherToAdd.LastName = textBox3.Text;
                    teacherToAdd.Email = textBox4.Text;
                    context.Teachers.Add(teacherToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Teacher Added Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeacher();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addTeacher()
        {
            try
            {
                using (var context = new Entities())
                {
                    var teachers = from Teacher in context.Teachers select Teacher;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Id");
                    dt.Columns.Add("First Name");
                    dt.Columns.Add("Last Name");
                    dt.Columns.Add("Email");

                    foreach (var teacher in teachers)
                    {
                        dt.Rows.Add(teacher.TeacherId, teacher.FirstName, teacher.LastName,
                                    teacher.Email);
                    }

                    dataGridView1.DataSource = dt;
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var teacherToEdit = from Teacher
                                        in context.Teachers
                                        where Teacher.TeacherId.ToString() == textBox1.Text
                                        select Teacher;

                    foreach (var teacher in teacherToEdit)
                    {
                        teacher.FirstName = textBox2.Text;
                        teacher.LastName = textBox3.Text;
                        teacher.Email = textBox4.Text;
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Teacher Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addTeacher();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
                try
                {
                    using (var context = new Entities())
                    {
                        var teacherTodelete = from Teacher
                                              in context.Teachers
                                              where Teacher.TeacherId.ToString() == textBox1.Text
                                              select Teacher;

                        foreach (var teacher in teacherTodelete)
                        {
                            context.Teachers.Remove(teacher);
                        }

                        context.SaveChanges();
                        MessageBox.Show($"Teacher Deleted Successfully", "Success",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        addTeacher();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var teacherToserach = from Teacher
                                          in context.Teachers
                                          where Teacher.TeacherId.ToString() == textBox5.Text
                                          select Teacher;

                    if (!teacherToserach.Any())
                    {
                        MessageBox.Show("TeacherId not found" +
                            "" +
                            ".");
                        return;
                    }

                    foreach (var teacher in teacherToserach)
                    {
                        label17.Text = "Full Name " + teacher.FirstName + " " + teacher.LastName + " " + "email: " + teacher.Email;
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)

        {
            try
            {
                using (var context = new Entities())
                {
                    //add Course to database

                    var courseToAdd = new Cours();
                    courseToAdd.CourseNumber = textBox9.Text;
                    courseToAdd.CourseTitle = textBox8.Text;
                    courseToAdd.Duration_hours_ = Int32.Parse(textBox7.Text);
                    context.Courses.Add(courseToAdd);
                    context.SaveChanges();
                    MessageBox.Show($"Course Added Successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCourse();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addCourse()
        {
            // select Course from database 
            try
            {
                using (var context = new Entities())
                {
                    var selectCourse = from Cours in context.Courses select Cours;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CourseNumber");
                    dt.Columns.Add("CourseTitle");
                    dt.Columns.Add("Duration");

                    foreach (var cours in selectCourse)
                    {
                        dt.Rows.Add(cours.CourseNumber, cours.CourseTitle, cours.Duration_hours_);
                    }

                    dataGridView2.DataSource = dt;
                    textBox9.Clear();
                    textBox8.Clear();
                    textBox7.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var courseToEdit = from Cours
                                        in context.Courses
                                       where Cours.CourseNumber.ToString() == textBox9.Text
                                       select Cours;

                    foreach (var cours in courseToEdit)
                    {
                        cours.CourseNumber = textBox9.Text;
                        cours.CourseTitle = textBox8.Text;
                        cours.Duration_hours_ = Int32.Parse(textBox7.Text);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCourse();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var courseTodelete = from Cours
                                          in context.Courses
                                         where Cours.CourseNumber.ToString() == textBox9.Text
                                         select Cours;

                    foreach (var cours in courseTodelete)
                    {
                        context.Courses.Remove(cours);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Course Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addCourse();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var courseToserach = from Cours
                                          in context.Courses
                                         where Cours.CourseNumber.ToString() == textBox6.Text
                                         select Cours;

                    if (!courseToserach.Any())
                    {
                        MessageBox.Show("CourseNumber not found.");
                        return;
                    }

                    foreach (var cours in courseToserach)
                    {
                        label18.Text = "Code : " + cours.CourseNumber + "  " + "Name : " + cours.CourseTitle + "  " + "Duration : " + cours.Duration_hours_ + " Hours";
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button13_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    int teacherId = Int32.Parse(textBox11.Text);
                    string courseNumber = textBox10.Text;

                    // Check if the CourseNumber exists in Courses table
                    var courseExists = context.Courses.Any(c => c.CourseNumber == courseNumber);

                    // Check if the TeacherId exists in Teachers table
                    var teacherExists = context.Teachers.Any(t => t.TeacherId == teacherId);

                    if (courseExists && teacherExists)
                    {
                        var registrationToAdd = new Registration();
                        registrationToAdd.RegistrationId = Int32.Parse(textBox12.Text);
                        registrationToAdd.TeacherId = teacherId;
                        registrationToAdd.CourseNumber = courseNumber;
                        context.Registrations.Add(registrationToAdd);
                        context.SaveChanges();
                        MessageBox.Show($"Registration Added Successfully", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                        addRegistration();
                    }
                    else
                    {
                        MessageBox.Show($"Course Number or Teacher ID doesn't exist in the data.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void addRegistration()
        {
            // select Registration from database 
            try
            {
                using (var context = new Entities())
                {
                    var selectRegistration = from Registration in context.Registrations select Registration;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Registration");
                    dt.Columns.Add("TeacherId");
                    dt.Columns.Add("CourseNumber");

                    foreach (var registration in selectRegistration)
                    {
                        dt.Rows.Add(registration.RegistrationId, registration.TeacherId, registration.CourseNumber);
                    }

                    dataGridView3.DataSource = dt;
                    textBox12.Clear();
                    textBox11.Clear();
                    textBox10.Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var registrationToEdit = from Registration
                                        in context.Registrations
                                             where Registration.RegistrationId.ToString() == textBox12.Text
                                             select Registration;

                    foreach (var registration in registrationToEdit)
                    {
                        registration.RegistrationId = Int32.Parse(textBox12.Text);
                        registration.TeacherId = Int32.Parse(textBox11.Text);
                        registration.CourseNumber = textBox10.Text;
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Registration Edited Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addRegistration();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new Entities())
                {
                    var registrationTodelete = from Registration
                                          in context.Registrations
                                               where Registration.RegistrationId.ToString() == textBox12.Text
                                               select Registration;

                    foreach (var registration in registrationTodelete)
                    {
                        context.Registrations.Remove(registration);
                    }

                    context.SaveChanges();
                    MessageBox.Show($"Registration Deleted Successfully", "Success",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    addRegistration();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void button14_Click(object sender, EventArgs e)
        {

            try
            {
                using (var context = new Entities())
                {
                    var registrationToserach = from Registration
                                          in context.Registrations
                                               where Registration.RegistrationId.ToString() == textBox13.Text
                                               select Registration;

                    if (!registrationToserach.Any())
                    {
                        MessageBox.Show("RegistrationID not found.");
                        return;
                    }

                    foreach (var registration in registrationToserach)
                    {
                        label19.Text = "TeacherId : " + registration.TeacherId + "\nCourseNumber : " + registration.CourseNumber;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
