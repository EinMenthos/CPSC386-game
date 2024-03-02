using TMPro;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public TMP_Text HSText;
    void Start()
    {
        if (globalVariables.HSUpdated){
            Debug.Log("if:" + HSText.enabled);
            HSText.gameObject.SetActive(true);
        }
        else{
            Debug.Log("else:" + HSText.enabled);
            HSText.gameObject.SetActive(false);
        }
    }
}
