using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingObject : MonoBehaviour
{
    
    
    [SerializeField]
    private float speed = 40;
    [Tooltip("Script that decides flight path")]
    public AlienAttacks attackPath;
    

    private List<Vector3> waypoints = new List<Vector3>();
    private int pathIndex;


    private void OnEnable()
    {
        SetPath();
    }
    
    private void SetPath() //Sets the flight path from the AlienAttacks Script
    {
        waypoints.Clear();
        for (int i = 0; i < attackPath.pathPoints.Count; i++)
        {
            waypoints.Add(attackPath.pathPoints[i]);
        }
        transform.position = waypoints[0];
        pathIndex = 1;
    } 

    // Update is called once per frame
    void Update()
    {
        //Movement code, moves the object along the path
        transform.position = Vector3.MoveTowards(transform.position, waypoints[pathIndex], speed * Time.deltaTime);
        
        if (transform.position == waypoints[pathIndex])
            pathIndex++;
        if (transform.position == waypoints[waypoints.Count-1])
            gameObject.SetActive(false);
        

    }
}
