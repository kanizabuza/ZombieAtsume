using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Call()
    {
        StartCoroutine("AttackCall");
    }

        private IEnumerator AttackCall()
    {
        anim.SetBool("Attack", true);
        yield return new WaitForSeconds(5.0f);
        anim.SetBool("Attack",false);
        anim.SetBool("Idle", true);
        yield return new WaitForSeconds(5.0f);
        anim.SetBool("Idle", false);

    }
}

