using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouncingBall : MonoBehaviour
{
    EnemyManager em;
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
    }

    void Update()
    {
        rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
    }

/*
    private void SetRandomTrajectory(){
        Vector2 force = Vector2.up;
        force.x = Random.Range(-1f, 1f);
        rigidbodyB.AddForce(force.normalized * speed,ForceMode2D.Impulse);
        rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
    }
*/
    void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger-Enemy");
        if(collider.CompareTag("Enemy")){
            em.HandleEnemy(collider.gameObject);
        }
        if(collider.CompareTag("Pit")){
            Debug.Log("Pit!");
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            //don't make sense to have a high score for kills in time battle since it will always have max kills
            //Endless = only finish when ball falls in the pit.
            if (sceneName == "game2"){
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
    }
}
