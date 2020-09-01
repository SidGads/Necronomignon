using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UnityEngine;

public class BeastManager
{
    // Start is called before the first frame update
    public void Start()
    {
//        SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
//        con.DataSource = "Beast_Database.mdf";
//        con.UserID = "sa";
//        con.InitialCatalog = "master";

        string con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Sidne\\OneDrive\\Documents\\GitHub\\Necronomignon\\Assets\\Scripts\\data\\Beast_Database.mdf;Integrated Security=True";
        SqlConnection myConnection = new SqlConnection(con);

        string line = "select name from Beast_directory where id=1";
        SqlCommand cmd = new SqlCommand(line, myConnection);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        while (oReader.Read())
        {
            Console.WriteLine(oReader["name"].ToString());
        }

        myConnection.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
