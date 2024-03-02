using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Scenebase = "";
    public string SceneName = "";
    public int SceneIndex = 0;
    

    public void LoadScene()
    {
        //disable msg of Highscore at gameover
        if(SceneName == "game1" || SceneName == "game2"){
            globalVariables.HSUpdated = false;
        }
        //globalVariables.HSUpdated = false;
        if(SceneName == "")
        {
            SceneManager.LoadScene(SceneIndex);
        }
        else{
            //SceneManager.LoadScene(SceneName);
            Time.timeScale = 1;
            if(Scenebase == "") {
                SceneManager.LoadScene(SceneName);
            }
            else{
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
                SceneManager.LoadScene(Scenebase, LoadSceneMode.Additive);
            }
        }

    }
}
