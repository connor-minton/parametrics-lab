using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsController : MonoBehaviour
{
    public TeamInfoDisplay teamInfoPrefab;
    public Text titleText;
    public GameObject creditsContentWindow;
    public GameObject firstPeriodParent;
    public GameObject fifthPeriodParent;

    private int currentWindow;
    private CanvasGroup canvasGroup;
    private const int NUM_WINDOWS = 2;

    void Awake() {
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentWindow = 0;
        RenderWindow();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextWindow() {
        currentWindow = (currentWindow + 1) % NUM_WINDOWS;
        RenderWindow();
    }

    public void PrevWindow() {
        currentWindow = (currentWindow - 1) % NUM_WINDOWS;
        RenderWindow();
    }

    public void ShowCredits() {
        canvasGroup.alpha = 1;
        canvasGroup.interactable = true;
        canvasGroup.blocksRaycasts = true;
    }

    public void HideCredits() {
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    private void RenderWindow() {
        ClearContentWindow();
        switch (currentWindow) {
        case 0:
            DisplayFirstBlock();
            break;
        case 1:
            DisplayFifthBlock();
            break;
        }
    }

    private void ClearContentWindow() {
        foreach (Transform t in creditsContentWindow.transform) {
            Destroy(t.gameObject);
        }
    }

    private void DisplayFirstBlock() {
        titleText.text = "1st BLOCK PRECALCULUS";
        foreach (Transform t in firstPeriodParent.transform) {
            var obstacleController = t.gameObject.GetComponent<ObstacleController>();
            var teamInfoObj = Instantiate(teamInfoPrefab, creditsContentWindow.transform);
            var teamInfo = teamInfoObj.GetComponent<TeamInfoDisplay>();
            teamInfo.TeamData = obstacleController.data;
        }
    }

    private void DisplayFifthBlock() {
        titleText.text = "5th BLOCK PRECALCULUS";
        foreach (Transform t in fifthPeriodParent.transform) {
            var obstacleController = t.gameObject.GetComponent<ObstacleController>();
            var teamInfoObj = Instantiate(teamInfoPrefab, creditsContentWindow.transform);
            var teamInfo = teamInfoObj.GetComponent<TeamInfoDisplay>();
            teamInfo.TeamData = obstacleController.data;
        }
    }
}
