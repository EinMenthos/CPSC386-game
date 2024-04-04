
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UIElements;

[RequireComponent(typeof(UnitPool))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] public int maxEnemiesSpawned = 10;
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
    
    //link to next button
    [SerializeField] public GameObject btNextLv;
    
    //High score
    public TMP_Text HSUpdate;
    Highscore hs;
    ClockController clockValue;
/*
    //fade in effect while destroying/disabling it
    public float fadeDelay = 0.3f;
    public float alphaValue = 0;
    public bool destroyGameObject = false;
    SpriteRenderer spriteRenderer;
*/

    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
        hs = FindObjectOfType<Highscore>();
        clockValue = FindObjectOfType<ClockController>();
    }

    void Awake(){
        //txtEndlessGame.text = PlayerPrefs.GetString("EndlessGameHS");

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
        go.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-2, 3));
        curSpawned++;

        return go;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(curSpawned < maxEnemiesSpawned && timer > 1f/spawnsPerSecond)
        {
            SpawnEnemy();
            timer = 0;
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName.Contains("game2")){
                Debug.Log("enemies on screen: " + curSpawned);
            }
        }
    }

/*
//this is working. Want to use it when enemy is killed.
    IEnumerator FadeTo(float aValue, float fadeTime, GameObject other, bool usePooling){
        Debug.Log("FadeTo");
        float alpha = spriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t+= Time.deltaTime / fadeTime){
            Debug.Log("Fading...");
            Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(alpha, aValue, t));
            spriteRenderer.color = newColor;
            yield return null;
        }
        if (usePooling)
            pool.pool.Release(other);

        else
            Destroy(other);
            //gameObject.SetActive(false);
    }
 */
    public void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {
        //fade effect
        //spriteRenderer = GetComponent<SpriteRenderer>();
        if(usePooling){
            //StartCoroutine(FadeTo(alphaValue, fadeDelay, other, usePooling));
            //only happens at endless mode (game2)
            pool.pool.Release(other);
            Debug.Log("releasing...");      //releasing will put it on standby for further usage.
            curSpawned--;
            countEnemies++;
            txtPoints.text = countEnemies.ToString();

        }
        else{
            //StartCoroutine(FadeTo(alphaValue, fadeDelay, other, usePooling));
            //only happens at time battle (game1)
            Destroy(other);
            Debug.Log("destroying...");     //destroy will simply remove it from memory (need to render it later if needed)
            countEnemies++;
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName == "game1"){
                if (countEnemies == gameEndKill){
                    Debug.Log("All enemies were killed in game1!!!");
                    //string[] parts = PlayerPrefs.GetString("TimeBattleHS").Split(':', ' ');
                    //int minutes = int.Parse(parts[0]);
                    //int seconds = int.Parse(parts[1]);
                    //int timeHS = minutes * 60 + seconds;
                    //minutes = Mathf.FloorToInt(clockValue.elapsedTime / 60f);
                    //seconds = Mathf.FloorToInt(clockValue.elapsedTime % 60f);
                    //string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
                    PlayerPrefs.SetFloat("TimeBattleActual", clockValue.elapsedTime);
                    Debug.Log("Time Battle partial time: " + clockValue.elapsedTime);                                    
                    txtClear.gameObject.SetActive(true); //show the text on canvas.
                    Time.timeScale = 0;
                    btNextLv.gameObject.SetActive(true);
                }
            }

            if (sceneName == "game1b"){
                if (countEnemies == gameEndKill){
                    Debug.Log("All enemies were killed!!!");
                    string[] parts = PlayerPrefs.GetString("TimeBattleHS").Split(':', ' ');
                    int minutes = int.Parse(parts[0]);
                    int seconds = int.Parse(parts[1]);
                    int timeHS = minutes * 60 + seconds;
                    if (clockValue.elapsedTime < timeHS){
                        GlobalVariables.HSUpdated = true;
                        minutes = Mathf.FloorToInt(clockValue.elapsedTime / 60f);
                        seconds = Mathf.FloorToInt(clockValue.elapsedTime % 60f);
                        string timeText = string.Format("{0:00}:{1:00}", minutes, seconds);
                        PlayerPrefs.SetString("TimeBattleHS", timeText);
                        Debug.Log("Time Battle record:" + timeText);
                        HSUpdate.gameObject.SetActive(true);
                    }
                    Time.timeScale = 0;                
                    txtClear.gameObject.SetActive(true); //show the text on canvas.
                }
            }
            
        }
        
    }

}
