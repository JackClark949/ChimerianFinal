using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttacking : MonoBehaviour
{
    //PlayerHealth Ref to call take damage method
    public playerHealth playerHealth;
    [SerializeField]
    float damage = 20f;

    [SerializeField]
    float attackCoolDown = 1f;
    [SerializeField]
    float nextAttackTime = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackCoolDown;
                playerHealth.TakeDamage(damage);

            }

        }
    }

}
