using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace _07Lab1_part2
{
    public  class ClubRegistrationQuery
    {
        private SqlConnection sqlConnect;
        private SqlCommand sqlCommand;
        private SqlDataAdapter sqlAdapter;
        private SqlDataAdapter sqlReader;

        public DataTable dataTable;
        public BindingSource bindingSource;

        private string connectionString = "Data Source=LAB-A-PC00;Initial Catalog=PaguiliganClubDB;Persist " +
            "Security Info=True;User ID=paguiligan.j;Password=***********;Trust Server Certificate=True";


        public string _FirstName, _MiddleName, _LastName, _Gender, _Program;
    }
}
