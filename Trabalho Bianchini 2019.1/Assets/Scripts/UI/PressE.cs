using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressE : MonoBehaviour
{ 
    public GameObject texto;


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            texto.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            texto.SetActive(false);
        }
    }
}
