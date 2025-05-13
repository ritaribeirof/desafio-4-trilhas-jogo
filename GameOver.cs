using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text gameOverText;
    
    void Start()
    {
        gameOverText.enabled = false;
    }

    public void ExibirGameOver()
    {
        gameOverText.enabled = true;
        gameOverText.text = "GAME OVER! Pressione 'R' para reiniciar.";
    }
}
