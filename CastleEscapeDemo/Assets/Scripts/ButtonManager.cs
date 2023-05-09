using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    private GameObject _doorLocker;

    void Start()
    {
        _doorLocker = GameObject.Find("DoorLocker");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("opened", true);
            _doorLocker.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
