using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ChooseGameType : MonoBehaviour {

    SystemVariables systemVariables;

    void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
    }

    public void chooseGameType() {
        chooseStuff();
        SceneManager.LoadScene("Levels Scene");

    }
    public void chooseRandomGameType() {
        chooseStuff();
        SceneManager.LoadScene("Random Scene");
    }

    void chooseStuff() {
        Debug.Log(1);
        SystemVariables.chosenType = EventSystem.current.currentSelectedGameObject.name.Split(' ')[0];
        KeyboardInput.indexOfButtons = new List<int>(new int[] { 0, 0, 0, 0, 0, 0 });
        systemVariables.aboutToSwitchScenes();
    }

}
