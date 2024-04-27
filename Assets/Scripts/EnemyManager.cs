using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(UnitPool))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField] public int maxEnemiesSpawned = 10;
    public float spawnsPerSecond = 0.5f;
    [SerializeField] public bool usePooling = false;
    [SerializeField] GameObject enemyPrefab;
    public UnitPool pool {get; protected set;}
    float timer = 0;
    int curSpawned = 1;//Should increment up to maxEnemiesSpawned
    EnemyScoreController1 EnScCtr1;
    EnemyScoreController2 EnScCtr2;

    SpriteRenderer spriteRenderer;
    [SerializeField] AudioSource killSound;    

    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
        EnScCtr1 = FindObjectOfType<EnemyScoreController1>();
        EnScCtr2 = FindObjectOfType<EnemyScoreController2>();
    }

    GameObject SpawnEnemy()
    {
        GameObject go;
        if(usePooling)
        {
            go = pool.pool.Get();
        }
        else
        {
            go = Instantiate(enemyPrefab, transform);
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<string> enemiesPos = new List<string>();
        foreach (GameObject enemy in enemies){
            enemiesPos.Add(enemy.transform.position.x.ToString() + "," + enemy.transform.position.y.ToString());
        }
        int x = Random.Range(-8, 9);
        int y = Random.Range(-2, 4);
        while (enemiesPos.Contains(x + "," + y)){
            Debug.Log("recalculating enemy position...");
            x = Random.Range(-8, 8);
            y = Random.Range(-2, 3);
        }
        go.transform.position = new Vector3(x, y);
        curSpawned++;
        return go;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(curSpawned < maxEnemiesSpawned && timer > 1f/spawnsPerSecond)
        {
            SpawnEnemy();
            timer = 0;
        }
        //GameObject.FindGameObjectsWithTag("ball").Length  // used to count "balls"
        //GameObject.FindGameObjectsWithTag("Enemy").Length   //used to count "Enemies" on screen
        /*
        if (GameObject.FindGameObjectsWithTag("ball").Length != 0)
            Debug.Log(GameObject.FindGameObjectsWithTag("ball").Length);
            */
    }
    IEnumerator IDelayReleasePool(GameObject other){
        //Debug.Log("waiting");
        yield return new WaitForSeconds(1);

        Color tmp = other.GetComponent<SpriteRenderer>().color;
        tmp.a = 1.0f;
        other.GetComponent<SpriteRenderer>().color = tmp;
        if(pool) pool.pool.Release(other);
        other.GetComponent<BoxCollider2D>().enabled = true;

    }

    IEnumerator IFadeTo(float aValue, float fadeTime, GameObject other, bool usePooling){
        spriteRenderer = other.GetComponent<SpriteRenderer>();
        float alpha = spriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t+= Time.deltaTime / fadeTime){
            //Debug.Log("Fading: " + t);
            Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(alpha, aValue, t));
            spriteRenderer.color = newColor;
            yield return null;
        }
    }
 
    public void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {
        if(usePooling){
            other.GetComponent<BoxCollider2D>().enabled = false;
            killSound.Play();
            StartCoroutine(IFadeTo(0, 0.5f, other, usePooling));
            StartCoroutine(IDelayReleasePool(other));
            //Debug.Log("releasing...");      //releasing will put it on standby for further usage.
            curSpawned--;
            
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName.Contains("game2")){
                EnScCtr2.ScoreGame2();
            }
        }
        else{
            other.GetComponent<BoxCollider2D>().enabled = false;
            killSound.Play();
            StartCoroutine(IFadeTo(0, 0.5f, other, usePooling));
            //only happens at time battle (game1 and game1b)
            Destroy(other,1);
            //Debug.Log("destroying...");     //destroy will simply remove it from memory (need to render it later if needed)
            EnScCtr1.ScoreGame1();
        }
        
    }
}
