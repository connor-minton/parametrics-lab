using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityStandardAssets.Cameras;

public class ObstacleCourseSceneManager : MonoBehaviour
{
    public CanvasGroup pauseMenu;
    public CanvasGroup mainMenu;
    public CanvasGroup creditsMenu;
    public CanvasGroup settingsMenu;

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

    public GameObject explosionParent;

    public StopwatchHUD stopwatch;

    public Settings settings;

    private bool isPaused = false;

    public bool IsGameOver { get; private set; }

    private enum GameMode {
        FirstBlock,
        FifthBlock,
        Mayhem
    }

    private GameMode gameMode;

    private float currentTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = true;
        stopwatch.Reset();
        DisablePauseMenu();
        DisableGameOverMenu();
        DisableCreditsMenu();
        DisableSettingsMenu();
        EnableMainMenu();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGameOver && Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
        if (!IsGameOver && !isPaused) {
            currentTime += Time.deltaTime;
            stopwatch.SetCurrentTime(currentTime);
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
        gameMode = GameMode.FirstBlock;

        firstObstacles.SetActive(true);
        fifthObstacles.SetActive(false);
        o1first.Reset();
        o2first.Reset();
        o3first.Reset();
        o4first.Reset();
        o5first.Reset();
        o6first.Reset();

        o1first.TimeScale = settings.TimeScale;
        o2first.TimeScale = settings.TimeScale;
        o3first.TimeScale = settings.TimeScale;
        o4first.TimeScale = settings.TimeScale;
        o5first.TimeScale = settings.TimeScale;
        o6first.TimeScale = settings.TimeScale;

        DisableMainMenu();
        ResetCharacter();
    }

    public void StartFifthPeriod() {
        gameMode = GameMode.FifthBlock;

        fifthObstacles.SetActive(true);
        firstObstacles.SetActive(false);
        o1fifth.Reset();
        o2fifth.Reset();
        o3fifth.Reset();
        o4fifth.Reset();
        o5fifth.Reset();
        o6fifth.Reset();

        o1fifth.TimeScale = settings.TimeScale;
        o2fifth.TimeScale = settings.TimeScale;
        o3fifth.TimeScale = settings.TimeScale;
        o4fifth.TimeScale = settings.TimeScale;
        o5fifth.TimeScale = settings.TimeScale;
        o6fifth.TimeScale = settings.TimeScale;

        DisableMainMenu();
        ResetCharacter();
    }

    public void StartMayhem() {
        gameMode = GameMode.Mayhem;

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

        o1first.TimeScale = settings.TimeScale;
        o2first.TimeScale = settings.TimeScale;
        o3first.TimeScale = settings.TimeScale;
        o4first.TimeScale = settings.TimeScale;
        o5first.TimeScale = settings.TimeScale;
        o6first.TimeScale = settings.TimeScale;

        o1fifth.TimeScale = settings.TimeScale;
        o2fifth.TimeScale = settings.TimeScale;
        o3fifth.TimeScale = settings.TimeScale;
        o4fifth.TimeScale = settings.TimeScale;
        o5fifth.TimeScale = settings.TimeScale;
        o6fifth.TimeScale = settings.TimeScale;

        DisableMainMenu();
        ResetCharacter();
    }

    public void EnterCredits() {
        EnableCreditsMenu();
    }

    public void EnterSettings() {
        EnableSettingsMenu();
    }

    public void ReturnToMainMenu() {
        Unpause();
        DisableGameOverMenu();
        DisableCreditsMenu();
        EnableMainMenu();
    }

    public void SaveSettings() {
        DisableSettingsMenu();
        EnableMainMenu();
    }

    public void Restart() {
        Unpause();
        DisableGameOverMenu();
        stopwatch.Reset();

        switch (gameMode) {
        case GameMode.FirstBlock:
            StartFirstPeriod();
            break;
        case GameMode.FifthBlock:
            StartFifthPeriod();
            break;
        case GameMode.Mayhem:
            StartMayhem();
            break;
        default:
            StartFirstPeriod();
            break;
        }
    }

    public void Win() {
        IsGameOver = true;
        characterCamera.GetComponent<FreeLookCam>().enabled = false;
        winText.SetActive(true);
        loseText.SetActive(false);
        EnableGameOverMenu();
        SaveRecord();
    }

    public void Lose(ObstacleData data) {
        IsGameOver = true;
        characterCamera.GetComponent<FreeLookCam>().enabled = false;
        winText.SetActive(false);
        loseText.SetActive(true);
        var loseTextText = loseText.GetComponent<UnityEngine.UI.Text>();
        if (data == null) {
            loseTextText.text = "You can't go that way, silly!";
        }
        else {
            string hexcode = ColorUtility.ToHtmlStringRGBA(data.color);
            string blockName = data.isFirstPeriod ? " (1st Block)" : " (5th Block)";
            loseTextText.text = $"Destroyed by\n<color=#{hexcode}>{data.teamName}{(gameMode == GameMode.Mayhem ? blockName : "")}</color>!";
        }
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

    private void DisableCreditsMenu() {
        creditsMenu.alpha = 0;
        creditsMenu.blocksRaycasts = false;
        creditsMenu.interactable = false;
    }

    private void EnableCreditsMenu() {
        creditsMenu.alpha = 1;
        creditsMenu.blocksRaycasts = true;
        creditsMenu.interactable = true;
    }

    private void DisableSettingsMenu() {
        settingsMenu.alpha = 0;
        settingsMenu.blocksRaycasts = false;
        settingsMenu.interactable = false;
    }

    private void EnableSettingsMenu() {
        settingsMenu.alpha = 1;
        settingsMenu.blocksRaycasts = true;
        settingsMenu.interactable = true;
    }

    private void ResetCharacter() {
        string recordKey = GetRecordKey(gameMode);
        if (PlayerPrefs.HasKey(recordKey))
            stopwatch.SetBestTime(PlayerPrefs.GetFloat(recordKey));
        else
            stopwatch.SetBestTime(-1);

        characterCamera.GetComponent<FreeLookCam>().enabled = true;

        currentTime = 0;
        IsGameOver = false;
        character.SetActive(true);
        character.transform.position = new Vector3(-5, 0, 0);
        character.transform.forward = new Vector3(1, 0, 0);
        characterCamera.transform.position = new Vector3(-5, 0, 0);
        characterCamera.transform.forward = new Vector3(1, 0, 0);
        foreach (Transform t in explosionParent.transform) {
            // should only be one explosion if one exists
            Destroy(t.gameObject);
        }
    }

    private string GetRecordKey(GameMode gm) {
        switch (gm) {
        case GameMode.FirstBlock:
            return "FirstBlockRecord";
        case GameMode.FifthBlock:
            return "FifthBlockRecord";
        case GameMode.Mayhem:
            return "MayhemRecord";
        default:
            return "FirstBlockRecord";
        }
    }

    private void SaveRecord() {
        string key = GetRecordKey(gameMode);
        if (!PlayerPrefs.HasKey(key) || PlayerPrefs.GetFloat(key) > currentTime) {
            stopwatch.SetBestTime(currentTime);
            PlayerPrefs.SetFloat(key, currentTime);
        }
    }
}
