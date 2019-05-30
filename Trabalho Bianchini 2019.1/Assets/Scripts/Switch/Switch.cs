using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    public GameObject[] caixas_A;
    public GameObject[] caixas_B;

    int currentBoxA;
    int currentBoxB;

    [SerializeField]
    private bool ligado; 


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            currentBoxA = 0;
            currentBoxB = 0;
            if (ligado == true)
            {
                LigaCaixasA();
                ligado = false;
            }
            else
            {
                LigaCaixasB();
                ligado = true;
            }
        }
    }

    void LigaCaixasA()
    {
        for (int i = 0; i < caixas_A.Length; i++)
        {
            caixas_A[currentBoxA].SetActive(true);
            currentBoxA++;
        }
        for (int i = 0; i < caixas_B.Length; i++)
        {
            caixas_B[currentBoxB].SetActive(false);
            currentBoxB++;
        }
    }

    void LigaCaixasB()
    {
        for (int i = 0; i < caixas_A.Length; i++)
        {
            caixas_A[currentBoxA].SetActive(false);
            currentBoxA++;
        }
        for (int i = 0; i < caixas_B.Length; i++)
        {
            caixas_B[currentBoxB].SetActive(true);
            currentBoxB++;
        }
    }
}
