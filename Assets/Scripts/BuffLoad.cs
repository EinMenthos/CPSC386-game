using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffLoad : MonoBehaviour
{
    EnemyManager em;
    //public Rigidbody2D rigidbodyB {get; private set; }
    [SerializeField] public GameObject refBall;
    [SerializeField] public GameObject refPaddle;

    [SerializeField] public InputExample inputEx;

    // Start is called before the first frame update
    void Start()
    {
        em = FindObjectOfType<EnemyManager>();
        //refBall = FindObjectOfType<>
        Buff4Game();

    }
    void Buff4Game(){
        if (GlobalVariables.BuffBall != 0){
            //https://discussions.unity.com/t/how-can-i-scale-down-a-2d-sprite-via-script/92186
            Vector3 theScale = refBall.transform.localScale;
            //Debug.Log(theScale.x + "," + theScale.y + "," + theScale.z);
			theScale.x *= 1.5f;
            theScale.y *= 1.5f;
			refBall.transform.localScale = theScale;
        }
        if (GlobalVariables.BuffPaddle != 0){
            Vector3 theScale = refPaddle.transform.localScale;
            //Debug.Log(theScale.x + "," + theScale.y + "," + theScale.z);
			theScale.x *= 1.5f;
			refPaddle.transform.localScale = theScale;    
            inputEx.waypointRadius *= 0.91f;
        }
        if(GlobalVariables.BuffSpawn != 0){
            em.maxEnemiesSpawned += 10;
        }
    }
}
