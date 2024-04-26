using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barBottom : MonoBehaviour
{
    public GameObject barT;
    public GameObject barB;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barB.transform.position = new Vector2 (barT.transform.position.x, barB.transform.position.y);
    }
}
