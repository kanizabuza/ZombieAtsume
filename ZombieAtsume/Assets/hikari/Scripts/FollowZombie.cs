using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowZombie : MonoBehaviour
{
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

}
