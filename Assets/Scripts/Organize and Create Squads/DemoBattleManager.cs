using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoBattleManager : MonoBehaviour
{
    public LoadDemoBattle loadDemoBattle;
    public SquadData squadData;
    public BeastDatabase beastDatabase;
    public Attack attack;
    public HealthManager healthManager;

    int squadNumber;

    public Image slot1Img;
    public Image slot2Img;
    public Image slot3Img;
    public Image slot4Img;
    public Image slot5Img;
    public Image slot6Img;

    public Beast slot1;
    public Beast slot2;
    public Beast slot3;
    public Beast slot4;
    public Beast slot5;
    public Beast slot6;

    public Image order1;
    public Image order2;
    public Image order3;
    public Image order4;
    public Image order5;
    public Image order6;
    public Image order7;
    public Image order8;
    public Image order9;

    List<Beast> thisSquad = new List<Beast>();
    List<Beast> roundOrder = new List<Beast>();
    List<Beast> enemies = new List<Beast>();

    int turn = 0;
    int totalMoves;

    Beast currentTurn;

    void Start()
    {
        enemies.Add(BeastManager.getFromNameS("Target"));
        enemies.Add(null);
        enemies.Add(null);
        enemies.Add(null);
        squadNumber = loadDemoBattle.GetSquadNumber();
        LoadSquadImages();
        LoadOrder();
        healthManager.GetHealth(thisSquad, enemies);
    }

    void LoadSquadImages()
    {
        List<Beast> toLoad = new List<Beast>();
        toLoad = squadData.GetSquadList(squadNumber);

        if (toLoad[0] != null)
        {
            slot1Img.sprite = Resources.Load<Sprite>(GetImage(toLoad[0].Static_image));
            slot1 = toLoad[0];
            thisSquad.Add(toLoad[0]);
        }
        else slot1Img.gameObject.SetActive(false);
        if (toLoad[1] != null)
        {
            slot2Img.sprite = Resources.Load<Sprite>(GetImage(toLoad[1].Static_image));
            slot2 = toLoad[1];
            thisSquad.Add(toLoad[1]);
        }
        else slot2Img.gameObject.SetActive(false);
        if (toLoad[2] != null)
        {
            slot3Img.sprite = Resources.Load<Sprite>(GetImage(toLoad[2].Static_image));
            slot3 = toLoad[2];
            thisSquad.Add(toLoad[2]);
        }
        else slot3Img.gameObject.SetActive(false);
        if (toLoad[3] != null)
        {
            slot4Img.sprite = Resources.Load<Sprite>(GetImage(toLoad[3].Static_image));
            slot4 = toLoad[3];
            thisSquad.Add(toLoad[3]);
        }
        else slot4Img.gameObject.SetActive(false);
        if (toLoad[4] != null)
        {
            slot5Img.sprite = Resources.Load<Sprite>(GetImage(toLoad[4].Static_image));
            slot5 = toLoad[4];
            thisSquad.Add(toLoad[4]);
        }
        else slot5Img.gameObject.SetActive(false);
        if (toLoad[5] != null)
        {
            slot6Img.sprite = Resources.Load<Sprite>(GetImage(toLoad[5].Static_image));
            slot6 = toLoad[5];
            thisSquad.Add(toLoad[5]);
        }
        else slot6Img.gameObject.SetActive(false);
    }

    string GetImage(string beast)
    {
        if (beast == "Gaia") return "Boss Nature Titan Tellia-4";
        else if (beast == "Cthulhu") return "Boss Cthulhu-3";
        else if (beast == "Trogdor") return "Boss Mythical Stag Kyris-3";
        else if (beast == "Behemoth") return "Boss Wolfbull Demon Goliath-4";
        else if (beast == "Naglfar") return "Dragons Hydra-3";
        else if (beast == "Sunbather") return "Boss Darklord Excelsios-1";
        else return "";
    }

    void LoadOrder()
    {
        int moves1 = thisSquad[0].MOVES1;
        int moves2 = thisSquad[1].MOVES1;
        int moves3 = thisSquad[2].MOVES1;
        int moves4 = thisSquad[3].MOVES1;
        totalMoves = moves1 + moves2 + moves3 + moves4;

        int speed1 = thisSquad[0].Speed;
        int speed2 = thisSquad[1].Speed;
        int speed3 = thisSquad[2].Speed;
        int speed4 = thisSquad[3].Speed;

        int i = 0;

        int[] speeds = { speed1, speed2, speed3, speed4 };
        System.Array.Sort(speeds);
        System.Array.Reverse(speeds);
        
        while(i < totalMoves)
        {
            for (int x = 0; x < 4; x++)
            {
                if (speeds[x] == speed1 && moves1 > 0)
                {
                    roundOrder.Add(thisSquad[0]);
                    moves1--;
                    i++;
                }
                else if (speeds[x] == speed2 && moves2 > 0)
                {
                    roundOrder.Add(thisSquad[1]);
                    moves2--;
                    i++;
                }
                else if (speeds[x] == speed3 && moves3 > 0)
                {
                    roundOrder.Add(thisSquad[2]);
                    moves3--;
                    i++;
                }
                else if (speeds[x] == speed4 && moves4 > 0)
                {
                    roundOrder.Add(thisSquad[3]);
                    moves4--;
                    i++;
                }
            }
        }
        UpdateOrderBar();
    }

    void UpdateOrderBar()
    {
        currentTurn = roundOrder[turn];
        try
        {
            order1.sprite = Resources.Load<Sprite>(roundOrder[0 + turn].Static_image);
        }
        catch
        {
            order1.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order2.sprite = Resources.Load<Sprite>(roundOrder[1 + turn].Static_image);
        }
        catch
        {
            order2.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order3.sprite = Resources.Load<Sprite>(roundOrder[2 + turn].Static_image);
        }
        catch
        {
            order3.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order4.sprite = Resources.Load<Sprite>(roundOrder[3 + turn].Static_image);
        }
        catch
        {
            order4.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order5.sprite = Resources.Load<Sprite>(roundOrder[4 + turn].Static_image);
        }
        catch
        {
            order5.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order6.sprite = Resources.Load<Sprite>(roundOrder[5 + turn].Static_image);
        }
        catch
        {
            order6.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order7.sprite = Resources.Load<Sprite>(roundOrder[6 + turn].Static_image);
        }
        catch
        {
            order7.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order8.sprite = Resources.Load<Sprite>(roundOrder[7 + turn].Static_image);
        }
        catch
        {
            order8.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
        try
        {
            order9.sprite = Resources.Load<Sprite>(roundOrder[8 + turn].Static_image);
        }
        catch
        {
            order9.sprite = Resources.Load<Sprite>("EmptyRectangle");
        }
    }

    public void TakeTurn()
    {
        if (turn == totalMoves - 1)
        {
            Debug.Log("Round Ended");
            turn = 0;
            UpdateOrderBar();
        }
        else
        {
            turn++;
            UpdateOrderBar();
            Debug.Log(currentTurn + "'s turn");
        }

    }

    //public void Attack()
    //{
    //    if (turn == totalMoves - 1)
    //    {
    //        attack.InitiateAttack(currentTurn, "Target", GetRow());
    //        Debug.Log("Round Ended");
    //        turn = 0;
    //        UpdateOrderBar();
    //    }
    //    else 
    //    {
    //        attack.InitiateAttack(currentTurn, "Target", GetRow());
    //        TakeTurn();
    //    }
    //}

    //string GetRow()
    //{
    //    if (currentTurn == slot1 || currentTurn == slot3 || currentTurn == slot5)
    //    {
    //        return "B";
    //    }
    //    else
    //    {
    //        return "A";
    //    }
    //}
}
