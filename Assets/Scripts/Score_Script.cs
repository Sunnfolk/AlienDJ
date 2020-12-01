using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score_Script : MonoBehaviour
{
   [SerializeField] private Crowd TestCrowd; //The crowd currently being used
   public Crowdwants _Crowdwants;
   public int _Score; 
   [SerializeField] private int scorerefreshtimer = 2; //Time between calculations of the score
   public Category _currentCategory;

   //Used to calculate the points being earned
   private int point_Modifier = 1;
   public int currentpoint_increase;
   [SerializeField] public int Top_score_increase;
   [SerializeField] public int Mid_score_increase;
   [SerializeField] public int Bot_score_increase;
   private int colorbonus;
   [Tooltip("Used to change the bonus that correct color will give")]
   public int Colorbonusadd = 20; //adds value to colorbonus, Can be changed by designer
   private void Start() 
   {
     StartCoroutine(CountScoreCalc());
   }
   private void Update() 
   {
      point_Modifier = 1; //so that the point bonus wont go under 0 and into the negative

      if (Teststatic._colorshowing == Teststatic.song_playing) //finds if the track number and the color number is the same
      {
          colorbonus = Colorbonusadd;
      } else
      {
          colorbonus = 0;
      }
        //finds the catagory currently being used
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
        //function used to give the modifier its value
      Checkmodifier(_currentCategory.LowFrequency, Teststatic.LF_Playing);
      Checkmodifier(_currentCategory.HighFrequency, Teststatic.HF_Playing);
      Checkmodifier(_currentCategory.Melodic, Teststatic.MEL_Playing);
      Checkmodifier(_currentCategory.Rhythmic, Teststatic.RHY_Playing);


        //gives the current increase its value based on if it is above specific treshold
      if (_Crowdwants.Desireforcurrentsong > TestCrowd.Top)
      {
      currentpoint_increase = Top_score_increase * _currentCategory.want; 
      } else if (_Crowdwants.Desireforcurrentsong > TestCrowd.Mid)
      {
      currentpoint_increase = Mid_score_increase;
      } else {
      currentpoint_increase = Bot_score_increase;
      }
   }

   private void Checkmodifier(bool crowd, bool current) //finds what the point modifier is
   {
      if (crowd && current)
      {
          point_Modifier += 1;
      } else if (!crowd && current)
      {
          point_Modifier -= 1;
      }
   }
   private IEnumerator CountScoreCalc() //Calculates the score being given and makes sure it doesn't go under 0
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
