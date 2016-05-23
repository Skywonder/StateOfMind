using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public GameObject pausePanel;
    public bool isPaused = false;
    // Use this for initialization
    void Start() {
    
    }

    // Update is called once per frame
    void Update() {
        if (isPaused)
        {
            PauseGame(true);
        }
        else
        {
            PauseGame(false);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            switchPause();
        }

    }

    void PauseGame(bool state)
    {
        if (state)
        {
            pausePanel.SetActive(true);//paused
            Time.timeScale = 0.0f;//this stops Frames from moving per update
        }

        else {
            Time.timeScale = 1.0f; //this restarts the frame at 1 frame per sec
            pausePanel.SetActive(false);//not paused
        }
    }

    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else {
            isPaused = true;
        }
    }


    public void LoadLevel(string name)
    {
        Debug.Log("Loading Start scene" + name);
        SceneManager.LoadScene(name);
    }


}
