using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Scenebase = "";
    public string SceneName = "";
    public int SceneIndex = 0;
    
    public void LoadScene()
    {
        //globalVariables.HSUpdated flag is set during game1 and game1.
        //Should be disabled before starting another game
        if(SceneName == "game1" || SceneName == "game2"){
            GlobalVariables.HSUpdated = false;
        }
        if(SceneName == "")
        {
            SceneManager.LoadScene(SceneIndex);
        }
        else{
            //the game is paused at game1. Should start it when switching scenes.
            Time.timeScale = 1;
            if(Scenebase == "") {
                SceneManager.LoadScene(SceneName);
            }
            else{
                //2 scenes used to create each level.
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
                SceneManager.LoadScene(Scenebase, LoadSceneMode.Additive);
            }
        }

    }
}
