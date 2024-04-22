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

    public void ScoreGame1(){
        Debug.Log("ScoreGame1");
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
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
            countEnemies++;
        
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
