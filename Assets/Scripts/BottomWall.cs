using UnityEngine;
using UnityEngine.SceneManagement;

public class BottomWall : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        //Debug.Log("Trigger / bottom wall");
        if(collider.tag == "ball"){
            Debug.Log("A Ball fell into pit!");
            Destroy(collider.gameObject);
        }
    }
}
