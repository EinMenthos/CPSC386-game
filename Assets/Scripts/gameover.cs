using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameover : MonoBehaviour
{
    public TMP_Text HSText;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("global: " + globalVariables.HSUpdated);
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
