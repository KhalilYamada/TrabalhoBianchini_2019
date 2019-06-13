using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private int tempoFaltandoMin;
    [SerializeField]
    private int tempoFaltandoSeg;    

    private int tempoParaPerder;

    public TextMeshProUGUI textoDeTempo;

    private void Start()
    {
        StartCoroutine(SubtraiTempo());
        tempoParaPerder = ((tempoFaltandoMin * 60) + tempoFaltandoSeg) - 1;
    }


    private void Update()
    {
        if(tempoFaltandoSeg <= 9)
        {
            textoDeTempo.text = "Tempo restante: " + tempoFaltandoMin.ToString() + ":0" + tempoFaltandoSeg.ToString();
        }
        else
        {
            textoDeTempo.text = "Tempo restante: " + tempoFaltandoMin.ToString() + ":" + tempoFaltandoSeg.ToString();
        }
    }





    IEnumerator SubtraiTempo()
    {
        for (int i = 0; i <= tempoParaPerder; i++)
        {
            yield return new WaitForSeconds(1);

            if (tempoFaltandoSeg >= 1)
            {
                tempoFaltandoSeg--;
            }
            else if (tempoFaltandoMin >= 1)
            {
                tempoFaltandoMin--;
                tempoFaltandoSeg = 59;
            }
        }
        SceneManager.LoadScene("Death");
    }       
}
