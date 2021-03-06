using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class WinLose : MonoBehaviour {
    SystemVariables systemVariables;
    KeyboardInput keyboardInputScript;

    [SerializeField]
    GameObject incorrectFallingPanel;
    [SerializeField]
    GameObject correctFallingPanel;

    int number;
    GameObject fallingPanel;
    bool closeOnFinish;
    int count = 0;
    bool panelIsMoving = false;

    float[] fallingPanelPosition = { 550, 1000 };
    float[] fallingPanelPositionRandom = { 600, 1000 };

    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        keyboardInputScript = GameObject.Find("Main Camera").GetComponent<KeyboardInput>();
    }

    public void checkWinLose() {
        if (!systemVariables.hasWon) {
            incorrectResponse();
        }
        else {
            correctResponse();
        }
    }

    void incorrectResponse() {
        if (!panelIsMoving) {
            incorrectFallingPanel.SetActive(true);
            incorrectFallingPanel.GetComponentInChildren<Text>().text = "Incorrect";
            number = 200;
            fallingPanel = incorrectFallingPanel;
            closeOnFinish = true;
            movePanel();
        }
    }
    void correctResponse() {
        GameObject.Find("KeyboardCanvas").SetActive(false);
        correctFallingPanel.SetActive(true);
        correctFallingPanel.GetComponentInChildren<Text>().text = "Correct";
        number = 120;
        fallingPanel = correctFallingPanel;
        closeOnFinish = false;
        movePanel();
    }

    void movePanel() {
        float alpha = 1f;
        if (fallingPanel == incorrectFallingPanel) {
            alpha = 174 / 255f;
        }
        fallingPanel.GetComponent<Image>().color = new Color(
            keyboardInputScript.chosenGraphColor[0] / 255f, 
            keyboardInputScript.chosenGraphColor[1] / 255f,
            keyboardInputScript.chosenGraphColor[2] / 255f,
            alpha
        );
        
        if (SystemVariables.chosenType == "Random") {
            fallingPanel.transform.localPosition = new Vector3(fallingPanelPositionRandom[0], fallingPanelPositionRandom[1], 0);
        }
        else {
            fallingPanel.transform.localPosition = new Vector3(fallingPanelPosition[0], fallingPanelPosition[1], 0);
        }
        InvokeRepeating("panelMoving", 0, 0.004f);
    }
    void panelMoving() {
        count++;
        if (count < number) {
            panelIsMoving = true;
            fallingPanel.transform.localPosition -= new Vector3(0, 10, 0);
        }
        else{
            CancelInvoke();
            panelIsMoving = false;
            if (closeOnFinish) {
                fallingPanel.SetActive(false);
                count = 0;
            }
        }
    }
    public void goToMenu() {
        if (Random.Range(0f, 1f) < 0.5f) { // 50% chance of ad showing - always skippable
            #if UNITY_ADS
            Advertisement.Show();
            #endif
        }
        systemVariables.aboutToSwitchScenes();
        SystemVariables.chosenType = "";
        SceneManager.LoadScene(System.Array.IndexOf
            (SystemVariables.scenes, "Start Scene"));
    }
}