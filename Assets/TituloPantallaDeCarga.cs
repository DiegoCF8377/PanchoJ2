using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.CompilerServices;

public class TituloPantallaDeCarga : MonoBehaviour
{

    public TextMeshProUGUI titulo;

    private void Start()
    {
        if(NitroCollider.nitroCollider == "NonOrganicTrash")
        {
            titulo.text = "CIRCUITO INORGÁNICO RECICLABLE";
        }
        else if (NitroCollider.nitroCollider == "NonOrganicTrashNonReciclable")
        {
            titulo.text = "CIRCUITO INORGÁNICO NO RECICLABLE";
        }
        else if (NitroCollider.nitroCollider == "ElectronicTrash")
        {
            titulo.text = "CIRCUITO ELECTRÓNICO";
        }
    }
}
