using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChooseGraphTypeAny : MonoBehaviour {

    public DrawGraphsAny drawGraphsScript;
    public UpdateInputFieldsAny updateInputFieldsScript;
    SystemVariables systemVariables;

    public char exponent2 = '\u00B2';
    public char exponent3 = '\u00B3';

    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        switch (SystemVariables.chosenType) {
            case "Linear":
            case "Random":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Linear;
                break;
            case "Quadratic":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Quadratic;
                break;
            case "Cubic":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Cubic;
                break;
            case "Sine":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Sine;
                break;
            case "Cosine":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Cosine;
                break;
            case "Tangent":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Tangent;
                break;
            default:
                break;
        }
    }

    public void changeGraphType() {
        switch (EventSystem.current.currentSelectedGameObject.name) {
            case "Linear Graph":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Linear;
                SystemVariables.randomChosenType = "Linear";
                break;
            case "Quadratic Graph":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Quadratic;
                SystemVariables.randomChosenType = "Quadratic";
                break;
            case "Cubic Graph":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Cubic;
                SystemVariables.randomChosenType = "Cubic";
                break;
            case "Sine Graph":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Sine;
                SystemVariables.randomChosenType = "Sine";
                break;
            case "Cosine Graph":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Cosine;
                SystemVariables.randomChosenType = "Cosine";
                break;
            case "Tangent Graph":
                drawGraphsScript.function = DrawGraphsAny.FunctionOption.Tangent;
                SystemVariables.randomChosenType = "Tangent";
                break;
            default:
                break;
        }
        //drawGraphsScript.goToUpdateGraph();
        updateInputFieldsScript.ChangeInputPositions();
    }
}
