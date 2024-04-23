using System.ComponentModel;
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
/*
    // Update is called once per frame
    void FixedUpdate()
    {
        int ballN = GameObject.FindGameObjectsWithTag("ball").Length;
        if (ballN > 0){
            if(movingBody) 
                if(useForce)    //need to set the flag        
                    movingBody.AddForce(moveDir*moveSpeed*Time.deltaTime*physicsModifier, ForceMode2D.Force);
                else{   //we are mainly using this route
                    //get ball position to avoid it going into the walls
                    Vector2 ballPos = movingBody.position+(moveDir*moveSpeed*Time.deltaTime);
                    if (ballPos.x > -waypointRadius && ballPos.x < waypointRadius) {
                        speed = jumpingBody.velocity.magnitude;
                        if (speed == 0)
                        {
                            //ball will move together with the bar
                            jumpingBody.MovePosition(jumpingBody.position+(moveDir*moveSpeed*Time.deltaTime));     
                        }
                            //bar will move no matter the speed of the ball
                            movingBody.MovePosition(movingBody.position+(moveDir*moveSpeed*Time.deltaTime));
                    }
                }
        }
    }
*/
    void OnTriggerEnter2D(Collider2D collider)
    {
        /*
        Debug.Log("Not being used in this script...");
        if(collider.CompareTag("Enemy")){
            em.HandleEnemy(collider.gameObject);
        }
        if(collider.CompareTag("Boss")){
            bm.HandleEnemy(collider.gameObject);
        }
        */
        /*
        if(collider.CompareTag("Pit")){
            //Debug.Log("Pit!");
            
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
        */
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision Action");
        if(collision.collider.CompareTag("Enemy")){
            em.HandleEnemy(collision.collider.gameObject);         //this is the ball
        }
        if(collision.collider.CompareTag("Boss")){
            bm.HandleEnemy(collision.collider.gameObject);         //this is the ball
        }
        /*
        if(collision.collider.CompareTag("Pit")){
            Debug.Log("Pit: " + collision.otherCollider.gameObject.tag.ToString());
        }
        */
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
