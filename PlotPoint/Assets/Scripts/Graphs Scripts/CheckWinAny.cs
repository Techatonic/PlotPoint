using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWinAny : MonoBehaviour {

    [SerializeField]
    ChooseRandomPointsAny chooseRandomPointsScript;
    SystemVariables systemVariables;
    public int correctCount = 0;

    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
    }

    public void checkCorrectCount () {
		if (correctCount==ChooseRandomPointsAny.numberOfPlotPoints) {
            systemVariables.hasWon = true;
            PlayerPrefsPlus.SetBool(SystemVariables.playerPrefsKeys[7 * (System.Array.IndexOf(SystemVariables.graphNames, SystemVariables.chosenType)) + SystemVariables.chosenArgument], true);
        }
	}
}
