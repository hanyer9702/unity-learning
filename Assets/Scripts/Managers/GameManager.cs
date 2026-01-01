using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameState currentState = GameState.Playing;

    public GameObject gameOverPanel; // UI 패널

    public int coin = 0;
    public TextMeshProUGUI coinText;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (GameManager.Instance.currentState != GameState.Playing)
            return; // 게임 오버면 이동/점프 금지
    }

    public void AddCoin(int amount)
    {
        coin += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        coinText.text = "Coin : " + coin;
    }

    public void GameOver()
    {
        if (currentState == GameState.GameOver)
            return;

        currentState = GameState.GameOver;

        Debug.Log("Game Over");

        // 예: 2초 후 재시작
        Invoke("Restart", 2f);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
