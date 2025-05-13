using UnityEngine;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public GameObject cityObject;
    public Text scoreText;
    public Text gameOverText;
    public Text storyText;

    public int Score = 0;
    public int cityDestructionSize = 100000;
    public int comidaTipoScore = 1;

    private bool historiaExibida = false;

    void Awake()
    {
        instance = this;
        gameOverText.enabled = false;
        storyText.enabled = false;
        InvokeRepeating("SpawnFood", 2f, 3f);
    }

    void Update()
    {
        scoreText.text = "Crescimento da Serpente: " + Score;

        if (Score >= cityDestructionSize && cityObject != null)
        {
            DestroyCity();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // TOQUE ou CLIQUE para reiniciar após a história
        if (historiaExibida && (Input.touchCount > 0 || Input.GetMouseButtonDown(0)))
        {
            storyText.enabled = false;
            historiaExibida = false;
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

    public void DestroyCity()
    {
        if (cityObject != null)
        {
            Destroy(cityObject);
            cityObject = null;
            StartCoroutine(ShowStory());
        }
    }

    IEnumerator ShowStory()
    {
        storyText.enabled = true;
        storyText.text = "";

        string intro = "A Cobra de São Luís do Maranhão, mitológica e alimentada pelas comidas típicas da cidade, cresce a cada refeição...\n" +
                       "Com arroz de cuxá, juçara, e o refrigerante guaraná Jesus, a cobra vai ficando mais forte e destrutiva.\n";

        foreach (char letter in intro.ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        string middle = "À medida que a cobra devora mais e mais pratos típicos da região, sua fome se intensifica...\n" +
                        "Agora, ela se torna um monstro, engolindo tudo ao seu redor, inclusive a própria cidade...\n";

        foreach (char letter in middle.ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        yield return new WaitForSeconds(2f);

        string end = "Com o crescimento monstruoso da cobra, a cidade de São Luís é totalmente destruída...\n" +
                     "Agora, ela se torna uma lenda, um símbolo de resistência, poder e a força imbatível da natureza.\n" +
                     "Fim da história! Toque ou clique na tela para reiniciar.";

        foreach (char letter in end.ToCharArray())
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }

        historiaExibida = true;
    }
}
