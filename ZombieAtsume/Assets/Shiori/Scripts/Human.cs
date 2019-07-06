using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    public Transform looktarget;
    public bool isDetectPlayer;
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 0.001f;
    private bool isMovement, isRotation;
    float avoidtime = 0f;
    public Players playersc;
    private Vector3 angle;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isMovement = false;
        isRotation = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (isDetectPlayer)
        {
            isMovement = true;
            isRotation = true;


            avoidtime += Time.deltaTime;

            if (avoidtime < 5f)
            {

                //  Vector3 forward = new Vector3(transform.forward.x, -0.1f, transform.forward.z);
                //anim.SetBool("Run", true);
                moveSpeed = 3f;
                transform.position += transform.forward * moveSpeed * 0.01f;


            }

            else
            {

                avoidtime = 0;
                //  isDetectPlayer = false;

                //anim.SetBool("Run", false);
                moveSpeed = 0.1f;
                transform.position += transform.forward * moveSpeed * 0.01f;
                isDetectPlayer = false;

            }
        }
        if (isRotation && looktarget != null)
        {
            Vector3 angle = looktarget.position - transform.position;
            //    angle.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(angle), rotateSpeed);
        }

        else
        {
           // anim.SetBool("Run", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isDetectPlayer = true;
            looktarget = other.transform;
        }

        if (other.tag == "attack")
        {
            Debug.Log("1");


            playersc.Burn();
        }
    }



}
