using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;



[RequireComponent(typeof(UnitPool))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] int maxEnemiesSpawned = 10;
    public float spawnsPerSecond = 0.5f;
    [SerializeField] public bool usePooling = false;
    [SerializeField] GameObject enemyPrefab;
    public UnitPool pool {get; protected set;}
    float timer = 0;
    int curSpawned = 1;//Should increment up to maxEnemiesSpawned
    int countEnemies = 0;
    public int gameEndKill = 24;
    [SerializeField] public TMP_Text txtClear;
    [SerializeField] public TMP_Text txtPoints;


    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
    }

    GameObject SpawnEnemy()
    {
        GameObject go;
        if(usePooling)
        {
            go = pool.pool.Get();
        }
        else
        {
            go = Instantiate(enemyPrefab, transform);
        }
        //Todo: how could we alter this so enemies always spawn around the player?
        go.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-2, 3));
        curSpawned++;

        return go;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("Enemies: " + curSpawned);
        if(curSpawned < maxEnemiesSpawned && timer > 1f/spawnsPerSecond)
        {
            SpawnEnemy();
            timer = 0;
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "game2b"){
                Debug.Log("enemies on screen: " + curSpawned);
            }
        }
    }

    public void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {

        if(usePooling){
            pool.pool.Release(other);
            Debug.Log("releasing...");      //releasing will put it on standby for further usage.
            curSpawned--;
            countEnemies++;
            txtPoints.text = countEnemies.ToString();
        }
        else{
            Destroy(other);
            Debug.Log("destroying...");     //destroy will simply remove it from memory (need to render it later if needed)
            countEnemies++;
            Debug.Log("Enemies Killed: " + countEnemies);
            //https://discussions.unity.com/t/how-to-check-which-scene-is-loaded-and-write-if-code-for-it/163399/2

            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "game1b"){
                if (countEnemies == gameEndKill){
                    //Debug.Log("All enemies were killed!!!");
                    Time.timeScale = 0;
                    //show the text on canvas.
                    txtClear.gameObject.SetActive(true);
                }
            }

        }
        
    }
}
