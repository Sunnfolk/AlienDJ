using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore_Script : MonoBehaviour
{
    [SerializeField] private int Score;
    [SerializeField] private Score_Script _ScoreScript;
     public bool LevelComplete = false;
     private bool IsTwoMinute = false;
     private bool IsFiveMinute = false;
     private bool IsTenMinute = false;
     public int TwoMinuteHighScore;
     public int FiveMinuteHighScore;
     public int TenMinuteHighScore;
     

     private void OnAwake() 
     {
         if (GameSettings.gameDuration == 2)
         {
             IsTwoMinute = true;
         }
         if (GameSettings.gameDuration == 5)
         {
             IsFiveMinute = true;
         }
         if (GameSettings.gameDuration == 10)
         {
             IsTenMinute = true;
         }
     }

    private void Update() 
     {
         
         Score = _ScoreScript._Score;
         TwoMinuteHighScore = PlayerPrefs.GetInt("TwoMinute_HighScore");
         FiveMinuteHighScore = PlayerPrefs.GetInt("FiveMinute_HighScore");
         TenMinuteHighScore = PlayerPrefs.GetInt("TenMinute_HighScore");

        if (LevelComplete == true && Score > TwoMinuteHighScore && IsTwoMinute == true)
        {
             SaveHighScoreTwo();
        }
        if (LevelComplete == true && Score > FiveMinuteHighScore && IsFiveMinute == true)
        {
             SaveHighScoreFive();
        }
        if (LevelComplete == true && Score > TenMinuteHighScore && IsTenMinute == true)
        {
             SaveHighScoreTen();
        }
     }

    private void SaveHighScoreTwo()
     {   
         TwoMinuteHighScore = Score;
         PlayerPrefs.SetInt("TwoMinute_HighScore", TwoMinuteHighScore);
     }

    private void SaveHighScoreFive()
     {
         FiveMinuteHighScore = Score;
         PlayerPrefs.SetInt("FiveMinute_HighScore", FiveMinuteHighScore);
     }
    private void SaveHighScoreTen()
     {
         TenMinuteHighScore = Score;
         PlayerPrefs.SetInt("TenMinute_HighScore", TenMinuteHighScore);
     }
    public void ResetScores()
     {
         PlayerPrefs.DeleteAll();
     }
}