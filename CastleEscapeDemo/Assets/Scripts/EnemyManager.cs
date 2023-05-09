using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator _animator;

    public Transform[] waypoints;
    int waypointIndex;
    public static int enemyLevel = 5;

    Vector3 target;

    void Start()
    {
        UpdateDestination();
          
    }

    void Update()
    {
        if (Vector3.Distance(transform.position,target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }

    void UpdateDestination ()
    {
        target = waypoints[waypointIndex].position;
        agent.SetDestination(target);
    }

    void IterateWaypointIndex ()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") & GameManager.instance.GetPlayerLevel() > enemyLevel)
        {
            _animator.SetBool("isItDead", true);
            
            StartCoroutine(DeactivateAfterDelay(1f));
            agent.enabled = false;
        }

        else if (other.gameObject.CompareTag("Player") & GameManager.instance.GetPlayerLevel() < enemyLevel)
        {
            _animator.SetBool("isInRange", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("isInRange", false);
        }
    }

    IEnumerator DeactivateAfterDelay(float delay)
    {    
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }


}
