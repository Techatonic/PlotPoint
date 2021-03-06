using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisionAny : MonoBehaviour {
    CheckWinAny checkWinScript;
    SystemVariables systemVariables;
    public bool hit = false;


    private void Start() {
        checkWinScript = GameObject.Find("Graph1").GetComponent<CheckWinAny>();
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.name == "PlotCube(Clone)" && !hit) {
            hit = true;
            checkWinScript.correctCount++;
            checkWinScript.checkCorrectCount();
        }
    }
}