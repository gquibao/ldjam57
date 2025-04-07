using TMPro;
using UnityEngine;

public class Hud : MonoBehaviour
{
    [SerializeField] private TMP_Text livesText;
    [SerializeField] private TMP_Text levelText;
    
    void Start()
    {
        TileManager.OnLevelChanged.AddListener(UpdateLevel);
        TileManager.WrongToolUsed.AddListener(UpdateLives);
        
        UpdateLevel();
        UpdateLives();
    }

    private void UpdateLives()
    {
        livesText.text = $"{GameData.PlayerLives}";
    }
    
    private void UpdateLevel()
    {
        levelText.text = $"{GameData.CurrentLevel}";
    }
}
