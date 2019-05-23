using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject[] keys;

    public float keysPegas;

    public GameObject porta;


    private void Start()
    {
        porta.SetActive(true);
    }

    private void Update()
    {
        if(keysPegas >= keys.Length)
        {
            porta.SetActive(false);
        }
    }

}
