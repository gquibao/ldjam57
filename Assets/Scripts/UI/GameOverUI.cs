using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverObject;
        [SerializeField] private Button retryButton;
        [SerializeField] private Button quitButton;
        [SerializeField] private TMP_Text messageTxt;
        private void Start()
        {
            gameOverObject.SetActive(false);
            
            PlayerMovement.PlayerDied.AddListener(ShowGameOver);
            
            retryButton.onClick.AddListener(Retry);
            quitButton.onClick.AddListener(Quit);
        }

        private void ShowGameOver()
        {
            gameOverObject.SetActive(true);
            messageTxt.text = $"You have reached level {GameData.CurrentLevel}";
        }

        private void Retry()
        {
            GameData.ResetGame();
            SceneManager.LoadScene(0);
        }

        private void Quit()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
