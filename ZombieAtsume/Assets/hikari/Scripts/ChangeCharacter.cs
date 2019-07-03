using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    private int nowPlayer;

    [SerializeField]
    private List<GameObject> charaLists;

    void Start() {
        nowPlayer = charaLists.Count;
        ChangePlayer(nowPlayer);
    }

    void Update() {
        if (Input.GetKeyDown("q")){
            ChangePlayer(nowPlayer);
        }
    }

    void ChangePlayer(int tempNowPlayer) {
        bool flag;
        int nextPlayer = tempNowPlayer + 1;

        //循環処理
        if (nextPlayer >= charaLists.Count)
        {
            nextPlayer = 0;
        }

        for(int i=0; i<charaLists.Count; i++)
        {
            if(i == nextPlayer)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }

            //変換処理
            charaLists[i].GetComponent<PlayerTest>().ChangeControl(flag);
        }
        nowPlayer = nextPlayer;
    }
}
