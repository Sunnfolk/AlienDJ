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
            tEvent[i].mainEvent.Invoke();
            yield return new WaitForSeconds(tEvent[i].lastsForSeconds);

        }
        


    }

    public void ThrowNull(string _place)
    {

        Debug.Log(_place);
    }



}
