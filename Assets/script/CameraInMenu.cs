using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraInMenu : MonoBehaviour 
{
    public float speed, offset;
    float timer, delay, x, y;
    public Image background;
    Vector2 boundaries;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("camera-notToDestroy"))
            Destroy(gameObject);
        else
        {
            tag = "camera-notToDestroy";
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        boundaries = new Vector2(
            background.sprite.texture.width,
            background.sprite.texture.height
        );
    }

    void LateUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            y = Random.Range(-1f, 1);
            x = Random.Range(-1f, 1f);
            delay = Random.Range(1, 4);

            timer = delay;
        }

        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + x * speed, -(boundaries.x / 2) + offset, (boundaries.x / 2) - offset),
            Mathf.Clamp(transform.position.y + y * speed, -(boundaries.y / 2) + offset, (boundaries.y / 2) - offset),
            0
        );
    }
}