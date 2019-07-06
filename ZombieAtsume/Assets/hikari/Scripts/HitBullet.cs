using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBullet : MonoBehaviour
{
    private PlayerTest pTest;
    private ChangeCharacter cChara;
    private bool isPlayer = false;

    private void Start() {
        cChara = GameObject.Find("ChangePlayer").GetComponent<ChangeCharacter>();
        pTest = GetComponentInChildren<PlayerTest>();
    }

    private void OnTriggerEnter(Collider other) {
        //isPlayer = 
        //プレイヤかどうか確認
        if (other.tag == "Bullet")
        {
            pTest.TakeDamage(100);
        }
    }
}
