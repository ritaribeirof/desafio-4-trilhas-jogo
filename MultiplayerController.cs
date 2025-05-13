using UnityEngine;

public class MultiplayerController : MonoBehaviour
{
    public SnakeController player1;
    public SnakeController player2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) player1.DefinirDirecao(Vector2.up);
        if (Input.GetKeyDown(KeyCode.S)) player1.DefinirDirecao(Vector2.down);
        if (Input.GetKeyDown(KeyCode.A)) player1.DefinirDirecao(Vector2.left);
        if (Input.GetKeyDown(KeyCode.D)) player1.DefinirDirecao(Vector2.right);

        if (Input.GetKeyDown(KeyCode.UpArrow)) player2.DefinirDirecao(Vector2.up);
        if (Input.GetKeyDown(KeyCode.DownArrow)) player2.DefinirDirecao(Vector2.down);
        if (Input.GetKeyDown(KeyCode.LeftArrow)) player2.DefinirDirecao(Vector2.left);
        if (Input.GetKeyDown(KeyCode.RightArrow)) player2.DefinirDirecao(Vector2.right);
    }
}
