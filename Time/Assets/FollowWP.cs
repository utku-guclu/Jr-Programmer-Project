using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] waypoints;
    GameObject tracker;
    int currentWP = 0;
    public float speed = 10.0f;
    public float rotSpeed = 1.0f;
    public float lookAhead = 10.0f;

    void Start()
    {
        tracker = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        
        DestroyImmediate(tracker.GetComponent<Collider>());
        tracker.GetComponent<MeshRenderer>().enabled = false;

        tracker.transform.position = this.transform.position;
        tracker.transform.rotation = this.transform.rotation;
    }
    void ProgressTracker()
    {
        float distanceBetweenTT = Vector3.Distance(tracker.transform.position, this.transform.position);

        // tracker will stop if too far away
        if (distanceBetweenTT > lookAhead) return;

        if (currentWP >= waypoints.Length)
            currentWP = 0;
       
        GameObject currentTarget = waypoints[currentWP];

        float distanceBetweenTW = Vector3.Distance(tracker.transform.position, currentTarget.transform.position);

        if (distanceBetweenTW < 3)
            currentWP++;
            Debug.Log(currentTarget);

        tracker.transform.LookAt(waypoints[currentWP].transform);
        tracker.transform.Translate(0, 0, (speed + 2 ) * Time.deltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        ProgressTracker();

        /* this.transform.LookAt(currentTarget.transform); // lock the target */

        // smooth LookAt
        Quaternion lookatWP = Quaternion.LookRotation(tracker.transform.position - this.transform.position);
        
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookatWP, rotSpeed * Time.deltaTime);

        this.transform.Translate(0, 0, speed * Time.deltaTime); // increment z (forward)
    }
}
