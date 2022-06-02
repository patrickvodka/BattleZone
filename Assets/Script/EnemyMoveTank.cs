using System;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class EnemyMoveTank : MonoBehaviour
{
    public float speed;
    private Transform player;
    private NavMeshAgent Agent;
    //<>

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Agent.destination= player.position;
        
    }
    
}