using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] bool isHoming = true;
    [SerializeField] GameObject hitEffect = null;
    [SerializeField] float maxLifeTime = 10;
    [SerializeField] GameObject[] destroyOnHit = null;
    [SerializeField] float lifeAfterImpact = 2;
    [SerializeField] UnityEvent onHit;

    Enemy target;



    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(GetAimLocation());
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        if (isHoming && !target.IsDead())
        {
            transform.LookAt(GetAimLocation());
        }
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (enemy.ChangeHealth(-40))
                {
                    Destroy(gameObject);
                    return; 
                }
            }
        }
        StartCoroutine(SetTimerDestruction());
    }

    private Vector3 GetAimLocation()
    {
        CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
        if (targetCapsule == null)
        {
            return target.transform.position;
        }
        return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }
    private IEnumerator SetTimerDestruction()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }

    public void SetTarget(Enemy target)
    {
        this.target = target;
    }
}
