using System.Collections;
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

    public GameObject targetGM_PlayerEncontrado;
    private Vector3 target_PlayerEncontrado;

    public GameObject targetGM_Origem;
    private Vector3 target_Origem;

    //Scripts
    public FieldOfView campoDeVisao;


    //Floats
    public float tempoDeConfusao;
    [HideInInspector]
    public float tempoProcurando;
    [HideInInspector]
    public float tempoDeEspera = 5;

    //Booleans
    private bool switchBettween;
    public bool andando = true;
    public bool encontrou = false;
    public bool buscandoPlayer = true;
    public bool playerSaiuDaVisao = false;

    public bool fazRota;

    void Start()
    {
        if(targetGM_Origem != null)
        {
            target_Origem = targetGM_Origem.transform.position;
        }

        campoDeVisao = GetComponent<FieldOfView>();
        targetGM_Reset.SetActive(false);
        myAgent = GetComponent<NavMeshAgent>();
    }



    private void Update()
    {
        tempoProcurando = Time.time;
        if(fazRota == true)
        {
            if (andando == true)
            {
                MovimentoBasico();
            }
        }
        if (encontrou == true)
        {
            EncontrouPlayer();
        }
        if (playerSaiuDaVisao == true)
        {
            PerdeuPlayer();
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

        if (other.CompareTag("Reset"))
        {
            if(fazRota == true)
            {
                andando = true;
            }
            else
            {
                myAgent.SetDestination(target_Origem);
            }
            targetGM_Reset.SetActive(false);
            buscandoPlayer = true;
        }

        if (other.CompareTag("PosOrigem"))
        {
            Debug.Log("parou");
        }

        if (other.CompareTag("Hideout"))
        {
            StartCoroutine(ResetaOMovimento());
        }
    }

    void EncontrouPlayer()
    {
        andando = false;
        target_PlayerEncontrado = campoDeVisao.localizacaoDoPlayer;
        myAgent.SetDestination(target_PlayerEncontrado);
    }

    
    void PerdeuPlayer()
    {
        if(tempoProcurando >= tempoDeEspera)
        {
            encontrou = false;
            buscandoPlayer = false;
            playerSaiuDaVisao = false;
            StartCoroutine(ResetaOMovimento());            
        }
    }
    
    

    IEnumerator ResetaOMovimento()
    {
        yield return new WaitForSeconds(tempoDeConfusao);
        myAgent.isStopped = false;
        target_Reset = targetGM_Reset.transform.position;
        targetGM_Reset.SetActive(true);
        myAgent.SetDestination(target_Reset);        
    }
}
