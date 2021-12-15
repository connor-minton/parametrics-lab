using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerListener : MonoBehaviour
{
    public GameObject player;
    public GameObject winText;
    public GameObject loseText;
    public GameObject explosion;
    public ObstacleCourseSceneManager sceneManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -3)
        {
            sceneManager.Lose();
            // loseText.SetActive(true);
            player.SetActive(false);
        }
        if (transform.position.x > 39.71)
        {
            sceneManager.Win();
            // winText.SetActive(true);
            player.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstacle")
        {
            sceneManager.Lose();
            // loseText.SetActive(true);
            player.SetActive(false);
            explosion.transform.position = transform.position;
            explosion.SetActive(true);
        }
    }
}
