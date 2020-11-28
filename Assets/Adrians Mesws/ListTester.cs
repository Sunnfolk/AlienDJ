using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ListTester : MonoBehaviour
{
    public List<GameObject> goList = new List<GameObject>();
    public List<Hand> handList = new List<Hand>();

    public Button button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Space))
        {
            
        }



    }

    void Select()
    {
        Debug.Log("HOLY SHIT IT WORKED");



    }


}
