using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI recipesDeliveredText;
    [SerializeField] private Button playAgainButton;
    [SerializeField] private Button mainmenuButton;
    [SerializeField] private Button quitButton;

    private void Awake()
    {
        mainmenuButton.onClick.AddListener(() => 
        {
            SceneManager.LoadScene(Loader.Scene.MainMenuScene.ToString());
        });
        playAgainButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(Loader.Scene.GameScene.ToString());
        });
        quitButton.onClick.AddListener(() =>
        {
            Application.Quit();
        });
    }

    private void Start()
    {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        Hide();
    }


    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e)
    {
        if (KitchenGameManager.Instance.IsGameOver())
        {
            Show();
            playAgainButton.Select();
            Time.timeScale = 0f;
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
