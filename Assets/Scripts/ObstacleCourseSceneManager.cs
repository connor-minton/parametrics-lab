using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseSceneManager : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public CanvasGroup mainMenu;

    public Obstacle1Controller o1first;
    public Obstacle1Controller o1fifth;
    public Obstacle2Controller o2first;
    public Obstacle2Controller o2fifth;
    public Obstacle3Controller o3first;
    public Obstacle3Controller o3fifth;
    public Obstacle4Controller o4first;
    public Obstacle4Controller o4fifth;
    public Obstacle5Controller o5first;
    public Obstacle5Controller o5fifth;
    public Obstacle6Controller o6first;
    public Obstacle6Controller o6fifth;

    public GameObject firstObstacles;
    public GameObject fifthObstacles;

    public GameObject character;
    public GameObject characterCamera;

    public CanvasGroup gameOverMenu;
    public GameObject winText;
    public GameObject loseText;

    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        DisablePauseMenu();
        DisableGameOverMenu();
        EnableMainMenu();
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

    public void StartFirstPeriod() {
        firstObstacles.SetActive(true);
        fifthObstacles.SetActive(false);
        o1first.Reset();
        o2first.Reset();
        o3first.Reset();
        o4first.Reset();
        o5first.Reset();
        o6first.Reset();

        DisableMainMenu();
        ResetCharacter();
    }

    public void StartFifthPeriod() {
        fifthObstacles.SetActive(true);
        firstObstacles.SetActive(false);
        o1fifth.Reset();
        o2fifth.Reset();
        o3fifth.Reset();
        o4fifth.Reset();
        o5fifth.Reset();
        o6fifth.Reset();

        DisableMainMenu();
        ResetCharacter();
    }

    public void StartMayhem() {
        fifthObstacles.SetActive(true);
        firstObstacles.SetActive(true);
        o1first.Reset();
        o2first.Reset();
        o3first.Reset();
        o4first.Reset();
        o5first.Reset();
        o6first.Reset();
        o1fifth.Reset();
        o2fifth.Reset();
        o3fifth.Reset();
        o4fifth.Reset();
        o5fifth.Reset();
        o6fifth.Reset();

        DisableMainMenu();
        ResetCharacter();
    }

    public void ReturnToMainMenu() {
        Unpause();
        DisableGameOverMenu();
        EnableMainMenu();
    }

    public void Win() {
        winText.SetActive(true);
        loseText.SetActive(false);
        EnableGameOverMenu();
    }

    public void Lose() {
        winText.SetActive(false);
        loseText.SetActive(true);
        EnableGameOverMenu();
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

    private void DisableGameOverMenu() {
        gameOverMenu.alpha = 0;
        gameOverMenu.blocksRaycasts = false;
        gameOverMenu.interactable = false;
        Cursor.visible = false;
    }

    private void EnableGameOverMenu() {
        gameOverMenu.alpha = 1;
        gameOverMenu.blocksRaycasts = true;
        gameOverMenu.interactable = true;
        Cursor.visible = true;
    }

    private void DisableMainMenu() {
        mainMenu.alpha = 0;
        mainMenu.blocksRaycasts = false;
        mainMenu.interactable = false;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void EnableMainMenu() {
        mainMenu.alpha = 1;
        mainMenu.blocksRaycasts = true;
        mainMenu.interactable = true;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    private void ResetCharacter() {
        character.SetActive(true);
        character.transform.position = new Vector3(-5, 0, 0);
        character.transform.forward = new Vector3(1, 0, 0);
        characterCamera.transform.position = new Vector3(-5, 0, 0);
        characterCamera.transform.forward = new Vector3(1, 0, 0);
    }
}
