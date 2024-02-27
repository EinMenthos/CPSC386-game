using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    EnemyManager em;
    public Rigidbody2D rigidbodyB {get; private set; }
    public float speed = 6f;

    
    private void Awake(){
        rigidbodyB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update

    void Start()
    {
        em = FindObjectOfType<EnemyManager>();
        //Invoke(nameof(SetRandomTrajectory), 1f);
        //SetRandomTrajectory();
    }

    void Update()
    {
        rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
    }

private void SetRandomTrajectory(){
    Vector2 force = Vector2.up;
    force.x = Random.Range(-1f, 1f);
    //force.y = 1f; //always going up   //not needed because I declared to go up
    rigidbodyB.AddForce(force.normalized * speed,ForceMode2D.Impulse);
    rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
}

void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {
        if(em && em.usePooling){
            em.pool.pool.Release(other);
            Debug.Log("releasing...");      //releasing will put it on standby for further usage.
        }
        else{
            Destroy(other);
            Debug.Log("destroying...");     //destroy will simply remove it from memory (need to render it later if needed)
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger-Enemy");
        if(collider.CompareTag("Enemy")){
            HandleEnemy(collider.gameObject);
        }
            

        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy")){
            //Debug.Log("Collision-Enemy");
            //HandleEnemy(collision.otherCollider.gameObject);  // this it the bar
            HandleEnemy(collision.collider.gameObject);         //this is the ball
        }
        //Requires both objects have rigidbody2d and collider, with maximum 1 kinematic rigidbody
    }
    
}
