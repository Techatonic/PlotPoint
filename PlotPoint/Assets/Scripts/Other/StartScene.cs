using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScene : MonoBehaviour {

    SystemVariables systemVariables;

    [SerializeField]
    GameObject[] graphImages;
    [SerializeField]
    GameObject[] graphTypeTexts;
    [SerializeField]
    GameObject privacyPolicyPanel;
    [SerializeField]
    GameObject leftArrow;
    [SerializeField]
    GameObject rightArrow;

    bool allowedToMove = true;
    float count = 0;

    int indexOfCurrentChoice;
    int newIndex = 0;

    float speed;
    float rateUsPopUpAmount;

    private void Start() {
        systemVariables = GameObject.Find("SystemVariablesGameObject").GetComponent<SystemVariables>();
        speed = 3;
        CheckFirstGame();
    }

    void CheckFirstGame() {
        if (PlayerPrefs.GetString("AcceptedPrivacyPolicy") == "true") {
            ContinueStartScene();
        }
        else {
            privacyPolicyPanel.SetActive(true);
            rightArrow.SetActive(false);
            leftArrow.SetActive(false);
        }
    }
    public void AcceptedPrivacyPolicy() {
        PlayerPrefs.SetString("AcceptedPrivacyPolicy", "true");
        privacyPolicyPanel.SetActive(false);
        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
        ContinueStartScene();
    }
    public void RejectedPrivacyPolicy() {
        Application.Quit();
    }
    void ContinueStartScene() {
        indexOfCurrentChoice = systemVariables.startSceneCurrentIndex;
        graphImages[indexOfCurrentChoice].SetActive(true);
        graphTypeTexts[indexOfCurrentChoice].SetActive(true);
    }


    public void moveRight() {
        Debug.Log(2);
        if (allowedToMove) {
            newIndex = (indexOfCurrentChoice + SystemVariables.startSceneOptions.Length + 1) % SystemVariables.startSceneOptions.Length;
            graphImages[newIndex].SetActive(true);
            graphImages[newIndex].transform.localPosition -= new Vector3(1000, 0, 0);
            graphTypeTexts[newIndex].SetActive(true);
            graphTypeTexts[newIndex].transform.localPosition -= new Vector3(1000, 0, 0);

            move(true);
        }
    }
    public void moveLeft() {
        if (allowedToMove) {
            newIndex = (indexOfCurrentChoice + SystemVariables.startSceneOptions.Length - 1) % SystemVariables.startSceneOptions.Length;
            graphImages[newIndex].SetActive(true);
            graphImages[newIndex].transform.localPosition += new Vector3(1000, 0, 0);
            graphTypeTexts[newIndex].SetActive(true);
            graphTypeTexts[newIndex].transform.localPosition += new Vector3(1000, 0, 0);

            move(false);
        }
    }

    void move(bool forward) {
        count = 0;
        StartCoroutine(moveABit(forward));
    }

    IEnumerator moveABit(bool forward) {
        allowedToMove = false;

        yield return new WaitForSeconds(0.001f);

        if (++count <= 125/speed) {
            graphImages[indexOfCurrentChoice].transform.localPosition -= new Vector3(0, speed*8, 0);
            graphTypeTexts[indexOfCurrentChoice].transform.localPosition -= new Vector3(0, speed*8, 0);
            if (forward) {
                graphImages[newIndex].transform.localPosition += new Vector3(speed*8, 0, 0);
                graphTypeTexts[newIndex].transform.localPosition += new Vector3(speed*8, 0, 0);
            }
            else {
                graphImages[newIndex].transform.localPosition -= new Vector3(speed*8, 0, 0);
                graphTypeTexts[newIndex].transform.localPosition -= new Vector3(speed*8, 0, 0);
            }
            StartCoroutine(moveABit(forward));
        }
        else {
            count = 0;
            allowedToMove = true;

            graphImages[indexOfCurrentChoice].transform.localPosition += new Vector3(0, 1000, 0);
            graphImages[indexOfCurrentChoice].SetActive(false);

            graphTypeTexts[indexOfCurrentChoice].transform.localPosition += new Vector3(0, 1000, 0);
            graphTypeTexts[indexOfCurrentChoice].SetActive(false);

            indexOfCurrentChoice = newIndex;
            systemVariables.startSceneCurrentIndex = indexOfCurrentChoice;
            newIndex = 0;
        }
    }

}