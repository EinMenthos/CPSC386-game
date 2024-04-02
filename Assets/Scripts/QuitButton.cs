using UnityEngine;

public class QuitBt : MonoBehaviour
{
    public void QuitApp(){
        Application.Quit();
        Debug.Log("Quitting the game...");
    }
}
