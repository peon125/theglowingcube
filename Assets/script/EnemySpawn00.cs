using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn00 : MonoBehaviour 
{
    public GameObject enemy;
    public float delay;
    Vector3 whereToSpawn;
    float timer;

    void Start()
    {
        whereToSpawn = transform.position - new Vector3(0, enemy.transform.localScale.y - 0.1f, 0);
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
            enemy.transform.position = whereToSpawn;
            enemy.SetActive(true);
            timer = delay;
        }
    }
}