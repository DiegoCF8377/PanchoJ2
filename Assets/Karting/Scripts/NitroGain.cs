using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NitroGain : MonoBehaviour
{
    public Slider Nitro;
 
    private void OnTriggerEnter(Collider other)
    {
        gameObject.active = false;
        if (Nitro.value != 100)
        {
            Nitro.value += 25;
        }
    }
}
