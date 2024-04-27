using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffLoad : MonoBehaviour
{
    BossManager bm;
    MobManager mm;
    [SerializeField] public GameObject refBall;
    [SerializeField] public GameObject refPaddle;
    [SerializeField] public GameObject refPaddleShadow;


    [SerializeField] public InputExample inputEx;

    // Start is called before the first frame update
    void Start()
    {
        bm = FindObjectOfType<BossManager>();
        mm = FindObjectOfType<MobManager>();
        Buff4Game();
    }
    void Buff4Game(){
        if (GlobalVariables.BuffBall != 0){
            //https://discussions.unity.com/t/how-can-i-scale-down-a-2d-sprite-via-script/92186
            Vector3 theScale = refBall.transform.localScale;
			theScale.x *= 1.5f;
            theScale.y *= 1.5f;
			refBall.transform.localScale = theScale;
        }
        if (GlobalVariables.BuffPaddle != 0){
            Vector3 theScale = refPaddle.transform.localScale;
            Vector3 theScaleShadow = refPaddleShadow.transform.localScale;
			theScale.x *= 1.5f;
            theScaleShadow.x *= 1.5f;
			refPaddle.transform.localScale = theScale;   
            refPaddleShadow.transform.localScale = theScaleShadow;    
            inputEx.waypointRadius *= 0.91f;
        }
        if(GlobalVariables.BuffSpawn != 0){
            bm.limitBreak = 4;
            mm.limitBreak = 4;
        }
    }
}
