using TMPro;
using UnityEngine;

public class Highscore_bt : MonoBehaviour
{
    public TMP_Text txtEndlessGame;
    public TMP_Text txtTimeBattle;

    public void clearHS(){
        PlayerPrefs.SetString("EndlessGameHS","0");
        txtEndlessGame.text = "0";
        PlayerPrefs.SetString("TimeBattleHS", "10:00");
        txtTimeBattle.text = "10:00";
    }
}
