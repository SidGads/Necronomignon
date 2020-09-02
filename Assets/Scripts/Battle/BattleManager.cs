using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleManager : MonoBehaviour
{
    public HealthManager healthManager;
    public BeastDatabase beastDatabase;
    public Attack attack;
    public LoadMission loadMission;

    public Text txtTurn;

    List<Beast> players = new List<Beast>();
    List<Beast> enemies = new List<Beast>();
    public List<Beast> roundOrder = new List<Beast>();
    public List<string> roundOrderTypes = new List<string>();
    List<Beast> attackPool = new List<Beast>();


    public int turn = 0;
    int totalMoves;
    int totalBeasts = 8;

    public Beast currentTurn;

    Beast slot1;
    Beast slot2;
    Beast slot3;
    Beast slot4;
    Beast slot5;
    Beast slot6;
    public Beast enemySlot1;
    public Beast enemySlot2;
    public Beast enemySlot3;
    public Beast enemySlot4;
    public Beast enemySlot5;
    public Beast enemySlot6;

    public bool player1Active = true;
    public bool player2Active = true;
    public bool player3Active = true;
    public bool player4Active = true;
    public bool enemy1Active = true;
    public bool enemy2Active = true;
    public bool enemy3Active = true;
    public bool enemy4Active = true;

    int player1TurnsTaken;
    int player2TurnsTaken;
    int player3TurnsTaken;
    int player4TurnsTaken;
    int enemy1TurnsTaken;
    int enemy2TurnsTaken;
    int enemy3TurnsTaken;
    int enemy4TurnsTaken;

    //Get lists from LoadMission and add the players to the attack pool
    public void SendLists(List<Beast> thisSquad, List<Beast> enemySquad)
    {
        players = thisSquad;
        enemies = enemySquad;
        attackPool.Add(players[0]);
        attackPool.Add(players[1]);
        attackPool.Add(players[2]);
        attackPool.Add(players[3]);
        healthManager.GetHealth(players, enemies);
        LoadOrder();
    }

    //Get the slot info for each beast from LoadMission
    public void GetSlots(Beast s1, Beast s2, Beast s3, Beast s4, Beast s5, Beast s6, Beast e1, Beast e2, Beast e3, Beast e4, Beast e5, Beast e6) 
    {
        slot1 = s1;
        slot2 = s2;
        slot3 = s3;
        slot4 = s4;
        slot5 = s5;
        slot6 = s6;
        enemySlot1 = e1;
        enemySlot2 = e2;
        enemySlot3 = e3;
        enemySlot4 = e4;
        enemySlot5 = e5;
        enemySlot6 = e6;
    }

    //Create attack order
    void LoadOrder()
    {
        int moves1 = 0;
        int moves2 = 0;
        int moves3 = 0;
        int moves4 = 0;
        int moves5 = 0;
        int moves6 = 0;
        int moves7 = 0;
        int moves8 = 0;

        //Get each players moves per round
        if(player1Active) moves1 = players[0].MOVES1;
        if(player2Active) moves2 = players[1].MOVES1;
        if(player3Active) moves3 = players[2].MOVES1;
        if(player4Active) moves4 = players[3].MOVES1;
        if(enemy1Active) moves5 = enemies[0].MOVES1;
        if(enemy2Active) moves6 = enemies[1].MOVES1;
        if(enemy3Active) moves7 = enemies[2].MOVES1;
        if(enemy4Active) moves8 = enemies[3].MOVES1;

        totalMoves = moves1 + moves2 + moves3 + moves4 + moves5 + moves6 + moves7 + moves8;

        //Get each player's speed
        int speed1 = players[0].Speed;
        int speed2 = players[1].Speed;
        int speed3 = players[2].Speed;
        int speed4 = players[3].Speed;
        int speed5 = enemies[0].Speed;
        int speed6 = enemies[1].Speed;
        int speed7 = enemies[2].Speed;
        int speed8 = enemies[3].Speed;

        int i = 0;

        List<string> wave = new List<string>();

        //Create an array woth each speed and sort it highest to lowest
        int[] speeds = { speed1, speed2, speed3, speed4, speed5, speed6, speed7, speed8 };
        System.Array.Sort(speeds);
        System.Array.Reverse(speeds);

        //Clear the previous round order
        roundOrder.Clear();
        roundOrderTypes.Clear();

        //Loop through the speed array and find the corresponding beast and add them to the round order
        while (i < totalMoves)
        {
            for (int x = 0; x < 8; x++)
            {
                if (player1Active && speeds[x] == speed1 && moves1 > 0 && !InWave("Player " + players[0], wave))
                {
                    roundOrder.Add(players[0]);
                    roundOrderTypes.Add("Player");
                    wave.Add("Player " + players[0]);
                    moves1--;
                    i++;
                }
                else if (player2Active && speeds[x] == speed2 && moves2 > 0 && !InWave("Player " + players[1], wave))
                {
                    roundOrder.Add(players[1]);
                    roundOrderTypes.Add("Player");
                    wave.Add("Player " + players[1]);
                    moves2--;
                    i++;
                }
                else if (player3Active && speeds[x] == speed3 && moves3 > 0 && !InWave("Player " + players[2], wave))
                {
                    roundOrder.Add(players[2]);
                    roundOrderTypes.Add("Player");
                    wave.Add("Player " + players[2]);
                    moves3--;
                    i++;
                }
                else if (player4Active && speeds[x] == speed4 && moves4 > 0 && !InWave("Player " + players[3], wave))
                {
                    roundOrder.Add(players[3]);
                    roundOrderTypes.Add("Player");
                    wave.Add("Player " + players[3]);
                    moves4--;
                    i++;
                }
                else if (enemy1Active && speeds[x] == speed5 && moves5 > 0 && !InWave("Enemy " + enemies[0], wave))
                {
                    roundOrder.Add(enemies[0]);
                    roundOrderTypes.Add("Enemy");
                    wave.Add("Enemy " + enemies[0]);
                    moves5--;
                    i++;
                }
                else if (enemy2Active && speeds[x] == speed6 && moves6 > 0 && !InWave("Enemy " + enemies[1], wave))
                {
                    roundOrder.Add(enemies[1]);
                    roundOrderTypes.Add("Enemy");
                    wave.Add("Enemy " + enemies[1]);
                    moves6--;
                    i++;
                }
                else if (enemy3Active && speeds[x] == speed7 && moves7 > 0 && !InWave("Enemy " + enemies[2], wave))
                {
                    roundOrder.Add(enemies[2]);
                    roundOrderTypes.Add("Enemy");
                    wave.Add("Enemy " + enemies[2]);
                    moves7--;
                    i++;
                }
                else if (enemy4Active && speeds[x] == speed8 && moves8 > 0 && !InWave("Enemy " + enemies[3], wave))
                {
                    roundOrder.Add(enemies[3]);
                    roundOrderTypes.Add("Enemy");
                    wave.Add("Enemy " + enemies[3]);
                    moves8--;
                    i++;
                }
            }
            wave.Clear();
        }

        currentTurn = roundOrder[turn];
        txtTurn.text = roundOrderTypes[0] + " " + currentTurn + "'s turn";
    }

    //Check to see of beast is used in the loop yet
    bool InWave(string beast, List<string> wave)
    {
        for(int i = 0; i < wave.Count; i++)
        {
            if(beast == wave[i])
            {
                return true;
            }
        }
        return false;
    }

    void TakeTurn()
    {
        turn++;
        currentTurn = roundOrder[turn];
        txtTurn.text = roundOrderTypes[turn] + " " + currentTurn + " 's turn";

        //If it is enemy turn, start their attack
        if(roundOrderTypes[turn] == "Enemy")
        {
            StartCoroutine(EnemyAttack());
        }
    }

    public void Attack(Beast target)
    {
        //Check to see if the round is still going and then run an attack
        if (turn == totalMoves - 1)
        {
            attack.InitiateAttack(currentTurn, target, GetRow(), roundOrderTypes[turn]);
            Debug.Log("Round Ended");
            ClearTurns();
            currentTurn = roundOrder[0];
            txtTurn.text = roundOrderTypes[0] + " " + currentTurn + "'s turn";
            turn = 0;
        }
        else
        {
            attack.InitiateAttack(currentTurn, target, GetRow(), roundOrderTypes[turn]);
            AddTurn();
            TakeTurn();
        }
    }

    IEnumerator EnemyAttack()
    {
        yield return new WaitForSeconds(1f);
        Attack(GetEnemyTarget());
    }

    //Enemy targets a random player from a pool of active player beasts
    Beast GetEnemyTarget()
    {
        int rand = Random.Range(0, attackPool.Count);
        return attackPool[rand];
    }

    //Get the row to determine whether the attacker is using an A move or a B move
    string GetRow()
    {
        if (currentTurn == slot1 || currentTurn == slot3 || currentTurn == slot5
        || currentTurn == enemySlot2 || currentTurn == enemySlot4 || currentTurn == enemySlot6)
        {
            return "B";
        }
        else
        {
            return "A";
        }
    }

    //Remove the desired beast by setting its active variable to false and removing image
    public void RemoveBeast(string beastID)
    {
        totalBeasts -= 1;
        if(beastID == "player1")
        {
            player1Active = false;
            attackPool.Remove(players[0]);
            loadMission.RemoveImage(players[0], "Player");
            turn -= player1TurnsTaken;
        }
        else if(beastID == "player2")
        {
            player2Active = false;
            attackPool.Remove(players[1]);
            loadMission.RemoveImage(players[1], "Player");
            turn -= player2TurnsTaken;
        }
        else if (beastID == "player3")
        {
            player3Active = false;
            attackPool.Remove(players[2]);
            loadMission.RemoveImage(players[2], "Player");
            turn -= player3TurnsTaken;
        }
        else if (beastID == "player4")
        {
            player4Active = false;
            attackPool.Remove(players[3]);
            loadMission.RemoveImage(players[3], "Player");
            turn -= player4TurnsTaken;
        }
        else if (beastID == "enemy1")
        {
            enemy1Active = false;
            loadMission.RemoveImage(enemies[0], "Enemy");
            turn -= enemy1TurnsTaken;
        }
        else if (beastID == "enemy2")
        {
            enemy2Active = false;
            loadMission.RemoveImage(enemies[1], "Enemy");
            turn -= enemy2TurnsTaken;
        }
        else if (beastID == "enemy3")
        {
            enemy3Active = false;
            loadMission.RemoveImage(enemies[2], "Enemy");
            turn -= enemy3TurnsTaken;
        }
        else if (beastID == "enemy4")
        {
            enemy4Active = false;
            loadMission.RemoveImage(enemies[3], "Enemy");
            turn -= enemy4TurnsTaken;
        }

        LoadOrder(); //Re Create the round order
    }

    //Add turn to keep track of how many times a beast has went in the round
    //Used to keep track of how much the turn variable has to be edited by when a beast gets knocked out
    void AddTurn()
    {
        if(roundOrderTypes[turn] == "Player")
        {
            if (currentTurn == players[0]) player1TurnsTaken += 1;
            else if (currentTurn == players[1]) player2TurnsTaken += 1;
            else if (currentTurn == players[2]) player3TurnsTaken += 1;
            else if (currentTurn == players[3]) player4TurnsTaken += 1;
        }
        else
        {
            if (currentTurn == enemies[0]) enemy1TurnsTaken += 1;
            else if (currentTurn == enemies[1]) enemy2TurnsTaken += 1;
            else if (currentTurn == enemies[2]) enemy3TurnsTaken += 1;
            else if (currentTurn == enemies[3]) enemy4TurnsTaken += 1;
        }
    }

    void ClearTurns()
    {
        player1TurnsTaken = 0;
        player2TurnsTaken = 0;
        player3TurnsTaken = 0;
        player4TurnsTaken = 0;
        enemy1TurnsTaken = 0;
        enemy2TurnsTaken = 0;
        enemy3TurnsTaken = 0;
        enemy4TurnsTaken = 0;
    }
}
