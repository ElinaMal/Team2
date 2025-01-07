using UnityEngine;

public class HighScore : MonoBehaviour
{
    public TMPro.TMP_Text highScoreText;

    // Update is called once per frame
    void Update()
    {
        highScoreText.SetText("High Score: " + PlayerPrefs.GetFloat("HighScore").ToString());
    }
}
