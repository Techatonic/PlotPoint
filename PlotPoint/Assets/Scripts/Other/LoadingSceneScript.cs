using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingSceneScript : MonoBehaviour{


    void Start(){
        DontDestroyOnLoad(GameObject.Find("SystemVariablesGameObject"));
        SceneManager.LoadScene("Start Scene");
    }
}
