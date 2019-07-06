using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private float bulletPower = 500f;
    [SerializeField]
    private Transform bullet;

    public Transform looktarget;
    public bool isDetectPlayer;
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 0.001f;
    private bool isMovement, isRotation;
    private Attack attack;
    float maketime = 0f;
    float avoidtime = 0f;
    public Players playersc;
    private Vector3 angle;
    Animator anim;
    private int attackflag = 0;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isMovement = false;
        isRotation = false;
        attack = GetComponent<Attack>();

    }

    // Update is called once per frame
    void Update()
    {
        avoidtime += Time.deltaTime;
        maketime += Time.deltaTime;
        if (isDetectPlayer)
        {
            isMovement = true;
            isRotation = true;

            if(avoidtime < 0.8f)
            {
                Debug.Log(avoidtime);
                anim.SetBool("Idle", false);
                anim.SetBool("Attack", true);
               if (maketime >= 0.4f)
                {
                    maketime = 0;
                    Shot();
                }
         
             
            }
            else if(avoidtime >= 0.8f && avoidtime < 2.8f) 
            {
                anim.SetBool("Attack", false);
                anim.SetBool("Idle", true);
             
            }
            else
            {
                avoidtime = 0;
            }


      



            //  Vector3 forward = new Vector3(transform.forward.x, -0.1f, transform.forward.z);
            //anim.SetBool("Run", true);
            //moveSpeed = 3f;
            //transform.position += transform.forward * moveSpeed * 0.01f;
            anim.SetBool("Nothing", false);

        }



        else
        {
         
            anim.SetBool("Nothing", true);
            anim.SetBool("Attack", false);
            // avoidtime = 0;
            //  isDetectPlayer = false;

            //anim.SetBool("Run", false);
            moveSpeed = 0.1f;
            transform.position += transform.forward * moveSpeed * 0.01f;
        


        }
        if (isRotation && looktarget != null)
        {
            Vector3 angle = looktarget.position - transform.position;
            //    angle.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(angle), rotateSpeed);
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

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            isDetectPlayer = false;
            looktarget = null;
        }
    }

    void Shot()
    {
        var bulletInstance = GameObject.Instantiate(bulletPrefab, bullet.position, bullet.rotation) as GameObject;
        bulletInstance.GetComponent<Rigidbody>().AddForce(bulletInstance.transform.forward * bulletPower);
        Destroy(bulletInstance, 3f);
    }



}
