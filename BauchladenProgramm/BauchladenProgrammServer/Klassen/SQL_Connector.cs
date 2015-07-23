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
    public class SQL_Connector
    {
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
        

        private SQL_Connector(string dataSource = @"Data Source=DOMINIK-PC;", string initialCatalog = "Initial Catalog=Bauchladen;", string persistSecurity = "Persist Security Info=false;", string userID = "User ID=jula;", string password = "Password=jula2015;", string asynchProcessing = "Asynchronous Processing=True")
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


// Teilnehmer---------------------------------------
        public async void addTeilnehmer(Teilnehmer teilnehmer)
        {
            if (con.State == ConnectionState.Open)
            { 
           
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO Teilnehmer (Vorname, Nachname,inaktiv) VALUES (@Vorname, @Nachname,0) insert into Konto(teilnehmer) values(IDENT_CURRENT('Teilnehmer')) insert into Kontostand(kontostand,datum,konto) values (0.00,@date,IDENT_CURRENT('Konto'))";
                cmd.CommandType = CommandType.Text;
          
                cmd.Parameters.Add(new SqlParameter("@Vorname", SqlDbType.VarChar));
                cmd.Parameters.Add(new SqlParameter("@Nachname", SqlDbType.VarChar));            
                cmd.Parameters["@Vorname"].Value = teilnehmer.VorName;
                cmd.Parameters["@Nachname"].Value = teilnehmer.NachName;
                cmd.Parameters.Add("@date", SqlDbType.Char);
                cmd.Parameters["@date"].Value = DateTime.Now;
                try
                {
                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Einfügen der Daten:\n\n" + ex.Message, "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
        }

        public List<Teilnehmer> selectTeilnehmerAll()
        {
            List<Teilnehmer> t = null;
            SqlDataReader reader=null;

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    t = new List<Teilnehmer>();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "SELECT id,vorname,nachname FROM Teilnehmer where inaktiv=0";
                    cmd.CommandType = CommandType.Text;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            t.Add(new Teilnehmer(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), 0));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine Teilnehmer gefunden");
                    }
                    reader.Close();
                }
                catch (SqlException ex)
                {
                    reader.Close();
                    MessageBox.Show("Fehler bei Teilnehmerliste abrufen /n/n" + ex.Message, "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return t;
        }

        public Teilnehmer selectTeilnehmer(int id)
        {
            Teilnehmer t = null;
            SqlDataReader reader=null;
            if (con.State == ConnectionState.Open)
            {
                try
                {
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandText = "select t.id,t.Vorname,t.Nachname,ks.kontostand from (Teilnehmer t join Konto k on t.id = k.teilnehmer) join Kontostand ks on ks.konto=k.id where k.id = @suchId and inaktiv=0 order by ks.datum desc";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@suchId", SqlDbType.Int);
                    cmd.Parameters["@suchId"].Value = id.ToString();

                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        t = new Teilnehmer(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3));
                    }
                    else
                    {
                        MessageBox.Show("Keine Teilnehmer gefunden");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    reader.Close();
                    MessageBox.Show("Fehler beim Kontostand abruf des Teilnehmers \\n\\n" + ex.Message, "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return t;
        }

        public void deleteTn(int userId)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "delete from Teilnehmer where id= @Id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Id", SqlDbType.Char);
            cmd.Parameters["@Id"].Value = userId.ToString();

            cmd.ExecuteNonQuery();
        }

        public void setTnInaktiv(int userId)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "update Teilnehmer set inaktiv =1 where id=@Id";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Id", SqlDbType.Char);
            cmd.Parameters["@Id"].Value = userId.ToString();

            cmd.ExecuteNonQuery();
        }
 
// Produkte----------------------------------------------------------------
         public List<Produkt> selectProduktAll()
         {
            List<Produkt> tmpP = new List<Produkt>();

            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Produkt;";
            cmd.CommandType = CommandType.Text;           

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    tmpP.Add(new Produkt(reader.GetInt32(0).ToString(), reader.GetString(1),reader.GetDecimal(2)));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();
            

            return tmpP;
         }

         public void setEinkauf(string userId, string productId, string anzahl)
         {
             SqlCommand cmd = con.CreateCommand();
             SqlDataReader reader;

             cmd.Parameters.Add("@Id", SqlDbType.Char);
             cmd.Parameters["@Id"].Value = userId.ToString();

             cmd.Parameters.Add("@date", SqlDbType.Char);
             cmd.Parameters["@date"].Value = DateTime.Now;

             cmd.Parameters.Add("@pId", SqlDbType.Char);
             cmd.Parameters["@pId"].Value = productId.ToString();

             for (int i = 0; i < int.Parse(anzahl); i++)
             {
                 cmd.CommandText = "select * from Einkauf where abgerechnet = 0";
                 cmd.CommandType = CommandType.Text;

                 reader = cmd.ExecuteReader();
                 if (reader.HasRows)
                 {
                     reader.Read();
                     cmd.CommandText = "insert into ProduktEinkauf (produkt,einkauf) values(@pId,@einkaufID)";
                     cmd.CommandType = CommandType.Text;

                     cmd.Parameters.Add("@einkaufID", SqlDbType.Char);
                     cmd.Parameters["@einkaufID"].Value = reader.GetInt32(0).ToString();
                     reader.Close();
                     cmd.ExecuteNonQuery();
                 }
                 else
                 {
                     reader.Close();
                     cmd.CommandText = "insert into Einkauf (datum,teilnehmer,abgerechnet) values (@date,@Id,0) insert into ProduktEinkauf (produkt,einkauf) values(@pId, IDENT_CURRENT('Einkauf'))";
                     cmd.CommandType = CommandType.Text;
                     cmd.ExecuteNonQuery();
                 }  
             }           
         }

         public void setEinkaufOK(Int32 userId)
         {
             SqlCommand cmd = con.CreateCommand();
             SqlDataReader reader;
             double kontostand = 0;

             cmd.CommandText = "select ks.kontostand, k.id from Konto k join Kontostand ks on k.id=ks.konto where k.teilnehmer= @Id order by datum desc";
             cmd.CommandType = CommandType.Text;

             cmd.Parameters.Add("@Id", SqlDbType.Char);
             cmd.Parameters["@Id"].Value = userId.ToString();

             reader = cmd.ExecuteReader();
             if (reader.HasRows)
             {
                 reader.Read();
                 kontostand = double.Parse(reader.GetDecimal(0).ToString());
                 cmd.Parameters.Add("@kId", SqlDbType.Int);
                 cmd.Parameters["@kId"].Value = reader.GetInt32(1);
             }
             reader.Close();

             cmd.CommandText = "select sum(p.preis) as'endpreis' from ProduktEinkauf pe join Produkt p on pe.produkt=p.id join Einkauf e on e.id=pe.einkauf where e.teilnehmer=@Id and e.abgerechnet != 1 group by e.id";
             cmd.CommandType = CommandType.Text;
             reader = cmd.ExecuteReader();
             if (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     kontostand=kontostand - double.Parse(reader.GetDecimal(0).ToString());
                 }
                     cmd.Parameters.Add("@kontostand", SqlDbType.Decimal);
                     cmd.Parameters["@kontostand"].Value = kontostand;
                     reader.Close();
                     cmd.Parameters.Add("@dateN", SqlDbType.Char);
                     cmd.Parameters["@dateN"].Value = DateTime.Now;

                     cmd.CommandText = "insert into Kontostand(kontostand,konto,datum) values (@kontostand,@kId,@dateN) update Einkauf set abgerechnet = 1 where id= IDENT_CURRENT('Einkauf')";
                     cmd.CommandType = CommandType.Text;
                     cmd.ExecuteNonQuery();
             }
         }

         public void setEinzahlung(string userId, string betrag)
         {
             SqlCommand cmd = con.CreateCommand();
             SqlDataReader reader;

             cmd.CommandText = "select ks.kontostand, k.id from Konto k join Kontostand ks on k.id=ks.konto where teilnehmer= @Id order by datum desc";
             cmd.CommandType = CommandType.Text;

             cmd.Parameters.Add("@Id", SqlDbType.Char);
             cmd.Parameters["@Id"].Value = userId.ToString();

             reader = cmd.ExecuteReader();
             if (reader.HasRows)
             {
                 reader.Read();
                 cmd.Parameters.Add("@einzahlung", SqlDbType.Decimal);
                 cmd.Parameters["@einzahlung"].Value = int.Parse(betrag) + reader.GetDecimal(0);
                 cmd.Parameters.Add("@kId", SqlDbType.Int);
                 cmd.Parameters["@kId"].Value = reader.GetInt32(1);
                 reader.Close();
                 cmd.Parameters.Add("@date", SqlDbType.DateTime);
                 cmd.Parameters["@date"].Value = DateTime.Now;

                 cmd.CommandText = "insert into Kontostand(kontostand,konto,datum) values (@einzahlung,@kId,@date)";
                 cmd.CommandType = CommandType.Text;
                 cmd.ExecuteNonQuery();

             }
             else
             {
                 MessageBox.Show("No rows found.");
             }
         }

         

        public async Task<bool> CheckDbConnection()
        {            
            try
            {
                using (var connection = new SqlConnection(@"Data Source=192.168.2.46\SQLEXPRESS;Initial Catalog=Jula;Persist Security Info=True;User ID=sa;Password=12345;Asynchronous Processing=True;Connection Timeout=2"))
                {                   
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Verbindung zu Datenbank abgebrochen!" + ex.Message);
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
