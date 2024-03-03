
using UnityEngine;

public class Highscore_init : MonoBehaviour
{
    void Start()
    {
        CheckPlayerPrefs();
    }

    void CheckPlayerPrefs(){
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
