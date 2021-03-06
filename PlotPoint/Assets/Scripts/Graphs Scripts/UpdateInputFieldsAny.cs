using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UpdateInputFieldsAny : MonoBehaviour {

    public GameObject[] inputFields;
    public GameObject[] inputFieldTexts;

    public List<List<GameObject>> differentInputFields;

    public List<GameObject> linearInputField;
    public List<GameObject> quadraticInputField;
    public List<GameObject> cubicInputField;
    public List<GameObject> sineInputField;
    public List<GameObject> cosineInputField;
    public List<GameObject> tangentInputField;



    public DrawGraphsAny drawGraphsScript;
    SystemVariables systemVariables;
    KeyboardInput keyboardInputScript;

    float result;

    public static GameObject currentGraph;
    public int currentGraphNumber0Based;

    GameObject[] randomGraphs;

    

    public GameObject[] graphTypes;
    public Sprite[] ticks;


    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        keyboardInputScript = GameObject.Find("Main Camera").GetComponent<KeyboardInput>();
        if (SystemVariables.chosenType == "Random") {
            randomGraphs = new GameObject[] {
                GameObject.Find("Linear Graph"),
                GameObject.Find("Quadratic Graph"),
                GameObject.Find("Cubic Graph"),
                GameObject.Find("Sine Graph"),
                GameObject.Find("Cosine Graph"),
                GameObject.Find("Tangent Graph"),
            };
            differentInputFields = new List<List<GameObject>> {
                linearInputField,
                quadraticInputField,
                cubicInputField,
                sineInputField,
                cosineInputField,
                tangentInputField
            };
            currentGraph = randomGraphs[0];
            currentGraphNumber0Based = 0;
        }
        if (SceneManager.GetActiveScene().name == "Random Scene") {
            changeGraphType(0);
        }

        ChangeInputPositions();
    }

    public void ChangeInputPositions() {
        switch (SystemVariables.chosenType) {
            case "Linear":
                drawGraphsScript.enteredEquationLinear[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationLinear[1] = KeyboardInput.inputtedValues[1];
                currentGraphNumber0Based = 0;
                break;
            case "Quadratic":
                drawGraphsScript.enteredEquationQuadratic[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationQuadratic[1] = KeyboardInput.inputtedValues[1];
                drawGraphsScript.enteredEquationQuadratic[2] = KeyboardInput.inputtedValues[2];
                currentGraphNumber0Based = 1;
                break;
            case "Cubic":
                drawGraphsScript.enteredEquationCubic[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationCubic[1] = KeyboardInput.inputtedValues[1];
                drawGraphsScript.enteredEquationCubic[2] = KeyboardInput.inputtedValues[2];
                drawGraphsScript.enteredEquationCubic[3] = KeyboardInput.inputtedValues[3];
                currentGraphNumber0Based = 2;
                break;
            case "Sine":
            case "Cosine":
            case "Tangent":
                drawGraphsScript.enteredEquationTrig[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationTrig[1] = KeyboardInput.inputtedValues[1];
                drawGraphsScript.enteredEquationTrig[2] = KeyboardInput.inputtedValues[2];
                drawGraphsScript.enteredEquationTrig[3] = KeyboardInput.inputtedValues[3];
                List<string> trigList = new List<string>(new string[] { "Sine", "Cosine", "Tangent" });
                currentGraphNumber0Based = trigList.IndexOf(SystemVariables.chosenType);
                break;
            case "Random":
                changeRandomInputPositions();
                break;
        }
    }

    public void changeRandomInputPositions() {
        switch(SystemVariables.randomChosenType) {
            case "Linear":
                //inputFields[2].SetActive(false);
                //inputFields[3].SetActive(false);
                //inputFields[0].SetActive(true);
                //inputFields[1].SetActive(true);
                changeGraphType(0);

                drawGraphsScript.enteredEquationLinear[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationLinear[1] = KeyboardInput.inputtedValues[1];

                currentGraph = GameObject.Find("Linear Graph");                
                break;
            case "Quadratic":
                /*inputFields[3].SetActive(false);
                inputFields[0].SetActive(true);
                inputFields[1].SetActive(true);
                inputFields[2].SetActive(true);
                */
                changeGraphType(1);

                drawGraphsScript.enteredEquationQuadratic[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationQuadratic[1] = KeyboardInput.inputtedValues[1];
                drawGraphsScript.enteredEquationQuadratic[2] = KeyboardInput.inputtedValues[2];

                currentGraph = GameObject.Find("Quadratic Graph");
                break;
            case "Cubic":
                //fourFields();
                changeGraphType(2);

                drawGraphsScript.enteredEquationCubic[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationCubic[1] = KeyboardInput.inputtedValues[1];
                drawGraphsScript.enteredEquationCubic[2] = KeyboardInput.inputtedValues[2];
                drawGraphsScript.enteredEquationCubic[3] = KeyboardInput.inputtedValues[3];

                currentGraph = GameObject.Find("Cubic Graph");
                break;
            case "Sine":
            case "Cosine":
            case "Tangent":
                //fourFields();
                drawGraphsScript.enteredEquationTrig[0] = KeyboardInput.inputtedValues[0];
                drawGraphsScript.enteredEquationTrig[1] = KeyboardInput.inputtedValues[1];
                drawGraphsScript.enteredEquationTrig[2] = KeyboardInput.inputtedValues[2];
                drawGraphsScript.enteredEquationTrig[3] = KeyboardInput.inputtedValues[3];

                if (SystemVariables.randomChosenType == "Sine") {
                    changeGraphType(3);
                    currentGraph = GameObject.Find("Sine Graph");
                }
                else if (SystemVariables.randomChosenType == "Cosine") {
                    changeGraphType(4);
                    currentGraph = GameObject.Find("Cosine Graph");
                }
                else {
                    changeGraphType(5);
                    currentGraph = GameObject.Find("Tangent Graph");
                }
                break;
            default:
                break;
        }
        if (currentGraph!=null) {
            currentGraph.GetComponent<Outline>().effectColor = Color.yellow;
            currentGraph.GetComponent<Outline>().effectDistance = new Vector2(5, -5);
        }
        foreach (GameObject i in randomGraphs) {
            if (i != currentGraph) {
                i.GetComponent<Outline>().effectColor = Color.black;
                if(i.name=="Linear Graph"||i.name=="Cubic Graph"||i.name=="Cosine Graph") {
                    i.GetComponent<Outline>().effectDistance = new Vector2(1.5f, -2);
                }
                else {
                    i.GetComponent<Outline>().effectDistance = new Vector2(3, -2);
                }
            }
        }
    }

    void changeGraphType(int x) {
        foreach (GameObject i in graphTypes) {
            i.SetActive(false);
        }
        graphTypes[x].SetActive(true);
        GameObject.Find("Tick").GetComponent<Image>().sprite = ticks[x];
        currentGraphNumber0Based = x;
        SystemVariables.randomChosenType = SystemVariables.graphNames[x];
        keyboardInputScript.checkNames();
        //KeyboardInput.indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] = 0;
        if (Time.timeSinceLevelLoad > 0.1f) {
            keyboardInputScript.changeTextColor(false);
        }
    }

    void fourFields() {
        inputFields[0].SetActive(true);
        inputFields[1].SetActive(true);
        inputFields[2].SetActive(true);
        inputFields[3].SetActive(true);
    }
}
