using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiBehaviour : MonoBehaviour 
{
    public GameObject[] UiStuffToDisable;
    public Transform player, gravitationButton;
    public Color regularColorOfBar, errorColorOfBar, energyBankFullColor;
    public GameObject pauseBoard;
    public RectTransform energyBar;
    public Text chargesText, objectivesCounter, graphicsText;
    public float speedOfChargingEnergy;
    float currentValue, maxValueOfEnergyBar;
    bool energyError, gravitationOn, lowGraphics;

    void Start()
    {
        maxValueOfEnergyBar = energyBar.rect.width;
        currentValue = maxValueOfEnergyBar;
        chargesText.text = (player.GetComponent<Cube>().chargesOfEnergy).ToString();

//        if (Application.platform != RuntimePlatform.Android)
//            foreach (GameObject gameObject in UiStuffToDisable)
//                gameObject.SetActive(false);

        gravitationOn = true;
        lowGraphics = false;
    }

    void Update()
    {
        Energy();

        if (!GameController._instance.controlByTouch)
        {
            if (Input.GetButtonDown("pause"))
                Pause();

            if (pauseBoard.activeInHierarchy)
            {
                if (Input.GetButtonDown("quit"))
                    QuitLevel();

                if (Input.GetButtonDown("restart"))
                    RestartLevel();
            }
        }
    }

    void Energy()
    {
        if (player.GetComponent<Cube>().chargesOfEnergy > 0)
            currentValue = Mathf.Clamp(currentValue + Time.deltaTime * speedOfChargingEnergy, 0, maxValueOfEnergyBar);

        energyBar.sizeDelta = new Vector2(currentValue, energyBar.rect.height);

        if (energyError)
        {
            energyBar.GetComponent<Image>().color = Color.Lerp(energyBar.GetComponent<Image>().color, regularColorOfBar, 0.01f);

            if (energyBar.GetComponent<Image>().color == regularColorOfBar)
                energyError = false;
        }
    }

    public void Pause()
    {
        pauseBoard.SetActive(!pauseBoard.activeInHierarchy);
        player.GetComponent<Cube>().isPaused = pauseBoard.activeInHierarchy;

        if (!pauseBoard.activeInHierarchy)
        {
            Time.timeScale = 1;
            return;
        }

        Time.timeScale = 0;
    }

    public void EnergyCollected(bool collected)
    {
        if (collected)
            chargesText.text = (player.GetComponent<Cube>().chargesOfEnergy + 1).ToString();
        else
            energyBar.GetComponent<Image>().color = energyBankFullColor;

        energyError = !collected;
    }

    public bool CanIUseEnergyYet()
    {
        if (currentValue == maxValueOfEnergyBar)
        {
            currentValue = 0;
            chargesText.text = (player.GetComponent<Cube>().chargesOfEnergy - 1).ToString();

            return true;
        }

        energyBar.GetComponent<Image>().color = errorColorOfBar;
        energyError = true;

        return false;
    }

    public void ChangeGravitation()
    {
        gravitationOn = !gravitationOn;

        if (gravitationOn)
        {
            gravitationButton.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
            gravitationButton.GetChild(0).GetComponent<Text>().color = new Color(0, 0, 0, 0.5f);
        }
        else
        {
            gravitationButton.GetComponent<Image>().color = new Color(0, 0, 0, 0.5f);
            gravitationButton.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 0.5f);
        }
    }

    public void UpdateObjectivesCounter()
    {
        objectivesCounter.text = GameController._instance.collectedObjectves + " / " + GameController._instance.objectives.childCount;
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("levelSelect");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ChangeGraphics()
    {
        lowGraphics = !lowGraphics;

        if (lowGraphics)
        {
            Camera.main.renderingPath = RenderingPath.VertexLit;
            graphicsText.text = "Low graphics";
            graphicsText.color = new Color((float)45 / 255, (float)45 / 255, (float)45 / 255, 1);
            graphicsText.transform.parent.GetComponent<Image>().color = new Color((float)200 / 255, (float)200 / 255, (float)200 / 255, 1);
        }
        else
        {
            Camera.main.renderingPath = RenderingPath.UsePlayerSettings;
            graphicsText.text = "High graphics";
            graphicsText.color = new Color((float)200 / 255, (float)200 / 255, (float)200 / 255, 1);
            graphicsText.transform.parent.GetComponent<Image>().color = new Color((float)45 / 255, (float)45 / 255, (float)45 / 255, 1);
        }
    }
}