using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerTest : MonoBehaviour
{
    private bool isControl;
    private int zombieHP = 100;

    private GameObject hpUI;
    private Slider hpSlider;

    private void Start() {
        hpSlider = GetComponentInChildren<Slider>();
    }

    void Update() {

    }

    public void ChangeControl(bool flag) {
        isControl = flag;
        this.GetComponent<Animator>().enabled = flag;

        //navemeshagent add
        //players.enabled false
        this.GetComponent<Players>().enabled = flag;
        if (flag)
        {
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<FollowZombie>().enabled = false;
        }
        else
        {
            this.GetComponent<NavMeshAgent>().enabled = true;
            this.GetComponent<FollowZombie>().enabled = true;
        }
    }
}
