using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortHealth : MonoBehaviour
{
    int health = 100;
    [SerializeField] Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue= health;
        healthSlider.value= health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (other.TryGetComponent<Enemy>(out Enemy enemy))
            {
                if (ChangeHealth(-10))
                {
                    enemy.ChangeHealth(-100);
                    return;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (IsDead())
        {
            Debug.Log("Game Over");
        }
    }

    public bool ChangeHealth(int health)
    {
        if (this.health < 0) { return false; }
        this.health += health;
        healthSlider.value = this.health;
        return true;
    }

    public bool IsDead()
    {
        return health < 0;
    }
}
