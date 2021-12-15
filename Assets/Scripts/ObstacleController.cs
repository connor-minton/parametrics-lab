using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private float currentTime;
    public bool isFirstPeriod;
    public ObstacleData data;

    // Start is called before the first frame update
    public virtual void Start()
    {
        currentTime = 0;
    }

    // Update is called once per frame
    public virtual void Update()
    {
        transform.position = new Vector3(x(currentTime), z(currentTime), y(currentTime));
        currentTime += Time.deltaTime;
    }

    public virtual float x(float t)
    {
        return 0;
    }

    public virtual float y(float t)
    {
        return 0;
    }

    public virtual float z(float t)
    {
        return 0.5f;
    }

    public void Reset() {
        currentTime = 0;
    }
}
