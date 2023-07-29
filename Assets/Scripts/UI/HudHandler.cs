using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HudHandler : MonoBehaviour
{
    private int initialScore = 0;
    private int initialLives = 3;

    private int score = 0;
    private int noOfLives = 3;

    [SerializeField] TextMeshProUGUI scoreValueText;
    [SerializeField] TextMeshProUGUI livesCountText;
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] MainMenu mainMenu;

    public void ResetHud()
    {
        score = initialScore;
        noOfLives = initialLives;

        scoreValueText.text = initialScore.ToString();
        livesCountText.text = initialLives.ToString();
    }

    //Update and set text value of current score
    public void UpdateScore()
    {
        score++;
        scoreValueText.text = score.ToString();
        Debug.Log("Score: " + score);
    }

    //Update number of lives and score
    public void UpdateLives()
    {
        noOfLives--;
        livesCountText.text = noOfLives.ToString();

        if (noOfLives < 1)
        {
            Time.timeScale = 0;

            //Update high score value when player dies
            mainMenu.UpdateHighScore(score);

            gameOverScreen.SetActive(true);
            
            //Disable Gameplay screen
            gameObject.SetActive(false);
        }
    }
}
