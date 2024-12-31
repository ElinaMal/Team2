using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Mathematics.math;

public class EnemyNumberTracker : MonoBehaviour
{
    public int enemyCounter = 0;
    public int undeadCounter = 0;
    public float timePassed = 0;
    public float trueTime;
    public TMPro.TMP_Text scoreText;

    void Update() 
    {
        timePassed = Time.time;
        trueTime = (Mathf.Round(timePassed * 100)) / 100;
        scoreText.SetText(trueTime.ToString());
    }
}
