using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore_Script : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private int CurrentScore;
    [SerializeField] private Score_Script _ScoreScript;

     public bool LevelComplete = false;
     public List<int> LeaderBoard = new List<int>();

     private void Start() 
     {
         
     }

    private void Update() 
     {
         Score = _ScoreScript._Score;

     if (LevelComplete == true)
     {
        SaveHighScore();
     }

     if (Input.GetKeyDown(KeyCode.H))
     {
         
     }

   
     }

    private void SaveHighScore()
     {   
         CurrentScore = Score;
         LeaderBoard.Add(CurrentScore);
         LeaderBoard.Sort();
         LeaderBoard.Reverse();
         PlayerPrefs.SetInt("ScoreBoard", LeaderBoard.Count);
         PlayerPrefs.Save();
     }
}