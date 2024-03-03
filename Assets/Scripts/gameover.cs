using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    
    public TMP_Text HSText;
    // Start is called before the first frame update
    void Start()
    {
        SetActiveHS();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetActiveHS (){
        if (GlobalVariables.HSUpdated){
            //Debug.Log("if:" + HSText.enabled);
            HSText.gameObject.SetActive(true);
        }
        else{
            //Debug.Log("else:" + HSText.enabled);
            HSText.gameObject.SetActive(false);
        }
    }
}
