using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string SceneName = "";
    public int SceneIndex = 0;

    public void LoadScene()
    {
        if(SceneName == "")
        {
            SceneManager.LoadScene(SceneIndex);
        }
        else{
            SceneManager.LoadScene(SceneName);
        }

    }
}
