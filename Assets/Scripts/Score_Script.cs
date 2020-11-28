using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Script : MonoBehaviour
{
   [SerializeField] private Crowd TestCrowd;
   public Crowdwants _Crowdwants;
   public int _Score;
   [SerializeField] private int scorerefreshtimer = 2;
   public Category _currentCategory;
   [SerializeField] public int point_Modifier = 1;
   [SerializeField] public int currentpoint_increase;
   [SerializeField] public int Top_score_increase;
   [SerializeField] public int Mid_score_increase;
   [SerializeField] public int Bot_score_increase;
   private int colorbonus;
   [SerializeField] private int Colorbonusvalue;
   private void Start() 
   {
     StartCoroutine(CountScoreCalc());
   }
   private void Update() 
   {
      point_Modifier = 1;

      if (Teststatic._colorshowing == Teststatic.song_playing)
      {
          colorbonus = 20;
      } else
      {
          colorbonus = 0;
      }

      switch (Teststatic.song_playing)
      {
         case 0:
         _currentCategory = TestCrowd.chill;
         break;

         case 1:
         _currentCategory = TestCrowd.Calm;
         break;

         case 2:
         _currentCategory = TestCrowd.Energic;
         break;

         case 3:
         _currentCategory = TestCrowd.Aggressive;
         break;
      }

      Checkmodifier(_currentCategory.LowFrequency, Teststatic.LF_Playing);
      Checkmodifier(_currentCategory.HighFrequency, Teststatic.HF_Playing);
      Checkmodifier(_currentCategory.Melodic, Teststatic.MEL_Playing);
      Checkmodifier(_currentCategory.Rhythmic, Teststatic.RHY_Playing);

      if (_Crowdwants.Desireforcurrentsong > TestCrowd.Top)
      {
      currentpoint_increase = Top_score_increase; 
      } else if (_Crowdwants.Desireforcurrentsong > TestCrowd.Mid)
      {
      currentpoint_increase = Mid_score_increase;
      } else {
      currentpoint_increase = Bot_score_increase;
      }
   }

   private void Checkmodifier(bool crowd, bool current)
   {
      if (crowd && current)
      {
          point_Modifier += 1;
      } else if (!crowd && current)
      {
          point_Modifier -= 1;
      }
   }
   private IEnumerator CountScoreCalc()
   {
      if (point_Modifier < 1)
      {
          point_Modifier = 1;
      }
      _Score += (currentpoint_increase + colorbonus) * point_Modifier;
      if (_Score < 0)
      {
          _Score = 0;
      }
      yield return new WaitForSeconds(scorerefreshtimer);
      StartCoroutine(CountScoreCalc());
   }
}
