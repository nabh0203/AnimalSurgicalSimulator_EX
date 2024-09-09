using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodThrough : MonoBehaviour
{
    [SerializeField] IvCatheterDegrees ivCatheter;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("catheter"))
        {
            ivCatheter.isDeepCatheter = true;
        }
    }

   /* void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("catheter"))
        {
            ivCatheter.isDeepCatheter = false;
        }
    }*/
}


