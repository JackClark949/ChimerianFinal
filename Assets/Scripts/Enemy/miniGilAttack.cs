using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class miniGilAttack : MonoBehaviour
{
    //Damage
    [SerializeField]
    float damage = 20f;
    //AttackCoolDowns
    [SerializeField]
    float attackCoolDown = 1f;
    [SerializeField]
    float nextAttackTime = 5f;

    private void OnCollisionEnter(Collision collision)
    {
        //If enemy collides with gameobject with player tag
        //it will grab its health script 
        //And if enemy can attack it will call players takedamage method 
        if (collision.gameObject.tag == "Player")
        {
            playerHealth playerTarget = collision.gameObject.GetComponent<playerHealth>();
            //Checks if enough time has passed since enemy has attacked
            if (Time.time > nextAttackTime)
            {
                
                nextAttackTime = Time.time + attackCoolDown;
                playerTarget.TakeDamage(damage);





            }













        }
    }

}
