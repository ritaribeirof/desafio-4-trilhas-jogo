using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public Text scoreText;
    public Text gameOverText;

    public int Score = 0;

    void Awake()
    {
        instance = this;
        gameOverText.enabled = false;
        InvokeRepeating("SpawnFood", 2f, 3f);
    }

    void Update()
    {
        scoreText.text = "Crescimento da Serpente: " + Score;

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void SpawnFood()
    {
        int x = Random.Range(-8, 8);
        int y = Random.Range(-4, 4);
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }

    public void AdicionarPontuacao(int pontos)
    {
        Score += pontos;
    }
}
