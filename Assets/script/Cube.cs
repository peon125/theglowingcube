using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class Cube : MonoBehaviour 
{
    public UiBehaviour ui;
    public Control controls;
    public Apex[] apexes;
    public Transform selectedApex;
    public float speed, boostPower;
    public int chargesOfEnergy, maxChargesOfEnergy;
    public bool isPaused;
    public List<Transform> collidingEdges;
    Rigidbody _rigidbody;
    Vector3 position;
    CameraMovement _camera;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        selectedApex = null;
        controls = transform.parent.GetComponent<Control>();
        position = transform.position;
        _camera = Camera.main.GetComponent<CameraMovement>();
    }

    void Update() 
    {
        if (isPaused)
            return;
        
        Rotate();

        if (controls.GetIfOtherIsSelected(0))
            Gravitation();

        Energy();

        selectedApex = null;
    }

    void LateUpdate()
    {
        if (position!=transform.position)
        {
            _camera.ComeOnCatchUp();
            position = transform.position;
        }
    }

    void Rotate()
    {
        int selectedApexes = 0;

        for (int i = 0; i < controls.apexButtons.Length; i++)
        {
            if (controls.GetIfApexIsSelected(i))
            {
                if (apexes[i].isGrounded)
                {
                    selectedApexes++;
                    selectedApex = apexes[i].transform;
                    apexes[i].Selected(true);
                }
                else
                    apexes[i].Error();
            }
            else
                apexes[i].Selected(false);
        }

        if (selectedApexes == 1)
        {
            transform.RotateAround(
                selectedApex.GetComponent<Apex>().relatedEdge.transform.position,
                selectedApex.position - selectedApex.GetComponent<Apex>().relatedApex.transform.position,
                speed * Time.deltaTime * controls.GetRotating()
            );

            GameObject brick = selectedApex.GetComponent<Apex>().brick;

            if(brick.GetComponent<Rigidbody>())
            {
               Rigidbody rb = brick.GetComponent<Rigidbody>();

                _rigidbody.velocity = rb.velocity;
                _rigidbody.angularVelocity = rb.angularVelocity;
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
            }
        }
        else
        {
            _rigidbody.drag = 0;
            _rigidbody.angularDrag = 0;
        }

        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    void Gravitation()
    {
        _rigidbody.useGravity = !_rigidbody.useGravity;
        controls.otherButtons[0] = false;
    }

    public void Energy()
    {
        if (controls.GetIfOtherIsSelected(1) && selectedApex != null && UseChargeOfEnergy())   
        {
            Vector3 pos = new Vector3();

            pos.z = transform.position.z;

            Transform brick = selectedApex.GetComponent<Apex>().brick.transform;

            float brickVelocityX = 0;
            float brickVelocityY = 0;

            if (brick.GetComponent<Rigidbody>())
            {
                brickVelocityX = brick.GetComponent<Rigidbody>().velocity.x;
                brickVelocityY = brick.GetComponent<Rigidbody>().velocity.y;
            }

            Pos(ref pos, true, transform.position.x, brick.position.x, brick.localScale.x, brickVelocityX);
            Pos(ref pos, false, transform.position.y, brick.position.y, brick.localScale.y, brickVelocityY);
           
            transform.position = pos;

            controls.otherButtons[1] = false;
        }
        else if (controls.GetIfOtherIsSelected(2) && selectedApex == null && UseChargeOfEnergy())
        {
            Boost();
        }
    }

    public bool CollectChargeOfEnergy()
    {
        ui.EnergyCollected(chargesOfEnergy != maxChargesOfEnergy);

        if (chargesOfEnergy != maxChargesOfEnergy)
        {
            chargesOfEnergy++;
            return true;
        }

        return false;
    }

    public bool UseChargeOfEnergy()
    {
        if (chargesOfEnergy > 0 && ui.CanIUseEnergyYet())
        {
            chargesOfEnergy--;
            return true;
        }

        return false;
    }

    void Boost()
    {
        if (collidingEdges.Count == 0)
            return;
        
        Vector3 direction = new Vector3();

        if (collidingEdges.Count > 1)
            direction = DirectionOfBoost();
        else
            direction = -collidingEdges[0].position + transform.position;

        direction.z = 0f;

        GetComponent<Rigidbody>().AddForce(direction * boostPower);
        AudioController._instance.PlaySound("boost");

        controls.otherButtons[2] = false;
    }

    Vector3 DirectionOfBoost()
    {
        return -Vector3.Cross(transform.position - collidingEdges[0].position, transform.position- collidingEdges[1].position);
    }

    void Pos(ref Vector3 pos, bool xAxis, float playerPosition, float brickPosition, float brickScale, float brickVelocity)
    {
        float myPosAbs = playerPosition;
        float brickPosAbs = brickPosition;
        
        float rest = myPosAbs - brickPosAbs;
        rest = Mathf.Abs(rest);
        rest -= Mathf.Floor(rest);
        
        int i = 0;
        
        float b = 1;
        if (myPosAbs % 1 == 0 && brickPosAbs % 1 == 0)
            b = 0;
        
        if (myPosAbs > brickPosAbs)
            for (; myPosAbs > brickPosAbs + b; i++)
                myPosAbs--;
        else if (myPosAbs < brickPosAbs)
            for (; myPosAbs < brickPosAbs - b; i++)
                myPosAbs++;
        
        float addition = 0;
        if (brickScale % 2 == 0)
            addition = 0.5f;
        if (rest > 0.7f)
            addition++;
        
        if (playerPosition < brickPosition)
        {
            if (xAxis)
                pos.x = brickPosition - i - addition;
            else
                pos.y = brickPosition - i - addition;
        }
        else if (playerPosition > brickPosition)
        {
            if (xAxis)
                pos.x = brickPosition + i + addition;
            else
                pos.y = brickPosition + i + addition;
        }
    }
}