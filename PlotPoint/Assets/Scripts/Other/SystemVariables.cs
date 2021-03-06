using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class SystemVariables : MonoBehaviour {

    public static string[] scenes = {
        "Start Scene",
        "Linear Scene",
        "Quadratic Scene",
        "Cubic Scene",
        "Sine Scene",
        "Cosine Scene",
        "Tangent Scene",
        "Random Scene",
        "Settings Scene",
        "Levels Scene",
        "Explanation Scene",
    };
    public static string[] graphTypes = {
        "Linear Scene",
        "Quadratic Scene",
        "Cubic Scene",
        "Sine Scene",
        "Cosine Scene",
        "Tangent Scene",
        "Random Scene",
    };
    public static string[] startSceneOptions = {
        "Linear Scene",
        "Quadratic Scene",
        "Cubic Scene",
        "Sine Scene",
        "Cosine Scene",
        "Tangent Scene",
        "Random Scene",
        "Settings Scene",
        "Explanation Scene",
    };

    public static string[] graphNames = {
        "Linear",
        "Quadratic",
        "Cubic",
        "Sine",
        "Cosine",
        "Tangent"
    };

    public static Color[] graphTypeColors = {
        new Color(201,106,44),
        new Color(6,196,30),
        new Color(111,0,232),
        new Color(216,80,250),
        new Color(240,24,13),
        new Color(3,171,226),
        new Color(240,218,60),
    };

    public static string[] playerPrefsKeys = {
        "Linear0", "Linear1", "Linear2", "Linear3", "Linear4", "Linear5", "Linear6", "Linear7",
        "Quadratic0", "Quadratic1", "Quadratic2", "Quadratic3", "Quadratic4", "Quadratic5", "Quadratic6", "Quadratic7",
        "Cubic0", "Cubic1", "Cubic2", "Cubic3", "Cubic4", "Cubic5", "Cubic6", "Cubic7",
        "Sine0", "Sine1", "Sine2", "Sine3", "Sine4", "Sine5", "Sine6", "Sine7",
        "Cosine0", "Cosine1", "Cosine2", "Cosine3", "Cosine4", "Cosine5", "Cosine6", "Cosine7",
        "Tangent0", "Tangent1", "Tangent2", "Tangent3", "Tangent4", "Tangent5", "Tangent6", "Tangent7",
    };



    public static string chosenType;
    public static string randomChosenType;

    public void aboutToSwitchScenes() {
        //DontDestroyOnLoad(GameObject.Find("SystemVariablesGameObject"));
    }
    public bool hasWon = false;

    public int startSceneCurrentIndex = 0;
    public int settingsSceneCurrentIndex = 1;

    public List<int> chosenArguments;
    public static int chosenArgument;

    public static SystemVariables control;


    private InterstitialAd interstitial;

    void Start() {
        if (SceneManager.GetActiveScene().name == "Loading Scene") {
            requestInterstitial();
        }
    }

    void requestInterstitial() {
        #if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7877867112579790/1425160213";
        //string adUnitId = "ca-app-pub-3940256099942544/1033173712"; // TEST ID
        #else
            string adUnitId = "unexpected_platform";
        #endif
        interstitial = new InterstitialAd(adUnitId);
        AdRequest request = new AdRequest.Builder().Build();
        interstitial.LoadAd(request);
    }
    
    public void showInterstitial() {
        if (interstitial.IsLoaded()) {
            interstitial.Show();
            requestInterstitial();
        }
    }


}
