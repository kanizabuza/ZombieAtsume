using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowZombie : MonoBehaviour
{
    private bool isControl;
    GameObject target;
    NavMeshAgent agent;

    [SerializeField]
    private float arrivedDistance = 3f;

    [SerializeField]
    private float followDistance = 4f;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
        target = GameObject.FindGameObjectWithTag("Player");
        agent.SetDestination(target.transform.position);
        if(agent.remainingDistance < arrivedDistance)
        {
            agent.isStopped = true;
        }else if (agent.remainingDistance > followDistance)
        {
            agent.isStopped = false;
        }

    }

    public void ChangeControl(bool flag) {
        isControl = flag;

        this.transform.GetChild(18).gameObject.GetComponent<Canvas>().enabled = flag;

        this.GetComponent<Players>().enabled = flag;
        if (flag)
        {
            //this.GetComponent<ZombieAnim>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<FollowZombie>().enabled = false;
        }
        else
        {
            //this.GetComponent<ZombieAnim>().enabled = true;
            this.GetComponent<NavMeshAgent>().enabled = true;
            this.GetComponent<FollowZombie>().enabled = true;
        }
    }

}
