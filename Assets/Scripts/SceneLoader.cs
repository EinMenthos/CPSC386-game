using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

//used as a reference
////https://www.youtube.com/watch?v=CE9VOZivb3I

public class SceneLoader : MonoBehaviour
{
    public string Scenebase = "";
    public string SceneName = "";
    public bool GoNextScene;
    public Animator transition;
    public float transitionTime = 1f;

    public void LoadScene()
    {
        //globalVariables.HSUpdated flag is set during game1 and game1.
        //Should be disabled before starting another game
        if(SceneName == "game1" || SceneName == "game2" || SceneName == "game1b" || SceneName == "game2b"){
            GlobalVariables.HSUpdated = false;
        }
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel(){
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        if(SceneName == "quit"){
            QuitApp();
        }  
        else{
            if(GoNextScene)
            {
                //SceneManager.LoadScene(SceneIndex);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
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
    public void QuitApp(){
        Application.Quit();
        Debug.Log("Quitting...");
    }
}
