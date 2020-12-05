using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreTest : MonoBehaviour
{
    private static int score;
    public int hype;

    public static float interval = 3f;
    public static bool finished;

    private void Start()
    {
        StartCoroutine(UpdateScore());
    }

    private void Update()
    {

        if (finished)
            StopCoroutine(UpdateScore());
    }

    private IEnumerator UpdateScore()
    {
        score = score + hype;
        yield return new WaitForSeconds(interval);
        StartCoroutine(UpdateScore());
    }
}
