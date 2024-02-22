using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BottomWall : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger / bottom wall");
        if(collider.tag == "ball"){
            Debug.Log("trigger-ball");
            SceneManager.LoadScene("gameover");
            //ballModifier = FindObjectOfType
        }
        else{
            Debug.Log("trigger-bar");

        }

        //if(collider.tag == "Enemy")
            //HandleEnemy(collider.gameObject);


        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }
}
