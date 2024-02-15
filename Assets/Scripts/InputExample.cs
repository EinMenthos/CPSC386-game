using System.Collections;
using System.Collections.Generic;
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
    [SerializeField]
    float jumpPower = 6f, moveSpeed = 2.5f;
    float physicsModifier = 100f;

    Vector2 moveDir = Vector2.zero;
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movingBody) 
        if(useForce) 
        //ForceMode2D.Force = physics like throttle
            movingBody.AddForce(moveDir*moveSpeed*Time.deltaTime*physicsModifier, ForceMode2D.Force);
        else
        //we are mainly using this one.
            movingBody.MovePosition(movingBody.position+(moveDir*moveSpeed*Time.deltaTime));
    }

    //This function will provide movement using the new input system
    void OnMove(InputValue value)
    {
        moveDir = value.Get<Vector2>() * moveSpeed;
        //Debug.Log(moveDir);
    }
    

    void OnJump()
    {
        if(jumpingBody) jumpingBody.AddForce(Vector2.up*jumpPower,ForceMode2D.Impulse);
        //Debug.Log("jump");
    }
}
