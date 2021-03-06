using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class DrawGraphsAny : MonoBehaviour {
    [Range(10, 10000)]
    public int resolution = 10000;

    private int resolutionLowerRange = 10;
    private int resolutionUpperRange = 10000;

    private int currentResolution;
    private ParticleSystem.Particle[] points;
    private Vector3[] cubePoints;

    float lineLength = 20;
    bool emptyInput = false;
    bool validInput = true;

    public enum FunctionOption {
        Linear,
        Quadratic,
        Cubic,
        Sine,
        Cosine,
        Tangent,
    }
    public FunctionOption function;

    private delegate float FunctionDelegate(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig);
    private static FunctionDelegate[] functionDelegates = {
        Linear,
        Quadratic,
        Cubic,
        Sine,
        Cosine,
        Tangent,
    };

    public float[] enteredEquationLinear = { 0, 0 };
    public float[] enteredEquationQuadratic = { 0, 0, 0 };
    public float[] enteredEquationTrig = { 0, 0, 0, 0 };
    public float[] enteredEquationCubic = { 0, 0, 0, 0 };

    public ChooseGraphTypeAny chooseGraphTypeScript;
    public UpdateInputFieldsAny updateInputFieldsScript;
    public CheckWinAny checkWinScript;
    public ChooseRandomPointsAny chooseRandomPointsScript;
    SystemVariables systemVariables;
    [SerializeField]
    WinLose winLoseScript;
    static DrawGraphsAny drawGraphsScript;
    KeyboardInput keyboardInputScript;

    public GameObject prefab;

    private void Start() {
        drawGraphsScript = this;
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        keyboardInputScript = GameObject.Find("Main Camera").GetComponent<KeyboardInput>();
    }

    private void CreatePoints() {
        if (resolution < resolutionLowerRange || resolution > resolutionUpperRange) {
            Debug.LogWarning("Grapher resolution out of bounds, resetting to minimum.", this);
            resolution = Mathf.Clamp(resolution, resolutionLowerRange, resolutionUpperRange);
        }
        if (SystemVariables.chosenType == "Tangent" || SystemVariables.randomChosenType == "Tangent") {
            resolution = 25000;
        }
        float increment = lineLength / (resolution - 1);
        cubePoints = new Vector3[resolution];
        for (int i = 0; i < resolution; i++) {
            float x = -lineLength / 2 + (i * increment);
            cubePoints[i] = new Vector3(x, 0f, 0f);
        }
    }

    public void goToUpdateGraph() {
        StartCoroutine(updateGraph());
    }
    void destroyCubes() {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("prefab");
        foreach (GameObject i in cubes) {
            Destroy(i);
        }
    }
    public IEnumerator updateGraph() {
        destroyCubes();
        yield return new WaitForEndOfFrame();
        updateInputFieldsScript.ChangeInputPositions();
        float[] equationLinear = enteredEquationLinear;
        float[] equationQuadratic = enteredEquationQuadratic;
        float[] equationTrig = enteredEquationTrig;
        float[] equationCubic = enteredEquationCubic;
        if (currentResolution != resolution || points == null) {
            CreatePoints();
        }

        FunctionDelegate f = functionDelegates[(int)function];

        checkInputs();

        if (emptyInput) {
            Debug.Log("Do stuff regarding no input");
            yield break;
        }
        if (!validInput) {
            Debug.Log("Do stuff regarding invalid input");
            yield break;
        }
        prefab.GetComponent<Renderer>().sharedMaterial.color =
            new Color(
                keyboardInputScript.chosenGraphColor[0] / 255f,
                keyboardInputScript.chosenGraphColor[1] / 255f,
                keyboardInputScript.chosenGraphColor[2] / 255f
            );
        prefab.GetComponent<Renderer>().sharedMaterial.SetColor("_EmissionColor", new Color(
            keyboardInputScript.chosenGraphColor[0] / 255f,
            keyboardInputScript.chosenGraphColor[1] / 255f,
            keyboardInputScript.chosenGraphColor[2] / 255f
        ));


        float weight = 1.0f;
        float simultaneousPoints = 100f;
        int multiplier = 0;
        while (weight > simultaneousPoints / resolution) {
            Debug.Log(weight);
            weight -= simultaneousPoints / resolution;
            for (int i = 0; i < simultaneousPoints; i++) {
                int index = (int)simultaneousPoints * multiplier + i;
                Vector3 p = cubePoints[index];
                p.y = f(p.x, equationLinear, equationQuadratic, equationCubic, equationTrig);
                if (SceneManager.GetActiveScene().name == "Random Scene") {
                    p.x -= 9;
                }
                cubePoints[index] = p;
                if (p.y >= -10 && p.y <= 10) {
                    Instantiate(prefab, p, Quaternion.identity);
                }
            }
            multiplier++;
            yield return new WaitForSeconds(0.001f);
        }

        //StartCoroutine(plotPoints(f, equationLinear, equationQuadratic, equationCubic, equationTrig));

        //Invoke("goToWinLoseScript", 0.5f);
        goToWinLoseScript();
    }
    /*
    IEnumerator plotPoints(FunctionDelegate f, float[] equationLinear, float[] equationQuadratic, float[]
            equationCubic, float[] equationTrig) {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < resolution; i++) {
            plotIndividualPoint(i, f, equationLinear, equationQuadratic, equationCubic, equationTrig);
            yield return new WaitForSeconds(0.0001f);
        }
    }

    void plotIndividualPoint(int i, FunctionDelegate f, float[] equationLinear, float[] equationQuadratic, float[]
            equationCubic, float[] equationTrig) {
        Vector3 p = cubePoints[i];
        p.y = f(p.x, equationLinear, equationQuadratic, equationCubic, equationTrig);
        if (SceneManager.GetActiveScene().name == "Random Scene") {
            p.x -= 9;
        }
        cubePoints[i] = p;
        if (p.y >= -10 && p.y <= 10) {
            Instantiate(prefab, p, Quaternion.identity);
        }
    }
    */
    void goToWinLoseScript() {
        winLoseScript.checkWinLose();
    }
    public void resetCorrectCount() {
        checkWinScript.correctCount = 0;
        systemVariables.hasWon = false;
        drawGraphsScript.emptyInput = false;
        drawGraphsScript.validInput = true;

        GameObject[] plotPoints = GameObject.FindGameObjectsWithTag("plotPoint");
        foreach (GameObject i in plotPoints) {
            i.GetComponent<CheckCollisionAny>().hit = false;
        }
    }
    private static float Linear(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig) {
        return equationLinear[0] * x + equationLinear[1];
    }
    private static float Quadratic(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig) {
        return equationQuadratic[0] * x * x + equationQuadratic[1] * x + equationQuadratic[2];
    }
    private static float Sine(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig) {
        return equationTrig[0] * Mathf.Sin(equationTrig[1] * x + equationTrig[2])
            + equationTrig[3];
    }
    private static float Cosine(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig) {
        return equationTrig[0] * Mathf.Cos(equationTrig[1] * x + equationTrig[2])
            + equationTrig[3];
    }
    private static float Tangent(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig) {
        return equationTrig[0] * Mathf.Tan(equationTrig[1] * x + equationTrig[2])
            + equationTrig[3];
    }
    private static float Cubic(float x, float[] equationLinear, float[] equationQuadratic, float[] equationCubic, float[] equationTrig) {
        return equationCubic[0] * x * x * x + equationCubic[1] * x * x + equationCubic[2] * x + equationCubic[3];
    }

    void checkInputs() {
        int count = 0;
        float[] chosenGraphEquation = { 0f, 0f, 0f, 0f };
        switch (drawGraphsScript.function) {
            case FunctionOption.Linear:
                chosenGraphEquation = enteredEquationLinear;
                break;
            case FunctionOption.Quadratic:
                chosenGraphEquation = enteredEquationQuadratic;
                break;
            case FunctionOption.Cubic:
                chosenGraphEquation = enteredEquationCubic;
                break;
            case FunctionOption.Sine:
            case FunctionOption.Cosine:
            case FunctionOption.Tangent:
                chosenGraphEquation = enteredEquationTrig;
                break;
            default:
                break;
        }

        for (int i = 0; i < chosenGraphEquation.Length; i++) {
            if (chosenGraphEquation[i] == 0) {
                count += 1;
            }
            if (chosenGraphEquation[i] < chooseRandomPointsScript.lowerBoundaries[i] ||
                    chosenGraphEquation[i] > chooseRandomPointsScript.upperBoundaries[i]) {
                drawGraphsScript.validInput = false;
            }
        }
        
        if (count == chosenGraphEquation.Length) {
            drawGraphsScript.emptyInput = true;
        }
    }

}
