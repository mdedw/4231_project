using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controls_script : MonoBehaviour
{
    // Start is called before the first frame update
    public void BackButton() {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("Back");
    }


    public void Replay() {
        Application.Quit();
        Debug.Log("Restart");
    }
}
