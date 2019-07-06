using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerTest : MonoBehaviour
{

    private int zombieHP = 100;

    private GameObject hpUI;
    private Slider hpSlider;

    private void Start() {
        hpSlider = GetComponentInChildren<Slider>();
    }

    void LateUpdate() {
        transform.rotation = Camera.main.transform.rotation;
    }


}
