using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoretxt_Script : MonoBehaviour
{
    public TMP_Text TwoMinuteHighScoreTXT;
    public TMP_Text FiveMinuteHighScoreTXT;
    public TMP_Text TenMinuteHighScoreTXT;
    private void Awake() 
    {
         TwoMinuteHighScoreTXT.SetText(PlayerPrefs.GetInt("TwoMinute_HighScore").ToString());
         TenMinuteHighScoreTXT.SetText(PlayerPrefs.GetInt("FiveMinute_HighScore").ToString());
         TenMinuteHighScoreTXT.SetText(PlayerPrefs.GetInt("TenMinute_HighScore").ToString());
    }
}
