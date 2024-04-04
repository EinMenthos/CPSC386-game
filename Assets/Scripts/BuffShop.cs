using UnityEngine;
using UnityEngine.SceneManagement;


public class shopbuff : MonoBehaviour
{
    [SerializeField]public string BuffName = "";

    // Start is called before the first frame update
    void Start()
    {
        GlobalVariables.BuffBall = 0;
        GlobalVariables.BuffPaddle = 0;
        GlobalVariables.BuffSpawn = 0;
    }

    public void LoadBuff(){
        //globalVariables.HSUpdated flag is set during game1 and game1.
        //Should be disabled before starting another game
        if(BuffName == "Ball" || BuffName == "Paddle" || BuffName == "Spawn"){
            GlobalVariables.HSUpdated = false;
        }
        if(BuffName == "Ball"){
            GlobalVariables.BuffBall += 1;
            Debug.Log("Buff Ball +" + GlobalVariables.BuffBall);
        }
        if(BuffName == "Paddle"){
            GlobalVariables.BuffPaddle += 1;
            Debug.Log("Buff Paddle +" + GlobalVariables.BuffPaddle);
        }
        if(BuffName == "Spawn"){
            GlobalVariables.BuffSpawn += 1;
            Debug.Log("Buff Spawn +" + GlobalVariables.BuffSpawn);
        }
        //the game might be paused at start. Should start it.
        Time.timeScale = 1;
        //2 scenes used to create each level.
        SceneManager.LoadScene("game2b", LoadSceneMode.Single);
        SceneManager.LoadScene("baseLv", LoadSceneMode.Additive);
    }
}
