using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using BauchladenProgrammServer.Backend_Klassen;

namespace BauchladenProgrammServer.Klassen
{
    /// <summary>
    /// Klasse zum regeln der Verbindung zur SQL-Datenbank
    /// !Statements nicht fertig, aufgrund der unwissendheit der Tabellennamen.!
    /// </summary>
    class SQL_Connector
    {
        
        //-------- Teilnehmer abrufen -------------------------------------
        private const string SELECT_TEILNEHMER_BY_ID = "SELECT * FROM ... WHERE ID LIKE @ID;";
        private const string SELECT_TEILNEHMER_BY_FIRSTNAME = "SELECT * FROM ... WHERE Vorname LIKE @Vorname;";
        private const string SELECT_TEILNEHMER_BY_LASTNAME = "SELECT * FROM ... WHERE Nachname LIKE @Nachname;";
        private const string INSERT_ALL_TEILNEHMER = "INSERT INTO TestType (Vorname, Nachname) VALUES (@Vorname, @Nachname);";

        private const string SELECT_TEILNEHMER_BY_WHATEVER = "SELECT * FROM Teilnehmer WHERE CAST(Teilnehmer.ID as varchar(3)) = @ID OR Teilnehmer.Nachname = CAST(@Nachname as varchar(50)) OR Teilnehmer.Vorname = CAST(@Vorname as varchar(50));";

        //-------- Produkte abrufen -------------------------------------
        private const string SELECT_PRODUKT_ALL = "SELECT * FROM Produkt;";


        //---------------------------------------------------------------
        private string dataSource;       
        private string initialCatalog;       
        private string persistSecurity;      
        private string userID;       
        private string password;       
        private string asynchProcessing;   

        private static SQL_Connector instance = null;

        private SqlConnection con;

        public static SQL_Connector getInstance()
        {
            if (instance == null)
                instance = new SQL_Connector();
            return instance;
        }
        

        private SQL_Connector(string dataSource = @"Data Source=192.168.2.46\SQLEXPRESS;", string initialCatalog = "Initial Catalog=Jula;", string persistSecurity = "Persist Security Info=True;", string userID = "User ID=sa;", string password = "Password=12345;", string asynchProcessing = "Asynchronous Processing=True")
        {
            this.DataSource = dataSource;
            this.InitialCatalog = initialCatalog;
            this.PersistSecurity = persistSecurity;
            this.UserID = userID;
            this.Password = password;
            this.AsynchProcessing = asynchProcessing;         
        }

        public async Task<ConnectionState> openConnection()
        {
            con = new SqlConnection(DataSource + InitialCatalog + PersistSecurity + UserID + Password + AsynchProcessing);
            try
            {
                await con.OpenAsync();                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Fehler bei dem Versuch eine Verbindung mit dem SQL-Server herzustellen:\n\n" + ex.Message + "\n\nBitte Server starten oder Administrator benachrichtigen.", "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TaskCanceledException ex)
            {
                // bis jz nur aufgetreten, wenn das Hauptprogramm mit dem X rechts oben geschlossen wurde.
                // Während des Ausführung dieser Methode. Da damit aber das Programm geschlossen wird, 
                // ka was hier noch behandelt werden soll
            }
                     
            return con.State;
        }

        public bool isClosed()
        {
            return con.State == ConnectionState.Closed ? true : false;
        }

        public async void addTeilnehmer(List<Teilnehmer> teilnehmer)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = INSERT_ALL_TEILNEHMER;
            cmd.CommandType = CommandType.Text;
          
            cmd.Parameters.Add(new SqlParameter("@Vorname", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@Nachname", SqlDbType.VarChar));
            foreach (Teilnehmer t in teilnehmer)
            {              
                cmd.Parameters["@Vorname"].Value = "Test";
                cmd.Parameters["@Nachname"].Value = "Test1";
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Fehler beim Einfügen der Daten:\n\n" + ex.Message, "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
                
            }           
        }

        public List<Teilnehmer> selectTeilnehmerBySomething(string parameter)
        {
            List<Teilnehmer> t = new List<Teilnehmer>();
            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SELECT_TEILNEHMER_BY_WHATEVER;
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.AddWithValue("ID", parameter);
            cmd.Parameters.AddWithValue("Nachname", parameter);
            cmd.Parameters.AddWithValue("Vorname", parameter);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   t.Add(new Teilnehmer(reader.GetInt32(0), reader.GetString(2), reader.GetString(1)));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();
            return t;
        }

        public Teilnehmer selectTeilnehmerByID(int id)
        {
            Teilnehmer t = null;
            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SELECT_TEILNEHMER_BY_ID;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("ID", id);
            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                   t = new Teilnehmer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();
            return t;
        }

        public Teilnehmer selectTeilnehmerByFirstName(string vorname)
        {
            Teilnehmer t = null;
            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SELECT_TEILNEHMER_BY_FIRSTNAME;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("Vorname", vorname);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t = new Teilnehmer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }
            reader.Close();
            return t;
        }

        public Teilnehmer selectTeilnehmerByLastName(string nachname)
        {
            Teilnehmer t = null;
            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SELECT_TEILNEHMER_BY_LASTNAME;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("Nachname", nachname);

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    t = new Teilnehmer(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();
            

            return t;
        }

         public List<Produkt> selectProduktAll()
         {
            List<Produkt> tmpP = new List<Produkt>();

            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = SELECT_PRODUKT_ALL;
            cmd.CommandType = CommandType.Text;           

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tmpP.Add(new Produkt(reader.GetInt32(0), reader.GetString(1),reader.GetDecimal(2)));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();
            

            return tmpP;
         }

        public async Task<bool> CheckDbConnection()
        {
           
            try
            {
                using (var connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DBTest;Persist Security Info=True;User ID=sa;Password=12345;Asynchronous Processing=True;Connection Timeout=2"))
                {
                   
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verbindung zu Datenbank abgebrochen!");
                return false; // any error is considered as db connection error for now
            }
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
