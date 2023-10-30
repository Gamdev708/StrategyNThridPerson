using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy enemy;
    [SerializeField] Transform startPoint;
    [SerializeField] float deadline = 20;
    [SerializeField] float NumberOfEnemies = 20;
    // Update is called once per frame
    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    void Update()
    {
        deadline -= Time.deltaTime;
        if (deadline <= 0) { return; }
    }

    private IEnumerator StartSpawn()
    {
        for (int i = 0; i < NumberOfEnemies; i++)
        {
            yield return new WaitForSeconds(3);
            yield return Instantiate(enemy, startPoint.position, Quaternion.identity);
            //yield return new WaitForSeconds(5);
        }
        yield break;
        //yield return new WaitForSeconds(5);
    }

    public bool IsDeadlineReached()
    {
        return deadline <= 0;
    }
}
