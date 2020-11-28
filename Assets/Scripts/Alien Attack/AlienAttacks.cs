using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienAttacks : MonoBehaviour
{

    //Used to calculate the arc
    [Header("Arc Calculator")]
    [SerializeField]
    private int iterations = 15;
    [SerializeField]
    private Vector3 gravity = new Vector3(0.5f, 0, -0.08f);
    [SerializeField]
    private float velocityMultiplyer = 1;

    [HideInInspector] //Flying Objects use this as their flight path
    public List<Vector3> pathPoints = new List<Vector3>();

    [Header("Flying Objects")]
    [SerializeField]
    private List<GameObject> flyingObjects;

    [SerializeField] //Used for testing in editor to show path
    private bool showPath = true;


    //Visualaization of arc of spawnpoints
    public void OnDrawGizmosSelected()
    {
        if(showPath)
        {

            Gizmos.color = Color.red;
            Vector3 _startPoint = transform.position;
            Vector3 _forward = transform.forward;
            Vector3 _point = _startPoint;

            for (int i = 0; i < iterations; i++)
            {
                Gizmos.DrawWireSphere(_point, 0.2f);
                Vector3 _oldPoint = _point;
                _point += (_forward + (gravity * i)) * velocityMultiplyer;
                Gizmos.DrawLine(_oldPoint, _point);
            }

            Gizmos.DrawWireSphere(_point, 0.2f);

        }
        

    }

    void Start()
    {
        CreatePath();
        SecureFlyers();
    }

    private void SecureFlyers() //This ensures that you will never throw an error if you mess up
    {
        for (int i = 0; i < flyingObjects.Count; i++)
        {
            if (flyingObjects[i].GetComponent<FlyingObject>() == null)
            {
                flyingObjects[i].AddComponent<FlyingObject>();
                flyingObjects[i].GetComponent<FlyingObject>().attackPath = this;
            }
        }
    }

    private void CreatePath() //Create a list of all positions on the path way
    {
        pathPoints.Clear();
        Vector3 _startPoint = transform.position;
        Vector3 _forward = transform.forward;
        Vector3 _point = _startPoint;

        for (int i = 0; i < iterations; i++)
        {
            pathPoints.Add(_point);

            _point += (_forward + (gravity * i)) * velocityMultiplyer;
        }

        pathPoints.Add(_point);
    }
    
    public void LaunchObject() //Pick a random object from the object list and start flight path of it.
    {
        int random = UnityEngine.Random.Range(0, flyingObjects.Count);
        flyingObjects[random].SetActive(true);
    
    }

    void Update()
    {
        //Used for testing
        if (Input.GetKeyDown(KeyCode.Space))
            LaunchObject();

        //Used for Testing
        if(Input.GetKeyDown(KeyCode.Alpha1))
            CreatePath();

        
    }


}
