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
    [SerializeField] float attackRate;
    [SerializeField] Projectile Projectile;
    [SerializeField] GameObject ShooterPlace;
    [SerializeField] UnityEvent OnDestroy;

    List<GameObject> targets;
    Enemy target;

    private bool isShooting = false;
    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (Health <= 0)
        {
            OnDestroy.Invoke();
            return;
        }
        targets =GameObject.FindGameObjectsWithTag("Enemy").ToList();
        if (targets!=null)
        {
            try
            {
                target = targets.Where(x => Vector3.Distance(transform.position, x.transform.position) <= attackRange & !x.GetComponent<Enemy>().IsDead()).First().GetComponent<Enemy>();
            }
            catch (System.Exception)
            {
            }

            if (target != null && !isShooting) // Check if not already shooting
            {
                StartCoroutine(Shoot());
            }
        }

    }

    private IEnumerator Shoot()
    {
        isShooting = true; // Set to true while shooting
        while (target != null)
        {
            Projectile projectile = Instantiate(Projectile, ShooterPlace.transform.position, Quaternion.identity);
            projectile.SetTarget(target);

            yield return new WaitForSeconds(attackRate);
        }

        isShooting = false; // Set to false when shooting is done
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
