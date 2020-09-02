using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionList : MonoBehaviour
{
    public string mission; //Set in inspector

    public List<Beast> enemies = new List<Beast>();

    private void Awake()
    {
        if(mission == "sample")
        {

            enemies.Add(BeastManager.getFromNameS("Sunbather")); //A1
            enemies.Add(BeastManager.getFromNameS("Gaia")); //B1
            enemies.Add(BeastManager.getFromNameS("Cthulhu")); //A2
            enemies.Add(null); //B2
            enemies.Add(null); //A3
            enemies.Add(BeastManager.getFromNameS("Trogdor")); //B3
        }
    }

}
