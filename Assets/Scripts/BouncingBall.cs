using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouncingBall : MonoBehaviour
{
    EnemyManager em;
    BossManager bm;
    public Rigidbody2D rigidbodyB {get; private set; }
    public float speed = 6f;
    public TMP_Text scorePlayer;

    private void Awake(){
        rigidbodyB = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<EnemyManager>();
        bm = FindObjectOfType<BossManager>();
    }

    void Update()
    {
        rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger-Enemy");
        if(collider.CompareTag("Enemy")){
            em.HandleEnemy(collider.gameObject);
        }
        if(collider.CompareTag("Boss")){
            bm.HandleEnemy(collider.gameObject);
        }
        if(collider.CompareTag("Pit")){
            Debug.Log("Pit!");
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            //don't make sense to have a high score for kills in time battle since it will always have max kills
            //Endless = only finish when ball falls in the pit.
            if (sceneName.Contains("game2")){
                int scoreHS = int.Parse(PlayerPrefs.GetString("EndlessGameHS"));
                if (int.Parse(scorePlayer.text) > scoreHS){
                    GlobalVariables.HSUpdated = true;
                    PlayerPrefs.SetString("EndlessGameHS", scorePlayer.text);
                    Debug.Log("SCORE updated: " + scorePlayer.text);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy")){
            em.HandleEnemy(collision.collider.gameObject);         //this is the ball
        }
        if(collision.collider.CompareTag("Boss")){
            bm.HandleEnemy(collision.collider.gameObject);         //this is the ball
        }
        //Debug.Log("check veocity");
        //used as reference https://forum.unity.com/threads/breakout-pong-ball-stuck-to-wall-problem.138770/
                /* x-axis is not a problem since paddle can change it
        */
        if(Mathf.Abs(rigidbodyB.velocity.y) < 0.5 && rigidbodyB.velocity.x != 0){
            Debug.Log("Ball stuck at x-axis:  Adding random factor...");
            float yDistance = rigidbodyB.position.y - transform.position.y;
            rigidbodyB.velocity = new Vector2(rigidbodyB.velocity.x, rigidbodyB.velocity.y + yDistance - Mathf.Sign(yDistance) * Random.Range(0.1f, 0.2f));
        }
    }


}
