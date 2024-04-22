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
/*
    //fade in effect while destroying/disabling it
    public float fadeDelay = 0.3f;
    public float alphaValue = 0;
    public bool destroyGameObject = false;
    SpriteRenderer spriteRenderer;
*/

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
        go.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-2, 3));
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
            Scene currentScene = SceneManager.GetActiveScene ();
            string sceneName = currentScene.name;
            if (sceneName.Contains("game2")){
                Debug.Log("enemies on screen: " + curSpawned);
            }
        }
    }

/*
//this is working. Want to use it when enemy is killed.
    IEnumerator FadeTo(float aValue, float fadeTime, GameObject other, bool usePooling){
        Debug.Log("FadeTo");
        float alpha = spriteRenderer.color.a;
        for (float t = 0.0f; t < 1.0f; t+= Time.deltaTime / fadeTime){
            Debug.Log("Fading...");
            Color newColor = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, Mathf.Lerp(alpha, aValue, t));
            spriteRenderer.color = newColor;
            yield return null;
        }
        if (usePooling)
            pool.pool.Release(other);

        else
            Destroy(other);
            //gameObject.SetActive(false);
    }
 */
    public void HandleEnemy(GameObject other)//Deletes enemy and applies damage
    {
        //fade effect
        //spriteRenderer = GetComponent<SpriteRenderer>();
        if(usePooling){
            //StartCoroutine(FadeTo(alphaValue, fadeDelay, other, usePooling));
            //only happens at endless mode (game2)
            pool.pool.Release(other);
            Debug.Log("releasing...");      //releasing will put it on standby for further usage.
            curSpawned--;
            EnScCtr2.ScoreGame2();
        }
        else{
            //StartCoroutine(FadeTo(alphaValue, fadeDelay, other, usePooling));
            //only happens at time battle (game1)
            Destroy(other);
            Debug.Log("destroying...");     //destroy will simply remove it from memory (need to render it later if needed)
            EnScCtr1.ScoreGame1();
        }
        
    }
        public GameObject SpawnMobs(int i, int j)
    {
        GameObject go;
        go = Instantiate(enemyPrefab, transform);
        //go.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-2, 3));
        go.transform.position = new Vector3(i, j);
        return go;
    }

}
