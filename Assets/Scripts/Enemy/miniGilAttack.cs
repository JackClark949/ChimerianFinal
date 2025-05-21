using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniGilAttack : MonoBehaviour
{
    
    [SerializeField]
    float damage = 20f;

    [SerializeField]
    float attackCoolDown = 1f;
    [SerializeField]
    float nextAttackTime = 5f;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerHealth playerTarget = collision.gameObject.GetComponent<playerHealth>();
            if (Time.time > nextAttackTime)
            {
                nextAttackTime = Time.time + attackCoolDown;
                playerTarget.TakeDamage(damage);





            }

        }
    }

}
