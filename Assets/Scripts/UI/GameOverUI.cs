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
            TileManager.GameFinished.AddListener(ShowGameEnding);

            retryButton.onClick.AddListener(Retry);
            quitButton.onClick.AddListener(Quit);
        }

        private void ShowGameOver()
        {
            gameOverObject.SetActive(true);
            messageTxt.text = $"You have reached level {GameData.CurrentLevel}";
        }

        private void ShowGameEnding()
        {
            gameOverObject.SetActive(true);
            messageTxt.text =
                $"I didn't think of an interesting ending to this game, sorry. Thanks for playing though, hope you enjoyed it!";
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