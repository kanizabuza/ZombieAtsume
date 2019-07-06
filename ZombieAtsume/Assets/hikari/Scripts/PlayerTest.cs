using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTest : MonoBehaviour
{
    private bool isControl;
    private int zombieHP = 100;

    private GameObject hpUI;
    private Slider hpSlider;

    private void Start() {
        hpSlider = hpUI.transform.Find("Slider").GetComponent<Slider>();
    }

    void Update() {

    }

    public void ChangeControl(bool flag) {
        isControl = flag;
        this.GetComponent<MeshRenderer>().enabled = flag;
    }
}
