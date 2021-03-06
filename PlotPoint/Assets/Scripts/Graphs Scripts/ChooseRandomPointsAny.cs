using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseRandomPointsAny : MonoBehaviour {

    public GameObject plotPointPrefab;

    public SystemVariables systemVariables;

    List<string> graphTypes = new List<string>(new string[] {
        "Linear",
        "Quadratic",
        "Cubic",
        "Sine",
        "Cosine",
        "Tangent",
    });
    public static int numberOfPlotPoints = 10;

    List<Vector3> plotPoints = new List<Vector3>();
    List<float> randomXPlots = new List<float>();

    float xLowerBound = -10f;
    float xUpperBound = 10f;

    [SerializeField]
    string choice;

    int a, b, c, d;

    int badYValuesCount = 0;

    int testCount = 0;

    public int[] lowerBoundaries = { -5, -5, -5, -5 };
    public int[] upperBoundaries = { 5, 5, 5, 5 };

    List<bool> aAllowedToBeZero = new List<bool> { false, false, false, false, false, false };
    List<bool> bAllowedToBeZero = new List<bool> { true, true, true, false, false, false };
    List<bool> cAllowedToBeZero = new List<bool> { true, true, true, true, true, true };
    List<bool> dAllowedToBeZero = new List<bool> { true, true, true, true, true, true };
    List<List<bool>> possibilities = new List<List<bool>>();

    void Start () {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        SystemVariables.chosenType = SceneManager.GetActiveScene().name.Split(' ')[0];
        switch (SystemVariables.chosenType) {
            case "Linear":
            case "Quadratic":
            case "Cubic":
            case "Sine":
            case "Cosine":
            case "Tangent":
                choice = SystemVariables.chosenType;
                break;
            default:
                choice = graphTypes[UnityEngine.Random.Range(0, graphTypes.Count - 2)];
                break;
        }
        possibilities.Add(aAllowedToBeZero);
        possibilities.Add(bAllowedToBeZero);
        possibilities.Add(cAllowedToBeZero);
        possibilities.Add(dAllowedToBeZero);

        if (SceneManager.GetActiveScene().name == "Random Scene") {
            pickArguments();
        }
        else {
            getArguments();
            pickXValues();
        }
        Debug.Log("A: " + a.ToString() + " B: " + b.ToString() + " C: " + c.ToString() + " D: " + d.ToString());

        for (int i = 0; i < numberOfPlotPoints; i++) {
            if (SceneManager.GetActiveScene().name == "Random Scene") {
                plotPoints[i] -= new Vector3(9, 0, 0);
            }
            GameObject newObject = Instantiate(plotPointPrefab, plotPoints[i], Quaternion.identity);
        }
    }
    void getArguments() {
        a = systemVariables.chosenArguments[0];
        b = systemVariables.chosenArguments[1];
        c = systemVariables.chosenArguments[2];
        d = systemVariables.chosenArguments[3];
    }
    void pickArguments() {
        while (true) {
            a = UnityEngine.Random.Range(lowerBoundaries[0], upperBoundaries[0] + 1);
            b = UnityEngine.Random.Range(lowerBoundaries[1], upperBoundaries[1] + 1);
            c = UnityEngine.Random.Range(lowerBoundaries[2], upperBoundaries[2] + 1);
            d = UnityEngine.Random.Range(lowerBoundaries[3], upperBoundaries[3] + 1);
            int[] arguments = { a, b, c, d };

            bool works = true;
            for (int i = 0; i < arguments.Length; i++) {
                if (arguments[i] == 0 && possibilities[i][graphTypes.IndexOf(choice)] == false) {
                    works = false;
                }
            }
            if (works) {
                break;
            }
        }

        if (choice == "Cubic") {
            int differentiatedA = 3 * a;
            int differentiatedB = 2 * b;
            int differentiatedC = c;

            float x1 = (-differentiatedB +
                        Mathf.Sqrt(Mathf.Pow(differentiatedB, 2) - 4 * differentiatedA * differentiatedC))
                        / (2 * differentiatedA);
            float x2 = (-differentiatedB -
                        Mathf.Sqrt(Mathf.Pow(differentiatedB, 2) - 4 * differentiatedA * differentiatedC))
                        / (2 * differentiatedA);

            float y1 = a * x1 * x1 * x1 + b * x1 * x1 + c * x1 + d;
            float y2 = a * x2 * x2 * x2 + b * x2 * x2 + c * x2 + d;

            if (y1 >= -10 && y1 <= 10 && y2 >= -10 && y2 <= 10) {
                pickXValues();
            }
            else {
                pickArguments();
            }
        }
        else {
            pickXValues();
        }
    }
    void pickXValues() {
        if (choice == "Linear" && a!=0) {
            xLowerBound = Mathf.Clamp((-10 - b) / a, -10f, 10f);
            xUpperBound = Mathf.Clamp((10 - b) / a, -10f, 10f);
        }
        if (choice == "Quadratic") {
            setLimitsQuadratic();
        }
        for (int i = 0; i < numberOfPlotPoints; i++) {
            randomXPlots.Add(UnityEngine.Random.Range(xLowerBound, xUpperBound));
        }
        getYValues();
    }
    void getYValues() {
        badYValuesCount = 0;
        switch (choice) {
            case "Linear":
                Debug.Log(a + "x+" + b);
                for (int i = 0; i < numberOfPlotPoints; i++) {
                    float y = a * randomXPlots[i] + b;

                    plotPoints.Add(new Vector3(randomXPlots[i], y, 0));
                    checkYValuesLinearCubic(y, i);
                }
                break;
            case "Quadratic":
                Debug.Log(a + "x" + '\u00B2'.ToString() + "+" + b + "x+" + c);
                for (int i = 0; i < numberOfPlotPoints; i++) {
                    float x = randomXPlots[i];
                    float y = a * x * x + b * x + c;
                    plotPoints.Add(new Vector3(x, y, 0));
                }
                break;
            case "Cubic":
                Debug.Log(a + "x" + '\u00B3'.ToString() + "+" + b + "x" + '\u00B2'.ToString() + "+" + c + "x+" + d);
                for (int i = 0; i < numberOfPlotPoints; i++) {
                    float x = randomXPlots[i];
                    float y = a * x * x * x + b * x * x + c * x + d;
                    plotPoints.Add(new Vector3(x, y, 0));
                    checkYValuesLinearCubic(y, i);
                }
                break;
            case "Sine":
                Debug.Log(a + "sin(" + b + "x+" + c + ")+" + d);
                for(int i = 0; i < numberOfPlotPoints; i++) {
                    float x = randomXPlots[i];
                    float y = a * Mathf.Sin(b * x + c) + d;
                    plotPoints.Add(new Vector3(x, y, 0));
                }
                break;
            case "Cosine":
                Debug.Log(a + "cos(" + b + "x+" + c + ")+" + d);
                for (int i = 0; i < numberOfPlotPoints; i++) {
                    float x = randomXPlots[i];
                    float y = a * Mathf.Cos(b * x + c) + d;
                    plotPoints.Add(new Vector3(x, y, 0));
                }
                break;
            case "Tangent":
                Debug.Log(a + "tan(" + b + "x+" + c + ")+" + d);
                for (int i = 0; i < numberOfPlotPoints; i++) {
                    float x = randomXPlots[i];
                    float y = a * Mathf.Tan(b * x + c) + d;
                    checkYValuesTangent(y, i);
                    plotPoints.Add(new Vector3(x, y, 0));
                }
                break;
            default:
                break;
        }
        if (badYValuesCount > 0) {
            randomXPlots.Clear();
            plotPoints.Clear();
            pickXValues();
        }
    }

    void checkYValuesTangent(float y, int i) {
        if (y > 10) {
            badYValuesCount++;
        }
    }

    void setLimitsQuadratic() {
        float discriminant = Mathf.Pow(b, 2f) - 4f * a * c;
        float newDiscriminant;
        if (a > 0) {
            newDiscriminant = Mathf.Pow(b, 2f) - 4f * a * (c - 10);
        }
        else if(a<0) {
            newDiscriminant = Mathf.Pow(b, 2f) - 4f * a * (c + 10);
        }
        else {
            return;
        }

        float x1;
        float x2;

        x1 = (-b + Mathf.Sqrt(newDiscriminant)) / (2 * a);
        x2 = (-b - Mathf.Sqrt(newDiscriminant)) / (2 * a);

        xUpperBound = Mathf.Max(x1, x2);
        xLowerBound = Mathf.Min(x1, x2);
    }
    void checkYValuesLinearCubic(float y, int i) {
        if (y > 10 || y < -10) {
            badYValuesCount++;
            if (a > 0) {
                if (y > 10 && Mathf.Abs(randomXPlots[i]) < Mathf.Abs(xUpperBound)) {
                    xUpperBound = randomXPlots[i];
                    //Debug.Log("Upper: " + xUpperBound);
                }
                else if (y < -10 && Mathf.Abs(randomXPlots[i]) < Mathf.Abs(xLowerBound)) {
                    xLowerBound = randomXPlots[i];
                    //Debug.Log("Lower: " + xLowerBound);
                }
            }
            else {
                if (y > 10 && Mathf.Abs(randomXPlots[i]) < Mathf.Abs(xLowerBound)) {
                    xLowerBound = randomXPlots[i];
                    //Debug.Log("Lower: " + xLowerBound);
                }
                else if (y < -10 && Mathf.Abs(randomXPlots[i]) < Mathf.Abs(xUpperBound)) {
                    xUpperBound = randomXPlots[i];
                    //Debug.Log("Upper: " + xUpperBound);
                }
            }
        }
    }
}
