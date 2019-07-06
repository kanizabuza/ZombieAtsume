using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Players : MonoBehaviour
{
    // Start is called before the first frame update
    Plane plane = new Plane();
    float distance = 0;
    public float speed = 30f;
    float moveX = 0f;
    float moveZ = 0f;
    float time = 0;
    private GameObject obj = null;
    private Transform desobject;
    //public GameObject Zombie;
    int attackflag = 0;
    public int destroyflag = 0;
    int burnflag = 0;
    Rigidbody rb;
    private Animator anim;
    //public AvoidHuman avoidhuman;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
      
        
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (plane.Raycast(ray, out distance))
        {
            var lookPoint = ray.GetPoint(distance);
            transform.LookAt(lookPoint);

        }
        moveX = Input.GetAxis("Horizontal") * speed;
        moveZ = Input.GetAxis("Vertical") * speed ;
        Vector3 direction = new Vector3(moveX*10f, 0, moveZ*10f);
        time += Time.deltaTime;
        if (attackflag == 1)
        {
           // Debug.Log(time + "time");
            if (time < 2.5f)
            {
                burnflag = 1;

            }
            else
            {


                burnflag = 0;
                attackflag = 0;
                time = 0;
            }
        }
        if (moveX != 0 || moveZ != 0)
        {

            anim.SetBool("Walk", true);
        }

        else
        {
            anim.SetBool("Walk", false);
        }
        if (Input.GetMouseButtonDown(0))
        {
            attackflag = 1;
            anim.SetTrigger("Attack");
        }

        rb.AddForce(moveX*5f, 0f,moveZ*5f);

    }
    private void OnTriggerEnter(Collider other)
    {
        obj = other.gameObject;
    }
    public int Burn()
    {

        /*
        if (burnflag == 1 && attackflag == 1)
        {
           

            avoidhuman.Anim();

        }*/
        int tempflag = burnflag;
        burnflag = 0;
        attackflag = 0;
        return tempflag;

    }
    private void FixedUpdate()
    {
         
    }
}
