using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highscore_init : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CheckPlayerPrefs();
    }

    void CheckPlayerPrefs(){
        //Debug.Log("Creating PlayerPref if needed");
        if(!PlayerPrefs.HasKey("EndlessGameHS")){
            Debug.Log("Creating PlayerPrefs.EndlessGameHS");
            PlayerPrefs.SetString("EndlessGameHS","0");
        }
        if(!PlayerPrefs.HasKey("TimeBattleHS")){
            Debug.Log("Creating PlayerPrefs.TimeBattleHS");
            PlayerPrefs.SetString("TimeBattleHS", "10:00");
        }
    }
}
