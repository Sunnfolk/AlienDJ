using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DJBoothRotation : MonoBehaviour
{

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
    public void FromMenu()
    {
        //_animator.Play("DJBooth_Menu_Rot");
    }

    public void FromGame()
    {
        //_animator.Play("DJBooth_Game_Rot");
    }


    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    FromMenu();
        //}

        // if (Input.GetKeyDown(KeyCode.O))
        //{
        //    FromGame();
        //}
    }

}
