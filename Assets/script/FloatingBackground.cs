using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingBackground : MonoBehaviour 
{
    public float speed, offset;
    public Sprite[] backgrounds;
    float timer, delay, x, y;
    RectTransform rectangle;
    Vector2 boundaries;

    void Awake()
    {
        if (GameObject.FindGameObjectWithTag("background-notToDestroy"))
            Destroy(transform.parent.gameObject);
        else
        {
            transform.parent.tag = "background-notToDestroy";
            DontDestroyOnLoad(transform.parent.gameObject);
        }
    }

    void Start()
    {
        int i = Random.Range(0, backgrounds.Length);
        GetComponent<Image>().sprite = backgrounds[i];
        rectangle = GetComponent<RectTransform>();
        rectangle.sizeDelta = new Vector2(backgrounds[i].texture.width * 1.5f, backgrounds[i].texture.height * 1.5f);
    }
}