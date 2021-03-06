using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour {
    SystemVariables systemVariables;

    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
    }
    

    public void goToMenu() {

        if (Random.Range(1,11) < 5) {  // 40% chance of ad showing (always skippable)
            systemVariables.showInterstitial();
        }
        SystemVariables.chosenType = "";
        systemVariables.aboutToSwitchScenes();
        SceneManager.LoadScene("Start Scene");
    }

    public void goToSettings() {
        systemVariables.aboutToSwitchScenes();
        SceneManager.LoadScene("Settings Scene");
    }
    public void goToExplanationScene() {
        systemVariables.aboutToSwitchScenes();
        SceneManager.LoadScene("Explanation Scene");
    }
}
