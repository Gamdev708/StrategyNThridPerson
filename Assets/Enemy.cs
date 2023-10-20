using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{

    [SerializeField] Vector3 Destination;
    NavMeshAgent agent;
    int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Destination);
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
