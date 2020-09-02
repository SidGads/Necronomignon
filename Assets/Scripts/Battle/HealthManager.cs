using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public BeastDatabase beastDatabase;
    public BattleManager battleManager;

    public int player1 = 0;
    public int player2 = 0;
    public int player3 = 0;
    public int player4 = 0;
    public int playersLeft = 4;

    public int enemy1 = 0;
    public int enemy2 = 0;
    public int enemy3 = 0;
    public int enemy4 = 0;
    public int enemiesLeft = 0;

    List<Beast> squad = new List<Beast>();
    List<Beast> enemies = new List<Beast>();

    //Get the health for each beast in play from BeastDatabase
    public void GetHealth(List<Beast> players, List<Beast> opposing)
    {
        squad = players;
        enemies = opposing;

        player1 = players[0].HitPoints;
        player2 = players[1].HitPoints;
        player3 = players[2].HitPoints;
        player4 = players[3].HitPoints;

        if(opposing[0] != null) 
        {
            enemiesLeft += 1;
            enemy1 = opposing[0].HitPoints;
        }
        if (opposing[1] != null)
        {
            enemiesLeft += 1;
            enemy2 = opposing[1].HitPoints;
        }
        if (opposing[2] != null)
        {
            enemiesLeft += 1;
            enemy3 = opposing[2].HitPoints;
        }
        if (opposing[3] != null)
        {
            enemiesLeft += 1;
            enemy4 = opposing[3].HitPoints;
        }
    }

    //Subtract the damage from the target's health
    public void UpdateHealth(Beast target, int damage, string attacking) 
    {
        if (target == squad[0] && attacking != "Player")
        {
            player1 -= damage;
            if(player1 <= 0)
            {
                Debug.Log(target.Name + " is knocked out.");
                CheckRemainingPlayers();
                battleManager.RemoveBeast("player1");
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == squad[1] && attacking != "Player")
        {
            player2 -= damage;
            if (player2 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                CheckRemainingPlayers();
                battleManager.RemoveBeast("player2");
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == squad[2] && attacking != "Player")
        {
            player3 -= damage;
            if (player3 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                CheckRemainingPlayers();
                battleManager.RemoveBeast("player3");
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == squad[3] && attacking != "Player")
        {
            player4 -= damage;
            if (player4 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                battleManager.RemoveBeast("player4");
                CheckRemainingPlayers();
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == enemies[0] && attacking == "Player")
        {
            enemy1 -= damage;
            if (enemy1 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                battleManager.RemoveBeast("enemy1");
                CheckRemainingOpposing();
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == enemies[1] && attacking == "Player")
        {
            enemy2 -= damage;
            if (enemy2 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                battleManager.RemoveBeast("enemy2");
                CheckRemainingOpposing();
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == enemies[2] && attacking == "Player")
        {
            enemy3 -= damage;
            if (enemy3 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                battleManager.RemoveBeast("enemy3");
                CheckRemainingOpposing();
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
        else if (target == enemies[3] && attacking == "Player")
        {
            enemy4 -= damage;
            if (enemy4 <= 0)
            {
                Debug.Log(target + " is knocked out.");
                battleManager.RemoveBeast("enemy4");
                CheckRemainingOpposing();
            }
            else
            {
                DisplayHealthLeft(attacking, target);
            }
        }
    }

    void DisplayHealthLeft(string attacking, Beast target)
    {
        Debug.Log(attacking + "'s " + target + " has " + target.HitPoints + " health left.");
    }

    //Check to see if there are any players left, if not end game
    void CheckRemainingPlayers() 
    {
        playersLeft -= 1;
        if(playersLeft == 0)
        {
            Debug.Log("Opposing Team Wins. Better Luck Nex Time.");
            StartCoroutine(LoadMap());
        }
    }

    //Check to see if there are any enemies left, if not end game
    void CheckRemainingOpposing()
    {
        enemiesLeft -= 1;
        if (enemiesLeft == 0)
        {
            Debug.Log("Congratulations! You Win!");
            StartCoroutine(LoadMap());
        }
    }

    //After 1 second load the Map scene
    IEnumerator LoadMap()
    {
        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("Map");
    }
}
