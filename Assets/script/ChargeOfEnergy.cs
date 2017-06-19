using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeOfEnergy : MonoBehaviour 
{
    public int charges;

    void OnTriggerEnter(Collider collider)
    {
        for (int i = 0; i < charges; i++)
        {
            if (LayerMask.NameToLayer("player") == collider.gameObject.layer)
            {
                if (collider.GetComponent<Cube>().CollectChargeOfEnergy())
                {
                    AudioController._instance.PlaySound("chargeOfEnergy");

                    gameObject.SetActive(false);
                }
            }
        }
    }
}