using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(UnitPool))]
public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    int maxEnemiesSpawned = 100, spawnsPerSecond = 1;
    [SerializeField]
    public bool usePooling = false;
    [SerializeField]
    GameObject enemyPrefab;
    public UnitPool pool {get; protected set;}
    float timer = 0;
    int curSpawned = 0;//Should increment up to maxEnemiesSpawned
    // Start is called before the first frame update
    void Start()
    {
        pool = GetComponent<UnitPool>();
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
        //Todo: how could we alter this so enemies always spawn around the player?
        go.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-8, 8));
        curSpawned++;
        return go;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        //Debug.Log("Enemies: " + curSpawned);
        if(curSpawned < maxEnemiesSpawned && timer > 1f/spawnsPerSecond)
        {
            SpawnEnemy();
            timer = 0;
        }
    }
}
