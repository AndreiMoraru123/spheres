using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mScoreText;
    
    public int ScoreValue { get; private set; }


    private void FixedUpdate()
    {
        // Every fixed update, update the score string
        mScoreText.text = ScoreValue.ToString();
    }

    public void ResetScore()
    {
        ScoreValue = 0;
    }

    public void IncrementScore()
    {
        ScoreValue++;
    }
} 
