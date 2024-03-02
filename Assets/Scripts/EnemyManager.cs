//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;
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
    public TMP_Text HSUpdate;

    highscore hs;
    clockController clockValue;


    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
        hs = FindObjectOfType<highscore>();
        clockValue = FindObjectOfType<clockController>();
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
            if (sceneName == "game2"){
                Debug.Log("enemies on screen: " + curSpawned);
            }
        }
    }

    public void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {

        if(usePooling){
            //only happens at endless mode (game2)
            pool.pool.Release(other);
            Debug.Log("releasing...");      //releasing will put it on standby for further usage.
            curSpawned--;
            countEnemies++;
            txtPoints.text = countEnemies.ToString();
            //Debug.Log("Saving score: ")

        }
        else{
            //only happens at time battle (game1)
            Destroy(other);
            Debug.Log("destroying...");     //destroy will simply remove it from memory (need to render it later if needed)
            countEnemies++;
            //Debug.Log("Enemies Killed: " + countEnemies);
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "game1"){
                if (countEnemies == gameEndKill){
                    Debug.Log("All enemies were killed!!!");

                    string[] parts = PlayerPrefs.GetString("TimeBattleHS").Split(':', ' ');
                    int minutes = int.Parse(parts[0]);
                    int seconds = int.Parse(parts[1]);
                    Debug.Log("Loading best time: " + parts[0] + ":" + parts[1]);
                    int timeHS = minutes * 60 + seconds;
                    //Debug.Log(clockValue.elapsedTime);
                    if (clockValue.elapsedTime < timeHS){
                        globalVariables.HSUpdated = true;
                        //Debug.Log("updating HS");
                        minutes = Mathf.FloorToInt(clockValue.elapsedTime / 60f);
                        seconds = Mathf.FloorToInt(clockValue.elapsedTime % 60f);
                        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
                        PlayerPrefs.SetString("TimeBattleHS", timeText);
                        Debug.Log("HS updated!");
                        HSUpdate.gameObject.SetActive(true);
                    }
                    Time.timeScale = 0;                
                    txtClear.gameObject.SetActive(true); //show the text on canvas.
                }
            }

        }
        
    }
}
