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

    void SetActiveHS (){
        if (GlobalVariables.HSUpdated){
            HSText.gameObject.SetActive(true);
        }
        else{
            HSText.gameObject.SetActive(false);
        }
    }
}
