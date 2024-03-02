using UnityEngine;
using TMPro;


public class highscore : MonoBehaviour
{
    [SerializeField] public TMP_Text txtEndlessGame;
    [SerializeField] public TMP_Text txtTimeBattle;
 
    // Start is called before the first frame update
    void Start()
    {
        //create keys in PlayerPrefs if it does not exists
        LoadPlayerPrefs();
    }

    //https://docs.unity3d.com/ScriptReference/PlayerPrefs.html
    //macos save it at /Users/danielwu/Library/Preferences/unity.WuCompany.Project1.plist
    
    public void LoadPlayerPrefs(){
        Debug.Log("Loading PlayerPrefs.EndlessGameHS");
        txtEndlessGame.text = GetPlayerPrefs("EndlessGameHS");;
        Debug.Log("Loading PlayerPrefs.TimeBattleHS");
        txtTimeBattle.text = GetPlayerPrefs("TimeBattleHS");
    }
    
    public void SetPlayerPrefs(string KeyName, string Value)
    {
        PlayerPrefs.SetString(KeyName, Value);
    }
    
    public string GetPlayerPrefs(string KeyName)
    {
        return PlayerPrefs.GetString(KeyName);
    }
}
