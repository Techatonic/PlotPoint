using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ExplanationScript : MonoBehaviour {

    SystemVariables systemVariables;

    public GameObject[] graphImages;

    void Start () {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
    }

    public void changeGraphType() {
        switch (EventSystem.current.currentSelectedGameObject.name) {
            case "Linear Graph":
                changeExplanationGraphType(0);
                break;
            case "Quadratic Graph":
                changeExplanationGraphType(1);
                break;
            case "Cubic Graph":
                changeExplanationGraphType(2);
                break;
            case "Sine Graph":
                changeExplanationGraphType(3);
                break;
            case "Cosine Graph":
                changeExplanationGraphType(4);
                break;
            case "Tangent Graph":
                changeExplanationGraphType(5);
                break;
            default:
                break;
        }
    }
    void changeExplanationGraphType(int x) {
        for(int i = 0; i < graphImages.Length; i++) {
            if (i == x) {
                graphImages[i].SetActive(true);
                continue;
            }
            graphImages[i].SetActive(false);
        }
    }
}
