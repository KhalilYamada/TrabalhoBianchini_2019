using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(VoltaProJogo());
    }



    IEnumerator VoltaProJogo()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("Fase01");
    }


}
