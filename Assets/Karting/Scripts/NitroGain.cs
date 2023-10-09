using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroGain : MonoBehaviour
{
 
    private void OnTriggerEnter(Collider other)
    {
        gameObject.active = false;
    }
}
