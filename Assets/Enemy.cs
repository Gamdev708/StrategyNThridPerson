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
    FortHealth fort;

    // Start is called before the first frame update
    void Awake()
    {
        
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        Destination = GameObject.FindGameObjectWithTag("EndGoal").transform;
        fort = GameObject.FindGameObjectWithTag("EndGoal").GetComponent<FortHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.health <= 0)
        {
            agent.enabled = false;
            Destroy(gameObject);
        }
       else if (Destination!=null && !IsDead())
        {
            agent.SetDestination(Destination.position); 
            //if (agent.pathStatus == NavMeshPathStatus.PathComplete)
            //{
            //    Destroy(gameObject);
            //}
        }

       
    }


    public bool IsDead()
    {
        return health < 0;
    }

    public bool ChangeHealth(int health)
    {
        if(this.health < 0) { return false; }
        this.health += health;
        return true;
    }
}
