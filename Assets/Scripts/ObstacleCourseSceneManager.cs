using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCourseSceneManager : MonoBehaviour
{
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            TogglePause();
        }
    }

    private void Pause() {
        if (!isPaused) {
            isPaused = true;
            Time.timeScale = 0;
        }
    }

    private void Unpause() {
        if (isPaused) {
            isPaused = false;
            Time.timeScale = 1;
        }
    }

    private void TogglePause() {
        if (isPaused)
            Unpause();
        else Pause();
    }
}
