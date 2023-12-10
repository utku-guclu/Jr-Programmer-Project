using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoints;
    int currentWP = 0;
    int finalWP = 3;
    public float speed = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWP >= waypoints.Length)
            currentWP = 0;
       
        GameObject currentTarget = waypoints[currentWP];

        if (Vector3.Distance(this.transform.position, currentTarget.transform.position) < finalWP)
            currentWP++;
            Debug.Log(currentTarget);

        this.transform.LookAt(currentTarget.transform); // lock the target
        this.transform.Translate(0, 0, speed * Time.deltaTime); // increment z (forward)
    }
}
