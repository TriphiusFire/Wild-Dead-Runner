using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LeaderboardsController : MonoBehaviour
{
    public static LeaderboardsController instance;
    private const string ID = "CgkIvcDb5rkVEAIQBQ";
    private Button leaderboardsBtn;


    // Use this for initialization
    void Start()
    {
        PlayGamesPlatform.Activate();
        PlayGamesPlatform.DebugLogEnabled = true;
        Social.localUser.Authenticate((bool success) =>
        {

        });
    }

    void Awake()
    {
        MakeSingleton();
        GetTheButton();

    }

    void GetTheButton()
    {
        leaderboardsBtn = GameObject.Find("Leaderboards").GetComponent<Button>();
        leaderboardsBtn.onClick.RemoveAllListeners();
        leaderboardsBtn.onClick.AddListener(()=>OpenLeaderboardsScore());
    }
    
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }


    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        //Debug.Log("Level Loaded");
        //Debug.Log(scene.name);
        //Debug.Log(mode);
        PostScore();
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }


    public void OpenLeaderboardsScore()
    {
        if (Social.localUser.authenticated)
        {
            PlayGamesPlatform.Instance.ShowLeaderboardUI(ID);
        }
        else
        {
            Social.localUser.Authenticate((bool success)=>
            {
                
            });
        }

    }

    void PostScore()
    {
        if (Social.localUser.authenticated)
        {
            Social.ReportScore(PlayerPrefs.GetInt("Score"),ID,(bool success)=>
            {
                if (success)
                {

                }
                else
                {

                }
            });
        }
        else
        {
            Debug.Log("Not logged in 2");
        }
    }
}
