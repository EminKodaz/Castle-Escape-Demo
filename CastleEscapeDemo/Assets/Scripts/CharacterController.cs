using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class CharacterController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidBody;
    [SerializeField] private FixedJoystick _joyStick;
    [SerializeField] private Animator _animator;

    public float _movementSpeed;
    public int _enemyLevel;

    private void Start()
    {
        EnemyManager.enemyLevel = _enemyLevel;
    }


    private void FixedUpdate()
    {
        
        _rigidBody.velocity = new Vector3(-_joyStick.Horizontal * _movementSpeed, _rigidBody.velocity.y, -_joyStick.Vertical * _movementSpeed);

        if (_joyStick.Horizontal != 0 || _joyStick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidBody.velocity);
            _animator.SetBool("isRunning", true);
        }
        else
        {
            _animator.SetBool("isRunning", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") & GameManager.instance.GetPlayerLevel() > _enemyLevel)
        {
            _animator.SetBool("isAttackRange", true);
            StartCoroutine(AnimDelay(1f));      
        }

        if (other.gameObject.CompareTag("Enemy") & GameManager.instance.GetPlayerLevel() < _enemyLevel)
        {
            _animator.SetBool("isAlive", true) ;
            GameManager.instance.RestartLevel();
        }

        if (other.gameObject.CompareTag("RestartArea"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator AnimDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.SetBool("isAttackRange", false);
    }
}





