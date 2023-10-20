using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Structure : MonoBehaviour
{
    int Health;
    int MaxHealth = 100;

    [SerializeField] bool CanAttack;

    [SerializeField] float attackRange;
    [SerializeField] Projectile Projectile;
    [SerializeField] UnityEvent OnDestroy;

    List<GameObject> targets;
    GameObject target;

    private void OnEnable()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        targets=GameObject.FindGameObjectsWithTag("Enemy").ToList();
        if (targets!=null)
        {
            target = targets.Where(x => x.transform.position.sqrMagnitude <= attackRange & !x.GetComponent<Enemy>().IsDead()).First(); 
        }

        if (Health <= 0)
        {
            OnDestroy.Invoke();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
