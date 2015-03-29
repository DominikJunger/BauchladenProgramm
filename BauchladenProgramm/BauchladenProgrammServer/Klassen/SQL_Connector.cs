﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using BauchladenProgramm.Backend_Klassen;

namespace BauchladenProgrammServer.Klassen
{
    /// <summary>
    /// Klasse zum regeln der Verbindung zur SQL-Datenbank
    /// !Statements nicht fertig, aufgrund der unwissendheit der Tabellennamen.!
    /// </summary>
    class SQL_Connector
    {
        
        //-------- Teilnehmer abrufen -------------------------------------
        private const string SELECT_TEILNEHMER_BY_ID = "SELECT * FROM ... WHERE ID LIKE @ID";
        private const string SELECT_TEILNEHMER_BY_FIRSTNAME = "SELECT * FROM ... WHERE Vorname LIKE @Vorname";
        private const string SELECT_TEILNEHMER_BY_LASTNAME = "SELECT * FROM ... WHERE Nachname LIKE @Nachname";

        //-------- Produkte abrufen -------------------------------------
        private const string SELECT_PRODUKT_ALL = "SELECT FROM ...";
        
        //TODO SQL Statements hinzufügen, anpassen


        //---------------------------------------------------------------
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
                   t = new Teilnehmer(reader.GetString(1),reader.GetString(2),new DateTime(),"TestHausen");
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
                    t = new Teilnehmer(reader.GetString(1), reader.GetString(2), new DateTime(), "TestHausen");
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
                    t = new Teilnehmer(reader.GetString(1), reader.GetString(2), new DateTime(), "TestHausen");
                }
            }
            else
            {
                MessageBox.Show("No rows found.");
            }

            reader.Close();

            return t;
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
