using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EnemyScoreController1 : MonoBehaviour
{
    public int gameEndKill = 24;
    int countEnemies = 0;
    [SerializeField] public TMP_Text txtClear;
    [SerializeField] public TMP_Text txtPoints;
    
    //link to next button
    [SerializeField] public GameObject btNextLv;
        //High score
    public TMP_Text HSUpdate;
    Highscore hs;
    ClockController clockValue;


    // Start is called before the first frame update
    void Start()
    {
        hs = FindObjectOfType<Highscore>();
        clockValue = FindObjectOfType<ClockController>();
    }

    void Update()
    {
        int ballN = GameObject.FindGameObjectsWithTag("ball").Length;
        if (ballN == 0){
            Debug.Log("All balls fell into the Pit...");
            SceneManager.LoadScene("gameover");
        }
    }

    public void ScoreGame1(){
        //Debug.Log("ScoreGame1");
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        countEnemies++;
        if (countEnemies % 5 == 0 && countEnemies > 0){
            Debug.Log("Add another ball: " + countEnemies);
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            GameObject newBall = Instantiate(balls[0], transform);
            newBall.transform.position = balls[0].transform.position;
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(balls[0].GetComponent<Rigidbody2D>().velocity.x * Random.Range(-0.5f, 0.5f), balls[0].GetComponent<Rigidbody2D>().velocity.y * Random.Range(-1f, 1f));
        }
        if (sceneName == "game1c"){
                Debug.Log("The boss stage is cleared!!!");
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
        else{
            if (sceneName == "game1" || sceneName == "game1b"){
                if (countEnemies == gameEndKill){
                    Debug.Log("All enemies were killed in " + sceneName +"!!!");
                    PlayerPrefs.SetFloat("TimeBattleActual", clockValue.elapsedTime);
                    Debug.Log("Time Battle partial time: " + clockValue.elapsedTime);                                    
                    txtClear.gameObject.SetActive(true); //show the text on canvas.
                    Time.timeScale = 0;
                    btNextLv.gameObject.SetActive(true);
                }
            }
        }
    }
}
