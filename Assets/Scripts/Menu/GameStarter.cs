using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    [SerializeField]
    private List<TravelEvent> tEvent;
    

    public void ChangeGame()
    {
        StartCoroutine(GameIntro());

    }

    IEnumerator GameIntro()
    {

        for (int i = 0; i < tEvent.Count; i++)
        {
            Debug.Log("ON Event " + i + "Lasting for "+ tEvent[i].lastsForSeconds);
            tEvent[i].mainEvent.Invoke();
            Debug.Log("Invoked");
            yield return new WaitForSeconds(tEvent[i].lastsForSeconds);
            Debug.Log("Done Waiting");
        }
        


    }

    public void ThrowNull(string _place)
    {

        Debug.Log(_place);
    }



}
