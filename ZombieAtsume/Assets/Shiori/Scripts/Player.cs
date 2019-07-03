using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Plane plane = new Plane();
    float distance = 0;
    public float speed = 3f;
    float moveX = 0f;
    float moveZ = 0f;
    float time = 0;

    int attackflag = 0;
    public int destroyflag = 0;
    int burnflag = 0;
    Rigidbody rb;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
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
        moveZ = Input.GetAxis("Vertical") * speed;
        Vector3 direction = new Vector3(moveX, 0, moveZ);
        time += Time.deltaTime;
        if(attackflag == 1)
        {
            if (time < 10f && destroyflag == 1)
            {
                burnflag = 1;

            }
            else
            {
                attackflag = 0;
                burnflag = 0;
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
    }


    public void Burn(Collider obj)
    {
        Debug.Log(burnflag);
        Debug.Log("10");
        Debug.Log(attackflag);

        if (burnflag == 1 && attackflag == 1)
        {
            Debug.Log("3");
            Destroy(obj);
        }
        destroyflag = 0;

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(moveX, 0, moveZ);
    }
}
