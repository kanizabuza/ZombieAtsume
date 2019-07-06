using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class PlayerTest : MonoBehaviour
{
    public ChangeCharacter cChara;
    private Image fillImg;
    private Color fullHpColor = Color.green;
    private Color zeroHpColor = Color.red;
    private int zombieHp;
    private int maxHp = 100;

    private GameObject hpUI;
    private Slider hpSlider;

    private void Start() {
        zombieHp = maxHp;
        cChara = GameObject.Find("ChangePlayer").GetComponent<ChangeCharacter>();
        hpSlider = GetComponentInChildren<Slider>();
        fillImg = hpSlider.image;
    }

    void LateUpdate() {
        transform.rotation = Camera.main.transform.rotation;
    }

    public void TakeDamage(int damage) {
        zombieHp -= damage;

        SetHpUI();

        if(zombieHp <= 0f)
        {
            cChara.RemovePlayerZombie();
        }
    }

    private void SetHpUI() {
        hpSlider.value = zombieHp;
        //fillImg.color = Color.Lerp(zeroHpColor, fullHpColor, zombieHp / maxHp);
    }
    /*
    private void OnDeath() {
        int num = cChara.GetPlayerNumber();
        Destroy(this.gameObject.transform.root.gameObject);
        cChara.RemoveZombie(num);
    }*/
}
