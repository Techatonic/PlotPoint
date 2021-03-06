using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class KeyboardInput : MonoBehaviour {

    string inputString;
    GameObject canvas;
    [SerializeField]
    GameObject keyboardCanvas;
    [SerializeField]
    UpdateInputFieldsAny updateInputFieldsScript;
    DrawGraphsAny drawGraphsScript;

    public static List<int> indexOfButtons= new List<int>(new int[] { 0, 0, 0, 0, 0, 0 });
    //public static int indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based];

    List<string> names = new List<string>();

    List<string> graphTypes = new List<string>();

    SystemVariables systemVariables;

    public Color chosenGraphColor = new Color(0f, 0f, 0f);
    public GameObject[] plusOrMinus;

    public List<List<GameObject>> differentPlusMinus;
    public List<GameObject> linearPlusMinus;
    public List<GameObject> quadraticPlusMinus;
    public List<GameObject> cubicPlusMinus;
    public List<GameObject> sinePlusMinus;
    public List<GameObject> cosinePlusMinus;
    public List<GameObject> tangentPlusMinus;

    GameObject currentPlusOrMinus;

    public static List<int> inputtedValues = new List<int> { 0, 0, 0, 0 };

    void Start () {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        inputString = "";
        canvas = GameObject.Find("Canvas");
        drawGraphsScript = GameObject.Find("Graph1").GetComponent<DrawGraphsAny>();
        inputtedValues = new List<int> { 0, 0, 0, 0 };

        checkNames();

        //indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] = 0;

        foreach(string i in SystemVariables.graphTypes) {
            graphTypes.Add(i);
        }

        differentPlusMinus = new List<List<GameObject>> {
            linearPlusMinus,
            quadraticPlusMinus,
            cubicPlusMinus,
            sinePlusMinus,
            cosinePlusMinus,
            tangentPlusMinus
        };
        changeTextColor(false);
    }
    public void checkNames() {
        names.Clear();
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("inputField")) {
            names.Add(i.name);
        }
        names.Sort();
    }
    public void changeButton() {
        changeTextColor(true);
        indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] = names.IndexOf(EventSystem.current.currentSelectedGameObject.name);
        changeTextColor(false);
    }
    public void closeKeyboard() {
        chosenGraphColor = SystemVariables.graphTypeColors[graphTypes.IndexOf(SystemVariables.chosenType + " Scene")];
        drawGraphsScript.resetCorrectCount();
        drawGraphsScript.goToUpdateGraph();
        changeTextColor(true);
        //indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] = 0;
        changeTextColor(false);
    }

    public void onButtonClick() {

        if (SceneManager.GetActiveScene().name == "Random Scene") {
            currentPlusOrMinus = differentPlusMinus[updateInputFieldsScript.currentGraphNumber0Based][indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]];
        }
        else {
            currentPlusOrMinus = plusOrMinus[indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]];
        }

        string newInput = EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text;

        addInput(newInput);
        if (SceneManager.GetActiveScene().name == "Random Scene") {
            updateInputFieldsScript.differentInputFields[updateInputFieldsScript.currentGraphNumber0Based]
                [indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]].GetComponentInChildren<Text>().text = Mathf.Abs(int.Parse(inputString)).ToString();
        }
        else {
            updateInputFieldsScript.inputFields[indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]].GetComponentInChildren<Text>().text = Mathf.Abs(int.Parse(inputString)).ToString();
        }

        if (int.Parse(newInput) < 0) {
            currentPlusOrMinus.SetActive(true);
            currentPlusOrMinus.GetComponent<Text>().text = "-";
        }
        else if (indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] == 0 ||
            indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] == 1 && SystemVariables.chosenType == "Sine" ||
            indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] == 1 && SystemVariables.chosenType == "Cosine" ||
            indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] == 1 && SystemVariables.chosenType == "Tangent" ||
            indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]==1 && SystemVariables.chosenType=="Random" && 
                (updateInputFieldsScript.currentGraphNumber0Based==3 ||
                updateInputFieldsScript.currentGraphNumber0Based==4||
                updateInputFieldsScript.currentGraphNumber0Based==5)) {
            currentPlusOrMinus.SetActive(false);
        }
        else {
            currentPlusOrMinus.GetComponent<Text>().text = "+";
        }

        if (indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based] < names.Count - 1) {
            changeTextColor(true);
            indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]++;
            changeTextColor(false);
        }

        //closeKeyboard();
    }
    void addInput(string newInput) {
        inputString = newInput;
        inputtedValues[indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]] = int.Parse(newInput);
    }
    public void changeTextColor(bool toWhite) {
        Text text;
        if (SceneManager.GetActiveScene().name == "Random Scene") {
            text = updateInputFieldsScript.differentInputFields[updateInputFieldsScript.currentGraphNumber0Based]
                [indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]].GetComponentInChildren<Text>();
        }
        else {
            text = updateInputFieldsScript.inputFields[indexOfButtons[updateInputFieldsScript.currentGraphNumber0Based]].GetComponentInChildren<Text>();
        }
        if (toWhite) {
            text.color = Color.white;
        }
        else {
            if (SceneManager.GetActiveScene().name == "Random Scene") {
                chosenGraphColor = SystemVariables.graphTypeColors[updateInputFieldsScript.currentGraphNumber0Based];
            }
            else {
                chosenGraphColor = SystemVariables.graphTypeColors[graphTypes.IndexOf(SystemVariables.chosenType + " Scene")];
            }
            text.color = new Color(chosenGraphColor[0] / 255f, chosenGraphColor[1] / 255f, chosenGraphColor[2] / 255f);
        }
    }
}
    