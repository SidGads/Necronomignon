using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : MonoBehaviour
{
    

    //Changes the status of the desired beast and set rating to 1
    public void SummonBeast(Beast beast)
    {
        beast.Summoned = true;
        beast.Skill = 1;
    }
}
