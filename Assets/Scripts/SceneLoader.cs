using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string Scenebase = "";
    public string SceneName = "";
    public int SceneIndex = 0;

    public void LoadScene()
    {
        if(SceneName == "")
        {
            SceneManager.LoadScene(SceneIndex);
        }
        else{
            //SceneManager.LoadScene(SceneName);
            if(Scenebase == "") SceneManager.LoadScene(SceneName);
            else{
                SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
                SceneManager.LoadScene(Scenebase, LoadSceneMode.Additive);
            }
        }

    }
}
