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
    private float highScore = 0;
    public float levelUpScore = 0;

    void Update() 
    {
        timePassed += Time.deltaTime;
        levelUpScore += Time.deltaTime;
        trueTime = (Mathf.Round(timePassed * 100)) / 100;
        scoreText.SetText(trueTime.ToString());
        ScoreSave(trueTime);

        if (levelUpScore > 30)
        {
            levelUpScore = 0;
        }
    }

    void ScoreSave(float score)
    {
        highScore = PlayerPrefs.GetFloat("HighScore");

        if (highScore < score)
        {
            PlayerPrefs.SetFloat("HighScore", score);
            PlayerPrefs.Save();
        }
    }
}
