using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Text timeScaleText;
    public Slider timeScaleSlider;

    private float _timeScale = 1;
    public float TimeScale {
        get {
            return _timeScale;
        }
        set {
            if (value < .25f)
                _timeScale = .25f;
            else if (value > 2)
                _timeScale = 2;
            else {
                // round down to nearest .05
                _timeScale = Mathf.Floor(value * 20) / 20;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetTimeScale() {
        TimeScale = timeScaleSlider.value;
        UpdateTimeScale();
    }

    private void UpdateTimeScale() {
        timeScaleText.text = $"{TimeScale:0.00}x";
    }
}
