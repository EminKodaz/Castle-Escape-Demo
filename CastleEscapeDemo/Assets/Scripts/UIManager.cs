using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshPro levelText;

    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance; // Singleton instance'ý atar

        UpdateLevelText();
    }

    private void Update()
    {
        UpdateLevelText();
    }

    private void UpdateLevelText()
    {
        int playerLevel = _gameManager.GetPlayerLevel();
        levelText.text = "Lv. " + playerLevel.ToString();
    }
}