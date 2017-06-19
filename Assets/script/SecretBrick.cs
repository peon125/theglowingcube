using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretBrick : MonoBehaviour 
{
    public GameObject arrow;
    public GameObject[] contentToHide;
    public float timeOfShowingArrow, timeOfNotShowingArrow;
    float timer;

	void Update() 
    {
        timer -= Time.deltaTime;

        arrow.SetActive(timer <= timeOfShowingArrow);

        if (timer <= 0)
            timer = timeOfShowingArrow + timeOfNotShowingArrow;
	}

    void OnTriggerEnter(Collider collider)
    {
        foreach (GameObject go in contentToHide)
            go.SetActive(false);

        GameController._instance.secretsDiscovered++;
    }
}