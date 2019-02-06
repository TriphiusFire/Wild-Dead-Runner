using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameplayController : MonoBehaviour
{

    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private Button restartGameButton;

    [SerializeField]
    private Text scoreText, pauseText;

    private int score;



    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
       
    }

    void OnEnable()
    {
        PlayerDied.endGame += PlayerDiedEndTheGame;
    }

    IEnumerator CountScore()
    {
        yield return new WaitForSeconds(0.6f);
        score++;
        scoreText.text = score + "M";
        StartCoroutine(CountScore());
    }

    void PlayerDiedEndTheGame()
    {
        if (!PlayerPrefs.HasKey("Score"))
        {
            PlayerPrefs.SetInt("Score", 0);
        }
        else
        {            
            int highscore = PlayerPrefs.GetInt("Score");

            if(highscore < score)
            {
                PlayerPrefs.SetInt("Score", score);
            }
        }
        AdsController.instance.deaths++;
        AppLovin.PreloadInterstitial();

        pauseText.text = "Game Over";
        pausePanel.SetActive(true);
        restartGameButton.onClick.RemoveAllListeners();
        restartGameButton.onClick.AddListener(()=>RestartGame());
        Time.timeScale = 0f;

        if(AdsController.instance.deaths % 3 == 0)
        {
            if (AppLovin.HasPreloadedInterstitial())
            {
                AppLovin.ShowInterstitial();
            }
            else
            {
                AdsController.instance.deaths--;
            }
            
        }
    }

    void OnDisable()
    {
        PlayerDied.endGame -= PlayerDiedEndTheGame;
    }

    public void PauseButton()
    {
        if(Time.timeScale == 1f)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
            restartGameButton.onClick.RemoveAllListeners();
            restartGameButton.onClick.AddListener(() => RestartGame());
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
        
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Gameplay");
    }

}
