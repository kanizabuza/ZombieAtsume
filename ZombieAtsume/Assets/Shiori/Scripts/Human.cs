using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{


    public Player playersc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("2");
        if (other.tag == "attack")
        {
            Debug.Log("1");

          
            playersc.Burn();
        }
        
    }
}
