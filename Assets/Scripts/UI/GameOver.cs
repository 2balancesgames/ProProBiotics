using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOver : MonoBehaviour
{
    public Text survivalTime;
    public Text endGutStatus;

    public void UpdateSurvialTime(string survivalMsg){
        survivalTime.text = survivalMsg;
    }

    public void UpdateEndGutStat(string gutEndStatMsg){
        endGutStatus.text = gutEndStatMsg;
    }
}
