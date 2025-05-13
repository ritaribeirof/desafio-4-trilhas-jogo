using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject gameUI;

    public void PausarJogo()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gameUI.SetActive(false);
    }

    public void ContinuarJogo()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gameUI.SetActive(true);
    }

    public void SairParaMenu()
    {
        // Ação para voltar ao menu principal, você pode personalizar isso conforme necessário
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); // Exemplo
    }
}
