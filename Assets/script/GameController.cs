using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour 
{
    public static GameController _instance;
    public Cube player;
    public bool controlByTouch;
    public Transform objectives, secrets;
    public GameObject board;
    public UiBehaviour ui;
    public int collectedObjectves, secretsDiscovered;
    public Vector3 lastCheckpoint;

    void Awake()
    {
        Time.timeScale = 1; // when you are restarting the scene, timeScale is 0 idk why
        _instance = this;
    }

	void Start () 
    {
        lastCheckpoint = player.transform.position;
        collectedObjectves = 0;
        ui.UpdateObjectivesCounter();
	}

    public void CollectObjective()
    {
        collectedObjectves++;
        ui.UpdateObjectivesCounter();

        if (collectedObjectves == objectives.childCount && !board.activeInHierarchy)
        {
            EndOfLevel();
        }
    }

    void EndOfLevel()
    {
        board.transform.GetChild(0).GetComponent<Text>().text = (secretsDiscovered.ToString() + " / " + secrets.childCount.ToString());
        board.SetActive(true);

        if (Input.GetButtonDown("Submit"))
            Quit();
    }

    public void Quit()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void SetControlByTouch()
    {
        controlByTouch = !controlByTouch;
    }

    public void Lose()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        player.transform.eulerAngles = Vector3.zero;
        player.transform.position = lastCheckpoint;
    }
}