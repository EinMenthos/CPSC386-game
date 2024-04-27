using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class EnemyScoreController2 : MonoBehaviour
{
    int countEnemies = 0;
    [SerializeField] public TMP_Text txtPoints;
    [SerializeField] AudioSource extraB;

    void Update()
    {
        int ballN = GameObject.FindGameObjectsWithTag("ball").Length;
        if (ballN == 0){
            Debug.Log("All balls fell into the Pit...");
            int scoreHS = int.Parse(PlayerPrefs.GetString("EndlessGameHS"));
                if (int.Parse(txtPoints.text) > scoreHS){
                    GlobalVariables.HSUpdated = true;
                    PlayerPrefs.SetString("EndlessGameHS", txtPoints.text);
                    Debug.Log("SCORE updated: " + txtPoints.text);
                }
            SceneManager.LoadScene("gameover");
        }
    }

    public void ScoreGame2(){
        //Debug.Log("ScoreGame2");
        countEnemies++;
        txtPoints.text = countEnemies.ToString();
        if (countEnemies % 5 == 0 && countEnemies > 0){
            extraB.Play();
            Debug.Log("Add another ball after " + countEnemies + " hits");
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            GameObject newBall = Instantiate(balls[0], transform);
            newBall.transform.position = balls[0].transform.position;
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(balls[0].GetComponent<Rigidbody2D>().velocity.x * Random.Range(-0.5f, 0.5f), balls[0].GetComponent<Rigidbody2D>().velocity.y * Random.Range(-1f, 1f));
        }
    }
}