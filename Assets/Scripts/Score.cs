using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform player;
    public Text scoreText;
    public Text highScoreText;
    private int currentScore;
    private int highScore;
    private float startZPosition;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("highscore", 0);
        highScoreText.text = highScore.ToString();
        Debug.Log("High Score Loaded: " + highScore);

        // Initialize startZPosition to the player's starting z position
        startZPosition = player.position.z;
        Debug.Log("Starting Z Position: " + startZPosition);
    }

    private void Update()
    {
        // Calculate the score based on the player's z position relative to the start position
        currentScore = Mathf.FloorToInt(player.position.z - startZPosition);

        // Ensure the score is not negative
        currentScore = Mathf.Max(0, currentScore);

        scoreText.text = currentScore.ToString();
        if (currentScore > highScore)
        {
            highScore = currentScore;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("highscore", highScore);
            PlayerPrefs.Save();
            Debug.Log("New High Score Set: " + highScore);
        }

        Debug.Log("Current Score: " + currentScore);
        Debug.Log("Player Z Position: " + player.position.z);
    }
}
// made by Sandarbh bajpai
