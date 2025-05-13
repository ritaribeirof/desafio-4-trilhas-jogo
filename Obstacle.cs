using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Lógica para obstáculos, pode ser ajustado para customizar o comportamento
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            // Faz o jogo parar ou colidir com o obstáculo
            GameManager.instance.GameOver();
        }
    }
}
