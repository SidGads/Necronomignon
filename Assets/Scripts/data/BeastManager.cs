using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using UnityEngine;

public class BeastManager
{
    //The conection String to connect to the database
    static string con = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Sidne\\OneDrive\\Documents\\GitHub\\Necronomignon\\Assets\\Scripts\\data\\Beast_Database.mdf;Integrated Security=True";
    public void Start()
    {

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

        b.Name = oReader["name"].ToString();
        b.Summoned = (bool)oReader["isSummoned"];
        b.HitPoints = (int)oReader["hp"];
        b.Defense = (int)oReader["defence"];
        b.Power = (int)oReader["power"];
        b.Speed = (int)oReader["speed"];
        b.Skill = (int)oReader["skill"];
        b.MOVES1 = (int)oReader["moves"];
        b.MoveA = (int)oReader["moveA"];
        b.MoveB = (int)oReader["moveB"];


        myConnection.Close();

        return b;
    }

    public Beast getFromName(String name)
    {
        Beast b = new Beast();
        SqlConnection myConnection = new SqlConnection(con);
        string line = "select * from Beast_directory where name=@name";

        SqlCommand cmd = new SqlCommand(line, myConnection);

        cmd.Parameters.AddWithValue("@name", name);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        oReader.Read();

        b.Name = oReader["name"].ToString();
        b.Summoned = (bool)oReader["isSummoned"];
        b.HitPoints = (int)oReader["hp"];
        b.Defense = (int)oReader["defence"];
        b.Power = (int)oReader["power"];
        b.Speed = (int)oReader["speed"];
        b.Skill = (int)oReader["skill"];
        b.MOVES1 = (int)oReader["moves"];
        b.MoveA = (int)oReader["moveA"];
        b.MoveB = (int)oReader["moveB"];


        myConnection.Close();

        return b;
    }

    internal static Beast getS(int id)
    {
        Beast b = new Beast();
        SqlConnection myConnection = new SqlConnection(con);
        string line = "select * from Beast_directory where id=@id";

        SqlCommand cmd = new SqlCommand(line, myConnection);

        cmd.Parameters.AddWithValue("@id", id);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        oReader.Read();

        b.Name = oReader["name"].ToString();
        b.Summoned = (bool)oReader["isSummoned"];
        b.HitPoints = (int)oReader["hp"];
        b.Defense = (int)oReader["defence"];
        b.Power = (int)oReader["power"];
        b.Speed = (int)oReader["speed"];
        b.Skill = (int)oReader["skill"];
        b.MOVES1 = (int)oReader["moves"];
        b.MoveA = (int)oReader["moveA"];
        b.MoveB = (int)oReader["moveB"];


        myConnection.Close();

        return b;
    }

    public static Beast getFromNameS(String name)
    {
        Beast b = new Beast();
        SqlConnection myConnection = new SqlConnection(con);
        string line = "select * from Beast_directory where name=@name";

        SqlCommand cmd = new SqlCommand(line, myConnection);

        cmd.Parameters.AddWithValue("@name", name);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        oReader.Read();

        b.Name = oReader["name"].ToString();
        b.Summoned = (bool)oReader["isSummoned"];
        b.HitPoints = (int)oReader["hp"];
        b.Defense = (int)oReader["defence"];
        b.Power = (int)oReader["power"];
        b.Speed = (int)oReader["speed"];
        b.Skill = (int)oReader["skill"];
        b.MOVES1 = (int)oReader["moves"];
        b.MoveA = (int)oReader["moveA"];
        b.MoveB = (int)oReader["moveB"];
        b.Static_image = oReader["static_image"].ToString();


        myConnection.Close();

        return b;
    }

    public int getAmountOfEntries()
    {
        SqlConnection myConnection = new SqlConnection(con);
        string line = "select (*)count from Beast_directory";

        SqlCommand cmd = new SqlCommand(line, myConnection);

        myConnection.Open();

        SqlDataReader oReader = cmd.ExecuteReader();


        oReader.Read();

        int x = (int)oReader["count"];

        return x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
