using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class highscore_bt : MonoBehaviour
{
    public TMP_Text txtEndlessGame;
    public TMP_Text txtTimeBattle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void clearHS(){
        PlayerPrefs.SetString("EndlessGameHS","0");
        txtEndlessGame.text = "0";
        PlayerPrefs.SetString("TimeBattleHS", "10:00");
        txtTimeBattle.text = "10:00";
    }

    // Update is called once per frame

}
