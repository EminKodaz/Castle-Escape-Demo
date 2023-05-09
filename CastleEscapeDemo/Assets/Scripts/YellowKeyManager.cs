using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKeyManager : MonoBehaviour
{
    private GameObject _yellowDoorLocker;


    void Start()
    {
        _yellowDoorLocker = GameObject.Find("YellowDoorLocker");
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
            _yellowDoorLocker.GetComponent<BoxCollider>().enabled = false;
        }
    }
}












