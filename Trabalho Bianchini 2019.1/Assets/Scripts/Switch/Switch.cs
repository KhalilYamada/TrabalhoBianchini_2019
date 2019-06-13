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

    bool emContato;

    private void Start()
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


    void Update()
    {
        if (emContato == true && Input.GetKeyDown(KeyCode.E))
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


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emContato = true;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            emContato = false;
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
