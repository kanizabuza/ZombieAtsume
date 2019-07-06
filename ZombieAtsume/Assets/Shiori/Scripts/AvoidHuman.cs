using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidHuman : MonoBehaviour
{
    private ChangeCharacter cChara;
    private Transform looktarget;
    public bool isDetectPlayer;
    public float moveSpeed = 0.1f;
    public float rotateSpeed = 0.001f;
    private bool isMovement, isRotation;
    float avoidtime = 0f;
    private Players playersc;
    private Vector3 angle;
    private Animator anim;
    private Transform objtrans;
    public GameObject obj = null;
    private int moveflag = 1;
    private GameObject soundSource;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        isMovement = false;
        isRotation = false;

        playersc = GameObject.FindGameObjectWithTag("Player").GetComponent<Players>();
        soundSource = GameObject.Find("SoundSource");
        cChara = GameObject.Find("ChangePlayer").GetComponent<ChangeCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveflag == 1)
        {
            if (isDetectPlayer)
            {
                isMovement = true;
                isRotation = true;


                avoidtime += Time.deltaTime;

                if (avoidtime < 5f)
                {

                    //  Vector3 forward = new Vector3(transform.forward.x, -0.1f, transform.forward.z);
                    anim.SetBool("Run", true);
                    moveSpeed = 3f;
                    transform.position += transform.forward * moveSpeed * 0.01f;


                }

                else
                {

                    avoidtime = 0;
                    //  isDetectPlayer = false;

                    anim.SetBool("Run", false);
                    moveSpeed = 0.1f;
                    transform.position += transform.forward * moveSpeed * 0.01f;
                    isDetectPlayer = false;
                    looktarget = null;

                }
            }
            if (isRotation && looktarget != null)
            {
                Vector3 angle = -looktarget.position + transform.position;
                //    angle.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(angle), rotateSpeed);
            }

            else
            {
                anim.SetBool("Run", false);
            }
        }
        else
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            isDetectPlayer = true;
            looktarget = other.transform;
        }

        if (other.tag == "attack")
        {
           // Debug.Log("1");
            int flag = playersc.Burn();
            Debug.Log(flag + "avoid");
            if (flag == 1)
            {
                Anim();
            }
        }
    }

    public void Anim()
    {
        soundSource.GetComponent<humanSound>().soundPlay();
        anim.SetBool("Down", true);
        objtrans = this.gameObject.transform;
        Destroy(this.gameObject, 3);
        moveflag = 0;
        StartCoroutine(Make(obj, objtrans.transform));
        //Instantiate(obj, objtrans.transform.position, Quaternion.identity);
    }

   IEnumerator Make(GameObject obj,Transform trans)
    {
      //  Debug.Log("ok");
        yield return new WaitForSeconds(2.5f);
       // Debug.Log("ok!!");
        GameObject clone = Instantiate(obj, trans.position, Quaternion.identity);
        clone.GetComponent<Players>().enabled = false;
        clone.tag = "Zombie";
        clone.transform.GetChild(18).gameObject.GetComponent<Canvas>().enabled = false;
        clone.GetComponent<HitBullet>().enabled = false;
        cChara.AddList(clone);
    }



}
