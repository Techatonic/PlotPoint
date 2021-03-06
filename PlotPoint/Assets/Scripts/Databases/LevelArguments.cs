using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelArguments : MonoBehaviour {

    public static List<List<int>> linearArguments = new List<List<int>>();
    public static List<List<int>> quadraticArguments = new List<List<int>>();
    public static List<List<int>> cubicArguments = new List<List<int>>();
    public static List<List<int>> sineArguments = new List<List<int>>();
    public static List<List<int>> cosineArguments = new List<List<int>>();
    public static List<List<int>> tangentArguments = new List<List<int>>();

    public static List<List<List<int>>> allArguments = new List<List<List<int>>>();

    private void Start() {

        addAllArguments();

        addLinearArguments();
        addQuadraticArguments();
        addCubicArguments();
        addSineArguments();
        addCosineArguments();
        addTangentArguments();
    }

    void addAllArguments() {
        allArguments.Add(linearArguments);
        allArguments.Add(quadraticArguments);
        allArguments.Add(cubicArguments);
        allArguments.Add(sineArguments);
        allArguments.Add(cosineArguments);
        allArguments.Add(tangentArguments);
    }

    void addLinearArguments() {
        linearArguments.Add(new List<int>(new int[] { 1, 0, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { 2, 1, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { 3, -5, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { -1, 4, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { -5, -2, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { 5, 4, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { -1, -1, 0, 0 }));
        linearArguments.Add(new List<int>(new int[] { 4, -2, 0, 0 }));
    }

    void addQuadraticArguments() {
        quadraticArguments.Add(new List<int>(new int[] { 1, 0, 0, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { 2, 3, 1, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { -2, 5, -4, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { 3, -2, 1, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { 5, 0, -5, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { 2, 2, 2, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { -4, 4, -4, 0 }));
        quadraticArguments.Add(new List<int>(new int[] { -1, -1, 1, 0 }));
    }


    void addCubicArguments() {
        cubicArguments.Add(new List<int>(new int[] { 1, 0, 0, 0 }));
        cubicArguments.Add(new List<int>(new int[] { -2, 4, 0, 0 }));
        cubicArguments.Add(new List<int>(new int[] { -1, 2, -1, 3 }));
        cubicArguments.Add(new List<int>(new int[] { 5, -5, 1, -4 }));
        cubicArguments.Add(new List<int>(new int[] { -1, 1, -1, -1 }));
        cubicArguments.Add(new List<int>(new int[] { 2, -2, -2, 3 }));
        cubicArguments.Add(new List<int>(new int[] { -2, -4, 5, 1 }));
        cubicArguments.Add(new List<int>(new int[] { -5, -5, 5, 0 }));
    }

    void addSineArguments() {
        sineArguments.Add(new List<int>(new int[] { -4, 2, -3, -5 }));
        sineArguments.Add(new List<int>(new int[] { -1, -4, 3, -1 }));
        sineArguments.Add(new List<int>(new int[] { -2, 2, -3, 5 }));
        sineArguments.Add(new List<int>(new int[] { 4, -4, 0, 3 }));
        sineArguments.Add(new List<int>(new int[] { -3, -4, -2, -2 }));
        sineArguments.Add(new List<int>(new int[] { 1, -1, -1, 1 }));
        sineArguments.Add(new List<int>(new int[] { 5, 1, -2, -5 }));
        sineArguments.Add(new List<int>(new int[] { -2, 5, -1, 2 }));
    }

    void addCosineArguments() {
        cosineArguments.Add(new List<int>(new int[] { 3, -3, 4, -4 }));
        cosineArguments.Add(new List<int>(new int[] { -3, -5, 1, 2 }));
        cosineArguments.Add(new List<int>(new int[] { -3, 3, 0, -4 }));
        cosineArguments.Add(new List<int>(new int[] { 5, 2, -5, 5 }));
        cosineArguments.Add(new List<int>(new int[] { 5, 3, 4, 4 }));
        cosineArguments.Add(new List<int>(new int[] { 1, -1, -1, -5 }));
        cosineArguments.Add(new List<int>(new int[] { -3, 2, -1, -3 }));
        cosineArguments.Add(new List<int>(new int[] { 3, -4, 1, -5 }));
    }

    void addTangentArguments() {
        tangentArguments.Add(new List<int>(new int[] { 1, 5, -5, -3 }));
        tangentArguments.Add(new List<int>(new int[] { 2, -3, 3, 2 }));
        tangentArguments.Add(new List<int>(new int[] { 2, -2, 4, -5 }));
        tangentArguments.Add(new List<int>(new int[] { -5, -5, 3, -4 }));
        tangentArguments.Add(new List<int>(new int[] { -5, 1, 4, -3 }));
        tangentArguments.Add(new List<int>(new int[] { 4, 4, 1, 0 }));
        tangentArguments.Add(new List<int>(new int[] { 4, -1, -2, 4 }));
        tangentArguments.Add(new List<int>(new int[] { -3, -2, 4, -2 }));
    }
}
