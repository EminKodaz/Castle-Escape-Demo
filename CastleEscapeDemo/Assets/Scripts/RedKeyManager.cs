using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKeyManager : MonoBehaviour
{
    private GameObject _redDoorLocker;


    void Start()
    {
        _redDoorLocker = GameObject.Find("RedDoorLocker");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            _redDoorLocker.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
