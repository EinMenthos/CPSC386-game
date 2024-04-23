using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EnemyScoreController2 : MonoBehaviour
{
    //float timer = 0;
    public int gameEndKill = 24;
    int countEnemies = 0;
    [SerializeField] public TMP_Text txtPoints;
    //ClockController clockValue;

    // Start is called before the first frame update
    void Start()
    {
        //clockValue = FindObjectOfType<ClockController>();
    }

    void Update()
    {
        int ballN = GameObject.FindGameObjectsWithTag("ball").Length;
        if (ballN == 0){
            Debug.Log("All balls fell into the Pit...");
            SceneManager.LoadScene("gameover");
        }
    }

    public void ScoreGame2(){
        //Debug.Log("ScoreGame2");
        countEnemies++;
        txtPoints.text = countEnemies.ToString();
    }
}