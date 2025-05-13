using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject foodPrefab;
    public GameObject cityObject;  // Referência para o objeto da cidade que será destruído
    public Text scoreText;
    public Text gameOverText;
    public Text storyText; // Texto da história interativa

    public int Score = 0;
    public int cityDestructionSize = 100000;  // Pontuação necessária para destruir a cidade (100.000)
    public int comidaTipoScore = 1; // Pontuação dada por comida típica (arroz de cuxá, bacalhau, etc.)

    void Awake()
    {
        instance = this;
        gameOverText.enabled = false;
        storyText.enabled = false;  // Inicia a história invisível
        InvokeRepeating("SpawnFood", 2f, 3f);  // Spawna comida repetidamente
    }

    void Update()
    {
        scoreText.text = "Crescimento da Serpente: " + Score;

        // Verifica se a pontuação atingiu o limite para destruir a cidade
        if (Score >= cityDestructionSize && cityObject != null)
        {
            DestroyCity();  // Chama o método para destruir a cidade
        }

        if (Input.GetKeyDown(KeyCode.R))  // Reinicia o jogo quando pressionar a tecla "R"
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Recarrega a cena atual
        }
    }

    void SpawnFood()
    {
        int x = Random.Range(-8, 8);  // Define as coordenadas para a comida
        int y = Random.Range(-4, 4);
        Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity);  // Instancia a comida na cena
    }

    public void GameOver()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;  // Pausa o jogo quando terminar
    }

    public void AdicionarPontuacao(int pontos)
    {
        Score += pontos;  // Aumenta a pontuação com base na comida que a cobra come
    }

    // Método para destruir a cidade quando a pontuação atingir o limite
    public void DestroyCity()
    {
        if (cityObject != null)
        {
            Destroy(cityObject);  // Destrói o objeto da cidade
            cityObject = null;  // Desfaz a referência à cidade após destruí-la
            StartCoroutine(ShowStory());  // Inicia a história interativa após destruir a cidade
        }
    }

    // Coroutine para exibir a história de forma gradual
    IEnumerator ShowStory()
    {
        // História com base na alimentação das comidas típicas
        string intro = "A Cobra de São Luís do Maranhão, mitológica e alimentada pelas comidas típicas da cidade, cresce a cada refeição...\n" +
                       "Com arroz de cuxá, juçara, e o refrigente guaraná Jesus entre outros pratos, que chegam até a ela. Dessa forma, a mesma vai ficando mais forte e destrutiva.\n";

        storyText.enabled = true;  // Habilita o texto da história
        storyText.text = "";  // Limpa o texto antes de começar

        foreach (char letter in intro.ToCharArray())  // Exibe o início da história letra por letra
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);  // Controla a velocidade com que a história é exibida
        }

        yield return new WaitForSeconds(2);  // Espera antes de mostrar a parte seguinte

        // Meio da história - A cobra cresce e começa a destruir a cidade
        string middle = "À medida que a cobra devora mais e mais pratos típicos da região, sua fome se intensifica...\n" +
                        "Agora, ela se torna um monstro, engolindo tudo ao seu redor, incluindo a própria cidade...\n";

        foreach (char letter in middle.ToCharArray())  // Exibe a parte do meio da história letra por letra
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);  // Controla a velocidade com que a história é exibida
        }

        yield return new WaitForSeconds(2);  // Espera antes de mostrar a parte final

        // Fim da história - A cidade é destruída
        string end = "Com o crescimento monstruoso da cobra, a cidade de São Luís é totalmente destruída...\n" +
                     "Agora, ela se torna uma lenda, um símbolo de resistência, poder e a força imbatível da natureza...\n" +
                     "Fim da história! Pressione 'R' para reiniciar.";

        foreach (char letter in end.ToCharArray())  // Exibe o final da história letra por letra
        {
            storyText.text += letter;
            yield return new WaitForSeconds(0.05f);  // Controla a velocidade com que a história é exibida
        }
    }
}