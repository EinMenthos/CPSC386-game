using UnityEngine;
/// <summary>
/// Unity has an existing input system and a new one
/// They can not be used simultaneously. To use the new
/// input system, you must open the package manager window
/// then add "Input System" from the Unity Registry
/// </summary>
using UnityEngine.InputSystem;

public class InputExample : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D jumpingBody, movingBody;
    [SerializeField]
    bool useForce = true;
    [SerializeField] float jumpPower = 6f, moveSpeed = 3.0f;
    float physicsModifier = 100f;
    Vector2 moveDir = Vector2.zero;
    [SerializeField] float waypointRadius = 7.18f;

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movingBody) 
            if(useForce)    //need to set the flag        
                movingBody.AddForce(moveDir*moveSpeed*Time.deltaTime*physicsModifier, ForceMode2D.Force);
            else{   //we are mainly using this route
                //get ball position to avoid it going into the walls
                Vector2 ballPos = movingBody.position+(moveDir*moveSpeed*Time.deltaTime);
                if (ballPos.x > -waypointRadius && ballPos.x < waypointRadius) {
                    speed = jumpingBody.velocity.magnitude;
                    if (speed == 0)
                    {
                        jumpingBody.MovePosition(jumpingBody.position+(moveDir*moveSpeed*Time.deltaTime));     //ball will move together with the bar
                    }
                        movingBody.MovePosition(movingBody.position+(moveDir*moveSpeed*Time.deltaTime));
                }
            }
    }


    //This function will provide movement using the new input system
    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>() * moveSpeed;
    }
    
    float speed;

    void OnJump()
    {
        speed = jumpingBody.velocity.magnitude;
        if (speed == 0)
        {
            SetRandomTrajectory();  //this one will allow the ball to start randomly
        }
        
        //Debug.Log("jump");
    }
    
    //created with professor's help
    private void SetRandomTrajectory(){
        Vector2 force = Vector2.up;
        force.x = Random.Range(-1f, 1f);
        jumpingBody.AddForce(force.normalized * jumpPower,ForceMode2D.Impulse);
        jumpingBody.velocity = jumpingBody.velocity.normalized * jumpPower;
    }

}
