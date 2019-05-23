using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    public KeyManager sendInfo;

    private void Start()
    {
        sendInfo = GameObject.FindWithTag("KeyManager").GetComponent<KeyManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            sendInfo.keysPegas++;
            Destroy(gameObject);
        }
    }
}
