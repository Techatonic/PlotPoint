using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsScript : MonoBehaviour {

    SystemVariables systemVariables;

    public GameObject[] options; //Outlines not the actual options

    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        addOutline(systemVariables.settingsSceneCurrentIndex);
    }

    public void chooseDifficulty(string difficulty) {
        if (difficulty == "easy") {
            ChooseRandomPointsAny.numberOfPlotPoints = 20;
        }
        else if (difficulty == "normal") {
            ChooseRandomPointsAny.numberOfPlotPoints = 10;
        }
        else {
            ChooseRandomPointsAny.numberOfPlotPoints = 5;
        }
        string[] listOfOptions = {"easy","normal","hard"};
        systemVariables.settingsSceneCurrentIndex = System.Array.IndexOf(listOfOptions, difficulty);
        addOutline(systemVariables.settingsSceneCurrentIndex);
    }
    void addOutline(int option) {
        for (int i=0;i<options.Length;i++) {
            if (i != option) {
                if (options[i].transform.Find("Outline").GetComponent<Outline>() != null) {
                    Destroy(options[i].transform.Find("Outline").GetComponent<Outline>());
                }
            }
            else {
                if (options[i].transform.Find("Outline").GetComponent<Outline>() == null) {
                    options[i].transform.Find("Outline").gameObject.AddComponent<Outline>();
                    options[i].transform.Find("Outline").GetComponent<Outline>().effectColor = Color.yellow;
                    options[i].transform.Find("Outline").GetComponent<Outline>().effectDistance = new Vector2(6f, -8);
                }
            }
        }
    }

}
