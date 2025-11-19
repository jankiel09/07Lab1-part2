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
    public partial class FrmUpdateMember : Form
    {
        private ClubRegistrationQuery clubRegistrationQuery;

        public FrmUpdateMember()
        {
            InitializeComponent();
            clubRegistrationQuery = new ClubRegistrationQuery();
        }

        private void FrmUpdateMember_Load(object sender, EventArgs e)
        {
            LoadStudentIds();

            cbStudId.SelectedIndexChanged += cbStudentId_SelectedIndexChanged;
        }

        private void LoadStudentIds()
        {
            try
            {
                clubRegistrationQuery.DisplayList();
                cbStudId.Items.Clear();

                foreach (DataRow row in clubRegistrationQuery.dataTable.Rows)
                {
                    cbStudId.Items.Add(row["StudentId"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Student IDs: " + ex.Message);
            }
        }

        private void cbStudentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbStudId.SelectedItem != null)
                {
                    long studentId = long.Parse(cbStudId.SelectedItem.ToString());
                    DataRow member = clubRegistrationQuery.GetMemberByStudentId(studentId);

                    if (member != null)
                    {
                        // Populate the fields with existing data
                        txtFname.Text = member["FirstName"].ToString();
                        txtMname.Text = member["MiddleName"].ToString();
                        txtLname.Text = member["LastName"].ToString();
                        txtAge.Text = member["Age"].ToString();
                        cbGender.Text = member["Gender"].ToString();
                        cbProgram.Text = member["Program"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading member data: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbStudId.SelectedItem == null)
                {
                    MessageBox.Show("Please select a Student ID first.", "Validation Error",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                long studentId = long.Parse(cbStudId.SelectedItem.ToString());
                string firstName = txtFname.Text;
                string middleName = txtMname.Text;
                string lastName = txtLname.Text;
                int age = int.Parse(txtAge.Text);
                string gender = cbGender.Text;
                string program = cbProgram.Text;

               
                clubRegistrationQuery.UpdateMember(studentId, firstName, middleName,
                                                  lastName, age, gender, program);

                MessageBox.Show("Member Updated Successfully!", "Success",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating member: " + ex.Message, "Update Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btnUpdate_Click(sender, e);
        }
    }
}
