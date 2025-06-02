using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttacking : MonoBehaviour
{
    //PlayerHealthREf
    public playerHealth playerHealth;
    //EnemyDamage 
    [SerializeField]
    float damage = 20f;
    //EnemyAttackCoolDown
    [SerializeField]
    float attackCoolDown = 1f;
    //NexTime Enemy can attack 
    [SerializeField]
    float nextAttackTime = 5f;




    //if Enemy collides with a gameobject that has playerTag it will call PLayerhealths takedamage method and pass through damage 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Checks if enough time has passed since enemy has attacked
            if (Time.time > nextAttackTime)
            {
                playerHealth.TakeDamage(damage);
                //sets time for next attack 
                nextAttackTime = Time.time + attackCoolDown;
            }





        }
    }

}
