using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouncingBall : MonoBehaviour
{
    EnemyManager em;
    BossManager bm;
    MobManager mm;
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
        mm = FindObjectOfType<MobManager>();
    }

    void Update()
    {
        rigidbodyB.velocity = rigidbodyB.velocity.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collision Action");
        if(collision.collider.CompareTag("Enemy")){
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName.Contains("game1c")){
                mm.HandleEnemy(collision.collider.gameObject);         //this is the ball
            }
            else{
                em.HandleEnemy(collision.collider.gameObject);         //this is the ball
            }
        }
        if(collision.collider.CompareTag("Boss")){
            bm.HandleEnemy(collision.collider.gameObject);         //this is the ball
        }

        if(Mathf.Abs(rigidbodyB.velocity.y) < 0.5 && rigidbodyB.velocity.x != 0){
            Debug.Log("Ball stuck at x-axis:  Adding random factor...");
            float yDistance = rigidbodyB.position.y - transform.position.y;
            rigidbodyB.velocity = new Vector2(rigidbodyB.velocity.x, rigidbodyB.velocity.y + yDistance - Mathf.Sign(yDistance) * Random.Range(-0.5f, -0.2f));
        }
    }
}
