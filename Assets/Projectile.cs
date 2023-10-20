using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemies"))
        {
            if(other.GetComponent<Enemy>().ChangeHealth(-40))
            {
                Destroy(gameObject);
                return;
            }
        }
        StartCoroutine(SetTimerDestruction());
    }
    
    private IEnumerator SetTimerDestruction()
    {
        yield return new WaitForSeconds(4);
        Destroy(gameObject);
    }
}
