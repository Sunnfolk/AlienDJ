using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessStudent : MonoBehaviour
{

    public Classroom testClassroom;

    public Student troubleStudent;

    public int studentPicker = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        switch(studentPicker)
        {
            case 0:
                troubleStudent = null;
                break;
            case 1:
                troubleStudent = testClassroom.student1;
                break;
            case 2:
                troubleStudent = testClassroom.student2;
                break;
            default:
                troubleStudent = null;
                break;
        }



    }
}
