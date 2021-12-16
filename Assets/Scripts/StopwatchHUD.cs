using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopwatchHUD : MonoBehaviour
{
    private int lastMinutes = -1;
    private int lastSeconds = -1;
    private int lastCentis = -1;

    public Text currentTimeText;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetCurrentTime(float t) {
        if (t < 0) return;

        int minutes = Mathf.FloorToInt(t / 60);
        int seconds = Mathf.FloorToInt(t - minutes*60);
        int centis = Mathf.FloorToInt((t - minutes*60 - seconds)*100);

        if (centis == lastCentis && seconds == lastSeconds && minutes == lastMinutes)
            return;

        currentTimeText.text = $"{minutes}:{seconds:00}.<size=26>{centis:00}</size>";
    }

    public void Reset() {
        lastMinutes = -1;
        lastSeconds = -1;
        lastCentis = -1;
        currentTimeText.text = "0:00.<size=26>00</size>";
    }
}
