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
            if (GameData.CurrentLevel == 40)
            {
                gameOverObject.SetActive(true);
                messageTxt.text = $"I didn't think of an interesting ending to this game, sorry. Thanks for playing though, hope you enjoyed it!";
            }
            else
            {
                gameOverObject.SetActive(true);
                messageTxt.text = $"You have reached level {GameData.CurrentLevel}";
            }   
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
