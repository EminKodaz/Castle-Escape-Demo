using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Upgrader : MonoBehaviour
{
    public int instantLevel = 1;


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {

            GameManager.instance.SetPlayerLevel(instantLevel);
            gameObject.SetActive(false);
        }
    }
}
