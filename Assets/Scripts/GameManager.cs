using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI mGameOverText;

    [SerializeField] private TextMeshProUGUI mTimerText;

    [SerializeField] private Score mPlayerScore;
    
    [SerializeField] private Score mOpponentScore;

    [SerializeField] private float mGameTimeInSeconds = 60f;

    private float _mTimer;

    private bool _mGameIsPlaying = false;

    public const float RespawnHeight = 0.25f;
    
    void Start()
    {
        // set the time scale to zero to pause the game at the starts
        Time.timeScale = 0f;
        
        // set the game timer to number of seconds in a round
        _mTimer = mGameTimeInSeconds;
        
        // update the timer text
        UpdateTimer();
    }

    void FixedUpdate()
    {
        // if the game isn't playing, stop here
        if (!_mGameIsPlaying) return;
        
        // subtract the fixed delta time from the timer
        _mTimer -= Time.fixedDeltaTime;
        
        // update the timer text
        UpdateTimer();
        
        // if the timer hits zero, enter the game over state
        if (!(_mTimer <= 0)) return;
        GameOver();
        _mTimer = 0;
    }

    private void GameOver()
    {
        _mGameIsPlaying = false;
        
        // pause the game by setting the time scale to zero
        Time.timeScale = 0;
        
        // display the end game text
        string gameOverText;

        if (mPlayerScore.ScoreValue > mOpponentScore.ScoreValue)
        {
            gameOverText = "YOU WIN";
        }
        else if (mPlayerScore.ScoreValue < mOpponentScore.ScoreValue)
        {
            gameOverText = "YOU LOSE";
        }
        else
        {
            gameOverText = "TIE";
        }

        mGameOverText.text = gameOverText + "\n\nPress SPACE to Restart";
        
        // show the game over text once it has been set
        mGameOverText.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        if (_mGameIsPlaying) return;
        // unpause the game by setting the time scale to 1
        Time.timeScale = 1f;
        
        // hide the end game text
        mGameOverText.gameObject.SetActive(false);
        
        // reset the game timer
        _mTimer = mGameTimeInSeconds;
        _mGameIsPlaying = true;
    }

    private void UpdateTimer()
    {
        mTimerText.text = string.Format("{0:0}:{1:00}",
            Mathf.Floor(_mTimer / 60),
            Mathf.Floor(_mTimer % 60));
    }
}
