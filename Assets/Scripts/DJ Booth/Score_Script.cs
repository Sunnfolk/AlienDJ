using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Crowdwants))]
public class Score_Script : MonoBehaviour
{
    [SerializeField]
    private Crowd crowd; //The crowd currently being used
    private Crowdwants _Crowdwants;
    [HideInInspector]
    public int _Score; 
    [Tooltip("Time between calculations of the score")][SerializeField] 
    private int scoreRefreshTime = 2; //Time between calculations of the score
    private Category _currentCategory;

    //Used to calculate the points being earned
    private int point_Modifier = 1;
    
    private int currentpoint_increase;
    [Header("Score based on what lane the score wants is in")]
    [SerializeField] private int Top_score_increase;
    [SerializeField] private int Mid_score_increase;
    [SerializeField] private int Bot_score_increase;
    private int colorbonus;
    [Tooltip("Used to change the bonus that correct color will give")][SerializeField]
    private int Colorbonusadd = 20; //adds value to colorbonus, Can be changed by designer

    public TextMeshPro text;


    private void Start() 
    {

        _Crowdwants = GetComponent<Crowdwants>();
    }

    public void ResetScore()
    {
        _Score = 0;
    }

    public void StartCountingScore()
    {
        ResetScore();
        
        crowd = CurrentSong.selectedCrowd;
        
        StartCoroutine(CountScoreCalc());
    }

    private void Update() 
    {
        if (!GameSettings.gameInPlay)
            StopCoroutine(CountScoreCalc());

        


      point_Modifier = 1; //so that the point bonus wont go under 0 and into the negative

      if (CurrentSong.currentColor == CurrentSong.songPlaying) //finds if the track number and the color number is the same
      {
          colorbonus = Colorbonusadd;
      } else
      {
          colorbonus = 0;
      }
        //finds the catagory currently being used
      switch (CurrentSong.songPlaying)
      {
         case 0:
         _currentCategory = crowd.chill;
         break;

         case 1:
         _currentCategory = crowd.Calm;
         break;

         case 2:
         _currentCategory = crowd.Energic;
         break;

         case 3:
         _currentCategory = crowd.Aggressive;
         break;
      }
        //function used to give the modifier its value
      Checkmodifier(_currentCategory.modifier_0, CurrentSong.currentModifier_0);
      Checkmodifier(_currentCategory.modifier_1, CurrentSong.currentModifier_1);
      Checkmodifier(_currentCategory.modifier_2, CurrentSong.currentModifier_2);
      Checkmodifier(_currentCategory.modifier_3, CurrentSong.currentModifier_3);


        //gives the current increase its value based on if it is above specific treshold
      if (_Crowdwants.Desireforcurrentsong > crowd.Top)
      {
         currentpoint_increase = Top_score_increase * _currentCategory.want; 
      } 
      else if (_Crowdwants.Desireforcurrentsong > crowd.Mid)
      {
         currentpoint_increase = Mid_score_increase;
      } 
      else 
      {
         currentpoint_increase = Bot_score_increase;
      }
    }

    private void Checkmodifier(bool crowd, int current) //finds what the point modifier is
    {
       if (crowd && current == 1)
       {
          point_Modifier += 1;
       } else if (!crowd && current == 1)
       {
          point_Modifier -= 1;
       }
    }
    private IEnumerator CountScoreCalc() //Calculates the score being given and makes sure it doesn't go under 0
    {
      
        _Score += (currentpoint_increase + colorbonus) * point_Modifier;
       if (_Score < 0)
       {
          _Score = 0;
       }
        CurrentSong.gameScore = _Score;
        text.SetText(_Score.ToString());
       yield return new WaitForSeconds(scoreRefreshTime);
       StartCoroutine(CountScoreCalc());
    }
}
