using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance

    [SerializeField] private int playerLevel = 1;

    private void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public int GetPlayerLevel()
    {
        return playerLevel;
    }

    public void SetPlayerLevel(int newLevel)
    {
        playerLevel = newLevel;
    }

    public void RestartLevel()
    {
        StartCoroutine(AnimDelay(2f));
        IEnumerator AnimDelay(float delay)
        {

            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentSceneIndex);

        }
    }

}

