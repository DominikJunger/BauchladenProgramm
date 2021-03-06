﻿using System;
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
        public void addTeilnehmer(Teilnehmer teilnehmer)
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
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Fehler beim Einfügen der Daten:\n\n" + ex.Message, "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                }
            }
        }

        public List<Teilnehmer> selectTeilnehmerAll(bool mitKontostand)
        {
            List<Teilnehmer> t = null;
            SqlDataReader reader=null;
            SqlCommand cmd = con.CreateCommand();

            if (con.State == ConnectionState.Open)
            {
                try
                {
                    t = new List<Teilnehmer>();
                    cmd.CommandText = "SELECT id,vorname,nachname,inaktiv FROM Teilnehmer";
                    cmd.CommandType = CommandType.Text;
                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            t.Add(new Teilnehmer(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), 0, reader.GetBoolean(3)));
                        }
                    }
                    else
                    {
                        MessageBox.Show("Keine Teilnehmer gefunden");
                    }
                    reader.Close();
                    if (mitKontostand)
                    {
                        foreach (Teilnehmer tn in t)
                        {
                            tn.Kontostand = this.selectTeilnehmer(tn.Id).Kontostand;
                        }
                    }
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
                    cmd.CommandText = "select t.id,t.Vorname,t.Nachname,ks.kontostand,t.inaktiv from (Teilnehmer t join Konto k on t.id = k.teilnehmer) join Kontostand ks on ks.konto=k.id where k.id = @suchId order by ks.datum desc";
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.Add("@suchId", SqlDbType.Int);
                    cmd.Parameters["@suchId"].Value = id.ToString();

                    reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        t = new Teilnehmer(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetString(2), reader.GetDecimal(3),reader.GetBoolean(4));
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
            SqlDataReader reader;
            cmd.Parameters.Add("@Id", SqlDbType.Char);
            cmd.Parameters["@Id"].Value = userId.ToString();

            cmd.CommandText = "SELECT * FROM Teilnehmer where id =@Id";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                if (reader.GetBoolean(3) == true)
                {
                    cmd.CommandText = "update Teilnehmer set inaktiv=0 where id=@Id";
                    cmd.CommandType = CommandType.Text;
                }
                else
                {
                    cmd.CommandText = "update Teilnehmer set inaktiv=1 where id=@Id";
                    cmd.CommandType = CommandType.Text;
                }
                reader.Close();
                cmd.ExecuteNonQuery();
            }
        }

        public PDFAuszahlung PDF(int userId)
        {
            PDFAuszahlung pdfA;
            EinkaufListe el = new EinkaufListe();
            List<Kontostand> einzahlung=new List<Kontostand>();
            List<Kontostand> auszahlung = new List<Kontostand>();
            List<Kontostand> auflistung = new List<Kontostand>();


            SqlDataReader reader;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandText = "select p.name,p.preis, count(name) as'anzahl',e.datum from Produkt p join ProduktEinkauf pe on p.id = pe.produkt join Einkauf e on e.id = pe.einkauf join Teilnehmer t on t.id = e.teilnehmer where t.id = @Id group by p.name,p.preis,e.datum, t.Vorname, t.Nachname order by datum";
            cmd.CommandType = CommandType.Text;

            cmd.Parameters.Add("@Id", SqlDbType.Char);
            cmd.Parameters["@Id"].Value = userId.ToString();

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    el.El.Add(new Einkauf(new Produkt(reader.GetString(0), reader.GetDecimal(1)), reader.GetInt32(2), reader.GetDateTime(3)));
                }
            }

            reader.Close();

            cmd.CommandText = "select t.Vorname, t.Nachname from Teilnehmer t where t.id = @Id";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    el.Tn = new Teilnehmer(reader.GetString(0), reader.GetString(1));
                }
            }

            reader.Close();

            cmd.CommandText = "select ks.kontostand, ks.datum from Kontostand ks join Konto k on k.id = ks.konto join Teilnehmer t on t.id = k.teilnehmer where ks.einzahlung= '1' and t.id = @Id order by datum";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    einzahlung.Add(new Kontostand(reader.GetDecimal(0),reader.GetDateTime(1).ToString()));
                }
            }
            reader.Close();

            cmd.CommandText = "select ks.kontostand, ks.datum from Kontostand ks join Konto k on k.id = ks.konto join Teilnehmer t on t.id = k.teilnehmer where ks.einzahlung= '0' and t.id = @Id order by datum";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    auszahlung.Add(new Kontostand(reader.GetDecimal(0), reader.GetDateTime(1).ToShortDateString()));
                }
            }
            reader.Close();

            cmd.CommandText = "select ks.kontostand, ks.datum from Kontostand ks join Konto k on k.id = ks.konto join Teilnehmer t on t.id = k.teilnehmer where t.id = @Id order by datum";
            cmd.CommandType = CommandType.Text;

            reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    auflistung.Add(new Kontostand(reader.GetDecimal(0), reader.GetDateTime(1).ToShortDateString()));
                }
            }
            reader.Close();


            pdfA = new PDFAuszahlung(el, auszahlung,einzahlung,auflistung);

            return pdfA;
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
                    tmpP.Add(new Produkt(reader.GetInt32(0).ToString(), reader.GetString(1), reader.GetDecimal(2), reader.GetBoolean(3), reader.GetBoolean(4)));
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();
            

            return tmpP;
         }

         public void addProdukt(Produkt produkt)
         {
             if (con.State == ConnectionState.Open)
             {

                 SqlCommand cmd = con.CreateCommand();
                 cmd.CommandText = "insert into Produkt(name,preis,verfügbarkeit,bücherTisch) values(@Name,@Preis,1,@bücher)";
                 cmd.CommandType = CommandType.Text;

                 cmd.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar));
                 cmd.Parameters.Add(new SqlParameter("@Preis", SqlDbType.Decimal));
                 cmd.Parameters["@Name"].Value = produkt.Name;
                 cmd.Parameters["@Preis"].Value = produkt.Preis;
                 cmd.Parameters.Add(new SqlParameter("@bücher", SqlDbType.Bit));
                 cmd.Parameters["@bücher"].Value = produkt.BücherT;

                 try
                 {
                     cmd.ExecuteNonQueryAsync();
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show("Fehler beim Einfügen der Daten:\n\n" + ex.Message, "SqlException", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 }
             }
         }

         public void deletePr(int proId)
         {
             SqlCommand cmd = con.CreateCommand();
             cmd.CommandText = "delete from Produkt where id= @Id";
             cmd.CommandType = CommandType.Text;

             cmd.Parameters.Add("@Id", SqlDbType.Char);
             cmd.Parameters["@Id"].Value = proId.ToString();

             cmd.ExecuteNonQuery();
         }
         public void setVerfügbarkeit(int proId)
         {
             SqlCommand cmd = con.CreateCommand();
             SqlDataReader reader;
             cmd.Parameters.Add("@Id", SqlDbType.Char);
             cmd.Parameters["@Id"].Value = proId.ToString();

             cmd.CommandText = "SELECT * FROM Produkt where id =@Id";
             cmd.CommandType = CommandType.Text;

             reader = cmd.ExecuteReader();
             if (reader.HasRows)
             {
                reader.Read();
                if (reader.GetBoolean(3) == true)
                {
                    cmd.CommandText = "update Produkt set verfügbarkeit=0 where id=@Id";
                    cmd.CommandType = CommandType.Text;
                }
                else
                {
                    cmd.CommandText = "update Produkt set verfügbarkeit=1 where id=@Id";
                    cmd.CommandType = CommandType.Text;
                }
                reader.Close();
                cmd.ExecuteNonQuery();
             }
         }

         public List<PDF_Produkt> getStatistik()
         {
             List<PDF_Produkt> tmp = new List<PDF_Produkt>();
             SqlCommand cmd = con.CreateCommand();
             SqlDataReader reader;

             cmd.CommandText = "select p.name, p.preis,count(*) from ProduktEinkauf pe join Produkt p on pe.produkt=p.id group by p.id,p.name,p.preis";
             cmd.CommandType = CommandType.Text;

             reader = cmd.ExecuteReader();
             if (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     tmp.Add(new PDF_Produkt(reader.GetString(0),reader.GetDecimal(1),reader.GetInt32(2)));
                 }
             }
             return tmp;
         }

//Set Methoden Datenbank
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

             cmd.Parameters.Add("@einkaufID", SqlDbType.Char);
             cmd.Parameters["@einkaufID"].Value = "";

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

                     cmd.CommandText = "insert into Kontostand(kontostand,konto,datum,einzahlung) values (@kontostand,@kId,@dateN,0) update Einkauf set abgerechnet = 1 where id= IDENT_CURRENT('Einkauf')";
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
                 cmd.Parameters["@einzahlung"].Value = Decimal.Parse(betrag) + reader.GetDecimal(0);
                 cmd.Parameters.Add("@kId", SqlDbType.Int);
                 cmd.Parameters["@kId"].Value = reader.GetInt32(1);
                 reader.Close();
                 cmd.Parameters.Add("@date", SqlDbType.DateTime);
                 cmd.Parameters["@date"].Value = DateTime.Now;

                 cmd.CommandText = "insert into Kontostand(kontostand,konto,datum,einzahlung) values (@einzahlung,@kId,@date,1)";
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
