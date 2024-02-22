using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    EnemyManager em;

    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<EnemyManager>();
    }

void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {
        if(em && em.usePooling){
            em.pool.pool.Release(other);
            Debug.Log("releasing...");
        }
            
        else{
            Destroy(other);
            Debug.Log("destroying...");
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger-Enemy");
        if(collider.tag == "Enemy")
            HandleEnemy(collider.gameObject);

        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision-Enemy");
        if(collision.collider.tag == "Enemy"){
            Debug.Log("Collision-Enemy");
            //HandleEnemy(collision.otherCollider.gameObject);
            HandleEnemy(collision.collider.gameObject);
        }
        else if(collision.collider.tag == "Player"){
            Debug.Log("Collision-player");
            //collision. -> used to interact with the object2 that collided with 1.
            //transform. -> used to interact with the object1 itself
        }
        //    Debug.Log("Collision with something else");

        //Requires both objects have rigidbody2d and collider, with maximum 1 kinematic rigidbody
    }
    
}
