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
        public FrmClubRegistration()
        {
            InitializeComponent();
        }

        private ClubRegistrationQuery clubRegistrationQuery;
        private int ID, Age, count;
        private string FirstName, MiddleName, LastName, Gender, Program;

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshListOfClubMembers();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            clubRegistrationQuery.RegisterStudent();
        }

        private long StudentID;

        public void RefreshListOfClubMembers()
        {
            clubRegistrationQuery.DisplayList();
            dataGridView1.DataSource = clubRegistrationQuery.bindingSource;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClubRegistrationQuery clubRegistrationQuery = new ClubRegistrationQuery();
            RefreshListOfClubMembers();

        }


        public int RegistrationID()
        {
            ID = ++count;
            return ID;
        }
    }
}
