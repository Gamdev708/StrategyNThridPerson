using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class GameManager : MonoBehaviour
{
    List<GameObject> targets;
    [SerializeField] EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2;
    }

    // Update is called once per frame
    void Update()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy").ToList();
        if (targets != null)
        {
            if (targets.Count == 0 && enemySpawner.IsDeadlineReached())
            {
                Debug.Log("Game Win");
            }
        }
    }
}
