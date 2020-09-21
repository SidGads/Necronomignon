using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTeam : MonoBehaviour
{
    Animator anim;
    GameObject slot1;

    // Start is called before the first frame update
    void Start()
    {
        slot1 = gameObject.transform.GetChild(0).gameObject;
        anim = slot1.GetComponent<Animator>();
        anim.runtimeAnimatorController = Resources.Load("Animations/Abyssal/Idle/Idle") as RuntimeAnimatorController;
        anim.speed = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/Abyssal/Damaged/Damaged") as RuntimeAnimatorController;
        }
        if (Input.GetKeyDown("w"))
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/Abyssal/AttackA/Attack") as RuntimeAnimatorController;
        }
        if (Input.GetKeyDown("e"))
        {
            anim.runtimeAnimatorController = Resources.Load("Animations/Abyssal/AttackB/Attack") as RuntimeAnimatorController;
        }
    }
}
