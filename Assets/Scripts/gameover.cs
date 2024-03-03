using TMPro;
using UnityEngine;

public class Gameover : MonoBehaviour
{
    public TMP_Text HSText;
    void Start()
    {
        if (GlobalVariables.HSUpdated){
            Debug.Log("if:" + HSText.enabled);
            HSText.gameObject.SetActive(true);
        }
        else{
            Debug.Log("else:" + HSText.enabled);
            HSText.gameObject.SetActive(false);
        }
    }
}
