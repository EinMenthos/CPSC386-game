using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MobManager : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] public bool usePooling = false;
    public UnitPool pool {get; protected set;}
    SpriteRenderer spriteRenderer;
    public BossManager bm;
    public int limitBreak = 5;
    [SerializeField] AudioSource killSound;
    [SerializeField] AudioSource extraB;

    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
        bm = FindObjectOfType<BossManager>();
    }

        public GameObject SpawnMobs(int i, int j)
    {
        GameObject go;
        //pool
        go = pool.pool.Get();
        //not pool
        //go = Instantiate(enemyPrefab, transform);
        //go.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-2, 3));
        go.transform.position = new Vector3(i, j);
        return go;
    }

    IEnumerator IDelayReleasePool(GameObject other){
        //Debug.Log("waiting");
        yield return new WaitForSeconds(1);

        //Debug.Log("Done waiting");
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
        other.GetComponent<BoxCollider2D>().enabled = false;
        bm.limitCounter++;
        if (bm.limitCounter % limitBreak == 0 && bm.limitCounter > 0){
            extraB.Play();
            Debug.Log("Add another ball: " + bm.limitCounter + "hits");
            GameObject[] balls = GameObject.FindGameObjectsWithTag("ball");
            GameObject newBall = Instantiate(balls[0], transform);
            newBall.transform.position = balls[0].transform.position;
            newBall.GetComponent<Rigidbody2D>().velocity = new Vector2(balls[0].GetComponent<Rigidbody2D>().velocity.x * Random.Range(-0.5f, 0.5f), balls[0].GetComponent<Rigidbody2D>().velocity.y * Random.Range(-1f, 1f));
    }
        if(usePooling){
            //only happens at endless mode (game2)
            other.GetComponent<BoxCollider2D>().enabled = false;
            killSound.Play();
            StartCoroutine(IFadeTo(0, 0.5f, other, usePooling));
            StartCoroutine(IDelayReleasePool(other));
            //Debug.Log("releasing...");
        }
        else{
            //not the main route, without pooling
            other.GetComponent<BoxCollider2D>().enabled = false;
            killSound.Play();
            StartCoroutine(IFadeTo(0, 0.5f, other, usePooling));
            Destroy(other,1);
            //Debug.Log("destroying...");
            other.GetComponent<BoxCollider2D>().enabled = true;
        }
        
    }
}
