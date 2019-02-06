using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdsController : MonoBehaviour
{
    public static AdsController instance;

    private const string SDK_KEY = "833lZCpTOf2QAhTISWIW5RrTsJBRfol_4IprU5Xdki2eHfaXDmZUG7dwgV8yPhoUJr-6ugVLBqbi57qcXP4IGo";

    public const int DEATHS_TILL_AD = 9;

    public int deaths;

    void Awake()
    {
        MakeSingleton();
    }



    // Start is called before the first frame update
    void Start()
    {
        deaths = 0;
        //AppLovin.SetSdkKey(SDK_KEY);
        AppLovin.InitializeSdk();
        AppLovin.SetUnityAdListener(this.gameObject.name);
     
    }

    void MakeSingleton()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


 

}
