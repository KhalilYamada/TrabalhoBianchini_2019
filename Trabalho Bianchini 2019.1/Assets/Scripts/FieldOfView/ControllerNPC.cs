using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerNPC : MonoBehaviour
{

    //NavMesh
    public NavMeshAgent myAgent;


    //Pontos de Movimento
    public GameObject targetGM_01;
    private Vector3 target_01;

    public GameObject targetGM_02;
    private Vector3 target_02;

    public GameObject targetGM_Reset;
    private Vector3 target_Reset;

    public GameObject targetGM_ObjetoEncontrado;
    private Vector3 target_ObjetoEncontrado;


    //Scripts
    public FieldOfView campoDeVisao;


    //Floats
    public float tempoDeConfusao;


    //Booleans
    private bool switchBettween;
    public bool andando = true;
    public bool encontrou = false;
    public bool buscandoTotem = true;

    void Start()
    {
        campoDeVisao = GetComponent<FieldOfView>();
        targetGM_Reset.SetActive(false);
        myAgent = GetComponent<NavMeshAgent>();
    }



    private void Update()
    {
        if (andando == true)
        {
            MovimentoBasico();
        }
        if (encontrou == true)
        {
            EncontrouPoster();
        }
    }


    void MovimentoBasico()
    {
        if (switchBettween == true)
        {
            target_01 = targetGM_01.transform.position;
            myAgent.SetDestination(target_01);
        }
        else
        {
            target_02 = targetGM_02.transform.position;
            myAgent.SetDestination(target_02);
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Change"))
        {
            if (switchBettween == true)
            {
                switchBettween = false;
            }
            else
            {
                switchBettween = true;
            }
        }
        if (other.CompareTag("PosterHitbox"))
        {
            buscandoTotem = false;
            myAgent.isStopped = true;
            StartCoroutine(ColidiuComPoster());

        }
        if (other.CompareTag("Reset"))
        { 
            targetGM_Reset.SetActive(false);
            andando = true;
            buscandoTotem = true;
        }
    }

    void EncontrouPoster()
    {
        andando = false;
        target_ObjetoEncontrado = campoDeVisao.localizacaoDoPoster;
        myAgent.SetDestination(target_ObjetoEncontrado);
        encontrou = false;
    }



    IEnumerator ColidiuComPoster()
    {
        //Roda Animação de Confusão
        yield return new WaitForSeconds(tempoDeConfusao);
        myAgent.isStopped = false;
        targetGM_Reset.SetActive(true);
        target_Reset = targetGM_Reset.transform.position;
        myAgent.SetDestination(target_Reset);
    }
}
