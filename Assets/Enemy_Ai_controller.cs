using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Ai_controller : MonoBehaviour
{
    public Transform target;
    private NavMeshAgent agent;
    private void Start()
    {
        agent=transform.GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        agent.SetDestination(target.position);
        
    }
}
