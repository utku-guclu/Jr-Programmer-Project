using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoints;
    int currentWP = 0;
    public float speed = 10.0f;
    public float rotSpeed = 10.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWP >= waypoints.Length)
            currentWP = 0;
       
        GameObject currentTarget = waypoints[currentWP];

        float distanceBetween = Vector3.Distance(this.transform.position, currentTarget.transform.position);

        if (distanceBetween < 3)
            currentWP++;
            Debug.Log(currentTarget);

        /* this.transform.LookAt(currentTarget.transform); // lock the target */

        // smooth LookAt
        Quaternion lookatWP = Quaternion.LookRotation(waypoints[currentWP].transform.position - this.transform.position)
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime); // increment z (forward)
    }
}
