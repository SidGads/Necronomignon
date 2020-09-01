using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UnityEngine;

public class BeastManager
{
    static string con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Sidne\\OneDrive\\Documents\\GitHub\\Necronomignon\\Assets\\Scripts\\data\\Beast_Database.mdf;Integrated Security=True";
    public void Start()
    {
//        SqlConnectionStringBuilder con = new SqlConnectionStringBuilder();
//        con.DataSource = "Beast_Database.mdf";
//        con.UserID = "sa";
//        con.InitialCatalog = "master";

        SqlConnection myConnection = new SqlConnection(con);

        string line = "select name from Beast_directory where id=1";
        SqlCommand cmd = new SqlCommand(line, myConnection);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        oReader.Read();
        
        Console.WriteLine(oReader["name"].ToString());
        

        myConnection.Close();
    }

    public Beast get(int id)
    {
        Beast b = new Beast();
        SqlConnection myConnection = new SqlConnection(con);
        string line = "select * from Beast_directory where id=@id";

        SqlCommand cmd = new SqlCommand(line, myConnection);

        cmd.Parameters.AddWithValue("@id", id);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        oReader.Read();
        
        b.name = oReader["name"];
        b.Summoned = (bool)oReader["isSummoned"];
        b.HitPoints = (int)oReader["hp"];
        b.Defense = (int)oReader["defence"];
        b.Power = (int)oReader["power"];
        b.Speed = (int)oReader["speed"];
        b.Skill = (int)oReader["skill"];
        b.MOVES = (int)oReader["moves"];
        b.MoveA = (int)oReader["moveA"];
        b.MoveB = (int)oReader["moveB"];


        myConnection.Close();

        return b;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
