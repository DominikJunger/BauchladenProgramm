using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Data.SqlClient;
using BauchladenProgramm.Backend_Klassen;
using System.Threading.Tasks;

namespace BauchladenProgrammServer.Klassen
{
    class SQL_Connector
    {
        private string dataSource;       
        private string initialCatalog;       
        private string persistSecurity;      
        private string userID;       
        private string password;       
        private string asynchProcessing;
   

        private SqlConnection con;
    

        public SQL_Connector(string dataSource = @"Data Source=.\SQLEXPRESS;", string initialCatalog = "Initial Catalog=DBTest;", string persistSecurity = "Persist Security Info=True;", string userID = "User ID=sa;", string password = "Password=12345;", string asynchProcessing = "Asynchronous Processing=True")
        {
            this.DataSource = dataSource;
            this.InitialCatalog = initialCatalog;
            this.PersistSecurity = persistSecurity;
            this.UserID = userID;
            this.Password = password;
            this.AsynchProcessing = asynchProcessing;         
        }

        public ConnectionState openConnection()
        {
            con = new SqlConnection(DataSource + InitialCatalog + PersistSecurity + UserID + Password + AsynchProcessing);
            con.Open();

            return con.State;
        }

        public void addTeilnehmer(List<Teilnehmer> teilnehmer)
        {
          
        }



        public void closeConnection()
        {
            con.Close();
        }

        
        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        public string InitialCatalog
        {
            get { return initialCatalog; }
            set { initialCatalog = value; }
        }

        public string PersistSecurity
        {
            get { return persistSecurity; }
            set { persistSecurity = value; }
        }

        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string AsynchProcessing
        {
            get { return asynchProcessing; }
            set { asynchProcessing = value; }
        }
    }
}
