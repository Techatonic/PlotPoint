using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChooseLevel : MonoBehaviour {

    SystemVariables systemVariables;

    public Sprite[] ticks;
    public GameObject[] tickImagesForEachLevel;

    void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();

        for(int i = 0; i < tickImagesForEachLevel.Length;i++) {

            if (PlayerPrefsPlus.GetBool(SystemVariables.playerPrefsKeys[7 * System.Array.IndexOf(SystemVariables.graphNames, SystemVariables.chosenType) + i])) {
                tickImagesForEachLevel[i].SetActive(true);
                tickImagesForEachLevel[i].GetComponent<Image>().sprite = ticks[System.Array.IndexOf(SystemVariables.graphNames, SystemVariables.chosenType)];
            }

        }


    }

    public void chooseLevel(string number) {
        systemVariables.chosenArguments = LevelArguments.allArguments
            [System.Array.IndexOf(SystemVariables.graphNames, SystemVariables.chosenType)]
            [int.Parse(number)];
        SystemVariables.chosenArgument = int.Parse(number);

        systemVariables.aboutToSwitchScenes();
        SceneManager.LoadScene(SystemVariables.chosenType+" Scene");
    }


}
