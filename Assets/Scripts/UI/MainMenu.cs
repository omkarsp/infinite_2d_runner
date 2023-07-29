using UnityEngine;
using TMPro;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    int highScore = 0;

    //Called when MainMenu button is clicked
    public void SetHighScoreText()
    {
        highScoreText.text = highScore.ToString();
    }

    public void UpdateHighScore(int score)
    {
        if(score > highScore)
        {
            highScore = score;
        }
    }
}
