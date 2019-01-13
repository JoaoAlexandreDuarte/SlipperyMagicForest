using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool isPaused = false;
    public GameObject UI;

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
            if (!isPaused) {
                Pause();
            } else {
                Resume();
            }
        }
	}

    public void Pause() {
        UI.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume() {
        UI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Quit() {
        Application.Quit();
    }
}
