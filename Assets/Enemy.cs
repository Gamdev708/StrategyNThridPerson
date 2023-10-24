using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] Transform Destination;
    NavMeshAgent agent;
    int health = 100;

    // Start is called before the first frame update
    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Destination = GameObject.FindGameObjectWithTag("EndGoal").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Destination!=null)
        {
            agent.SetDestination(Destination.position); 
        }
    }


    public bool IsDead()
    {
        return health < 0;
    }

    public bool ChangeHealth(int health)
    {
        if(health < 0) { return false; }
        this.health += health;
        return true;
    }
}
