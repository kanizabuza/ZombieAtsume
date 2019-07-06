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
        /*
        if (Input.GetKeyDown(KeyCode.Space)){
            ChangePlayer(nowPlayer);
        }*/
        if (charaLists.Count == 0)
        {
            Debug.Log("te");
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
                charaLists[i].tag = "Player";
            }
            else
            {
                flag = false;
                charaLists[i].tag = "Zombie";
            }

            //変換処理
            charaLists[i].GetComponent<FollowZombie>().ChangeControl(flag);
            charaLists[i].GetComponent<Animator>().SetBool("Walk",!flag);
            charaLists[i].GetComponent<HitBullet>().enabled = flag;
        }

        nowPlayer = nextPlayer;
    }

    public void RemovePlayerZombie() {
        int tempPlayer = nowPlayer;

        ChangePlayer(nowPlayer);
        Destroy(charaLists[tempPlayer]);
        charaLists.RemoveAt(tempPlayer);
    }

    public int GetPlayerNumber() {
        return nowPlayer;
    }

    public void AddList(GameObject obj) {
        charaLists.Add(obj);
    }
}
