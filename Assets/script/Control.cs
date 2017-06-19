using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour 
{
    public Cube cube;
    public string[] namesOfApexButtons;
    public bool[] apexButtons, otherButtons; //otherButton - 0 is gravitation, 1 is energy, 2 is boost
    public float rotateVertical;

    public bool GetIfApexIsSelected(int index)
    {
        return (Input.GetButton(namesOfApexButtons[index]) || apexButtons[index]);
    }

    public bool GetIfOtherIsSelected(int index)
    {
        switch (index)
        {
            case 0:
                return (Input.GetButtonDown("gravitation") || otherButtons[0]);
            case 1: 
                return (Input.GetButton("energy") || otherButtons[1]);
            case 2:
                return (Input.GetButton("boost") || otherButtons[2]);
        }

        return false;
    }

    public float GetRotating()
    {
        if (rotateVertical != 0)
            return rotateVertical;
        if (Input.GetAxis("vertical") != 0)
            return Input.GetAxis("vertical");
        return 0;
    }

    public void SelectApex(int index)
    {
        apexButtons[index] = true;
    }

    public void UnselectApex(int index)
    {
        apexButtons[index] = false;
    }

    public void RotateVertical(float f)
    {
        rotateVertical = f;
    }

    public void TurnOffGravitation()
    {
        otherButtons[0] = !otherButtons[0];
    }

    public void UseEnergy()
    {
        otherButtons[1] = true;
    }

    public void UseBoost()
    {
        otherButtons[2] = true;
    }
}