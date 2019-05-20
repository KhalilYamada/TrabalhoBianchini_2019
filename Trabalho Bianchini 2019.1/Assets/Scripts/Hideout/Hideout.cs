using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hideout : MonoBehaviour
{

    public GameObject colisor;

    



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colisor.SetActive(true);
        }

        Debug.Log("Player");

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            colisor.SetActive(false);
        }

        Debug.Log("Player");

    }
}
