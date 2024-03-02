using TMPro;
//using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityEngine.UI;


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

    private void SetRandomTrajectory(){
        Vector2 force = Vector2.up;
        force.x = Random.Range(-1f, 1f);
        rigidbodyB.AddForce(force.normalized * speed,ForceMode2D.Impulse);
        rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
    }

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
            //Debug.Log("current scene: " + sceneName);
            //don't make sense to have a high score for kills in time battle since it will always have max kills
            //Endless = only finish when ball falls in the pit.
            if (sceneName == "game2"){
                int scoreHS = int.Parse(PlayerPrefs.GetString("EndlessGameHS"));
                //Debug.Log("Loading best score: " + scoreHS);
                //Debug.Log(clockValue.elapsedTime);
                
                if (int.Parse(scorePlayer.text) > scoreHS){
                    globalVariables.HSUpdated = true;
                    //Debug.Log("updating score HS");
                    PlayerPrefs.SetString("EndlessGameHS", scorePlayer.text);
                    Debug.Log("SCORE updated!");
                }
                
            }
        }
        //OnTriggerEnter2D: Owning object must be Kinematic, other collider must be "Trigger"
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Enemy")){
            //Debug.Log("Collision-Enemy");
            //HandleEnemy(collision.otherCollider.gameObject);  // this it the bar
            em.HandleEnemy(collision.collider.gameObject);         //this is the ball
        }
        //Requires both objects have rigidbody2d and collider, with maximum 1 kinematic rigidbody
    }
    
}
