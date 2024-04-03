using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Youtube - scene transition
//https://www.youtube.com/watch?v=CE9VOZivb3I

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel(){
        //automatically go to next scene build index
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex +1));
    }
    IEnumerator LoadLevel(int levelIndex){
        //Play animation
        transition.SetTrigger("Start");
        //Wait
        yield return new WaitForSeconds(transitionTime);
        //Load Scene
        //SceneManager.LoadScene(levelIndex);
    }
}
