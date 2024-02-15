using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneNavigation : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D col){
        Debug.Log(col.collider.tag);
        if(col.collider.tag == "NextLevel")
            SceneManager.LoadScene("MainMenu");
    }
        
}
