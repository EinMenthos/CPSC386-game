using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField]
    List<Vector3> waypoints;
    [SerializeField]
    float moveSpeed = 5f, waitTime = 1f, waypointRadius = 0.5f;
    // Start is called before the first frame update
    int curIndex = 0;
    float waitTimer;
    void Start()
    {
        if(waypoints == null || waypoints.Count == 0)
            Destroy(this);
            waitTimer = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position - waypoints[curIndex]).magnitude < waypointRadius)
        {
            waitTimer -= Time.deltaTime;
            if(waitTimer < 0)
            {
                waitTimer = waitTime;
                curIndex = (curIndex+1)%waypoints.Count;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,waypoints[curIndex],moveSpeed*Time.deltaTime);
        }
    }
}
