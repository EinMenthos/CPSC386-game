using UnityEngine;

public class Bar : MonoBehaviour
{
    public Rigidbody2D rigidbody {get; private set; }
    public float maxBounceAngle = 75f;


    //professor helped me doing it
    void OnCollisionEnter2D(Collision2D collision)
{
    //video used as a reference: https://www.youtube.com/watch?v=RYG8UExRkhA
        BouncingBall ball = collision.gameObject.GetComponent<BouncingBall>();
        if (ball != null){
            //calculate offset based on the position of the bar and the point wher the ball hits the bar
            Vector3 paddlePosition = this.transform.position;           //bar position is centered
            Vector2 contactPoint = collision.GetContact(0).point;       //where the ball hits the bar
            float offset = paddlePosition.x - contactPoint.x;           //now we know how far is it from the center
            float width = collision.otherCollider.bounds.size.x / 2;    //only need half of bar width
            //calculation angle and rotation
            float currentAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAngle = (offset / width) * this.maxBounceAngle;
            float newAngle = Mathf.Clamp(currentAngle + bounceAngle, -this.maxBounceAngle, this.maxBounceAngle);
            
            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;
        }

}
}
