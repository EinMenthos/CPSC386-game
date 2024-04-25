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
        if (countEnemies % 5 == 0 && countEnemies > 0){
            Debug.Log("Add another ball: " + countEnemies);
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            GameObject newBall = Instantiate(balls[0], transform);
            newBall.transform.position = balls[0].transform.position;
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(balls[0].GetComponent<Rigidbody2D>().velocity.x * Random.Range(-0.5f, 0.5f), balls[0].GetComponent<Rigidbody2D>().velocity.y * Random.Range(-1f, 1f));
        }
    }
}