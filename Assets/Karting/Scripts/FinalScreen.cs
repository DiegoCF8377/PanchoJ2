using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FinalScreen : MonoBehaviour
{
    public static int tiempoPantalla = 5;
    private bool notRunning = true;
    public TextMeshProUGUI Final;
    
    private IEnumerator PantallaFinal()
    {   
        for (float i = 0.05f; i <= tiempoPantalla; i += 0.05f)
        {
            yield return new WaitForSeconds(0.04f);
            this.GetComponent<Image>().color = new Color(0, 0, 0, (i / tiempoPantalla));
            Final.color = new Color(255, 255, 255, (i+1f / tiempoPantalla));
        }

    }

    void Update()
    {
        if (PickupFinalObject.isFinal && notRunning)
        {
            notRunning = false;
            StartCoroutine(PantallaFinal());
        }
    }

    
}
