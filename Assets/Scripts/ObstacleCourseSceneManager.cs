using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseSceneManager : MonoBehaviour
{
    public CanvasGroup pauseMenu;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        DisablePauseMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
    }

    public void Pause() {
        if (!isPaused) {
            isPaused = true;
            Time.timeScale = 0;
            EnablePauseMenu();
        }
    }

    public void Unpause() {
        if (isPaused) {
            isPaused = false;
            Time.timeScale = 1;
            DisablePauseMenu();
        }
    }

    public void Quit() {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void TogglePause() {
        if (isPaused)
            Unpause();
        else Pause();
    }

    private void DisablePauseMenu() {
        pauseMenu.alpha = 0;
        pauseMenu.blocksRaycasts = false;
        pauseMenu.interactable = false;
        Cursor.visible = false;
    }

    private void EnablePauseMenu() {
        pauseMenu.alpha = 1;
        pauseMenu.blocksRaycasts = true;
        pauseMenu.interactable = true;
        Cursor.visible = true;
    }
}
