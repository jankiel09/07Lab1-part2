using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _07Lab1_part2
{
    public partial class FrmClubRegistration : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        public FrmClubRegistration()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery(); 
            count = 0; 
        }

     
        // Update Button
        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private long StudentID;

        // Refresh Button
        private void button3_Click(object sender, EventArgs e)
        {
            if (clubRegistrationQuery != null)
            {
                clubRegistrationQuery.DisplayList();
                dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
            }
        }

        // Register Button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                ID = RegistrationID();
                StudentID = long.Parse(txtStudID.Text);
                FirstName = txtFname.Text;
                MiddleName = txtMname.Text;
                LastName = txtLname.Text;
                Age = int.Parse(txtAge.Text);
                Gender = cbGender.Text;
                Program = cbProgram.Text;

                clubRegistrationQuery.RegisterStudent(ID, StudentID, FirstName, MiddleName,
                                                        LastName, Age, Gender, Program);

                MessageBox.Show("Student Registered Successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInputs();
                RefreshListOfClubMembers();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Registration Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearInputs()
        {
            txtStudID.Clear();
            txtFname.Clear();
            txtMname.Clear();
            txtLname.Clear();
            txtAge.Clear();
            cbGender.SelectedIndex = -1;
            cbProgram.SelectedIndex = -1;
        }



        public void RefreshListOfClubMembers()
        {
            if (clubRegistrationQuery != null)
            {
                clubRegistrationQuery.DisplayList();
                dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
            }
        }

        // FrmClubRegistration Load
        private void Form1_Load(object sender, EventArgs e)
        {
            clubRegistrationQuery = new ClubRegistrationQuery();
            count = 0; 
            RefreshListOfClubMembers();

        }

        public int RegistrationID()
        {
            ID = ++count;
            return ID;


        }
    }
}
