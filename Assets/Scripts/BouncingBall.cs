using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    EnemyManager em;
    //public new Rigidbody2D rigidbody {get; private set; }
    //public float speed = 500f;

    // Start is called before the first frame update
    
    private void Awake(){
        //this.rigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        //em = FindObjectOfType<EnemyManager>();
        //Invoke(nameof(SetRandomTrajectory), 1f);
    }

/*
private void SetRandomTrajectory(){
    Vector2 force = Vector2.zero;
    force.x = Random.Range(-1f, 1f);
    force.y = -1f;

    //this.rigidbody.AddForce(force.normalized * this.speed);
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
*/
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger-Enemy");
        if(collider.CompareTag("Enemy")){
            //HandleEnemy(collider.gameObject);
        }
            

        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision-Enemy");
        if(collision.collider.CompareTag("Enemy")){
            Debug.Log("Collision-Enemy");
            //HandleEnemy(collision.otherCollider.gameObject);  // not right to do it
            //HandleEnemy(collision.collider.gameObject);
        }
        else if(collision.collider.CompareTag("Player")){
            Debug.Log("Collision-player");
            /*
            BouncingBall ball = collision.gameObject.GetComponent<BouncingBall>();

            //calculate offset based on the position of the bar and the point wher the ball hits the bar
            Vector3 paddlePosition = this.transform.position;           //bar position is centered
            Vector2 contactPoint = collision.GetContact(0).point;       //where the ball hits the bar
            float offset = paddlePosition.x - contactPoint.x;           //now we know how far is it from the center
            float width = collision.otherCollider.bounds.size.x / 2;    //only need half of bar width
            //calculation angle and rotation
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.rigidbody.velocity);
            //float bounceAngle = (offset / width) * this.maxBounceAngle;
            //float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
            */

        }
        //    Debug.Log("Collision with something else");

        //Requires both objects have rigidbody2d and collider, with maximum 1 kinematic rigidbody
    }
    
}
