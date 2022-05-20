using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    private int score = 0;

    private int Score
    {
        get{ return score; }

        set
        { 
            if (value >= 0) score = value; 
        }
    }

    void Awake()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable()
    {
        RingTrigger.OnTriggerRing += GainScore;
        RingTrigger.OnMissedRing  += LoseScore;
    }

    void OnDisable()
    {
        RingTrigger.OnTriggerRing -= GainScore;
        RingTrigger.OnMissedRing  -= LoseScore;
    }

    private void GainScore()
    {
        Score++;
        SetScore();
    }

    private void LoseScore()
    {
        Score--;
        SetScore();
    }

    private void SetScore()
    {
        scoreText.text = "Score : " + Score;
    }
}
