using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_script : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton() {
        SceneManager.LoadScene("SampleScene");
    }


    public void QuitButton() {
        Application.Quit();
        Debug.Log("Quit");
    }


    public void ControlsButton() {
        SceneManager.LoadScene("ControlsScene");
    }


    public void GuideButton() {
        SceneManager.LoadScene("GuideScene");
    }
}
