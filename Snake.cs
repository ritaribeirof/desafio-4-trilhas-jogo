using System.Collections.Generic;
using UnityEngine;

public class SnakeController : MonoBehaviour
{
    public float moveRate = 0.3f;
    public GameObject tailPrefab;

    private Vector2 direction = Vector2.right;
    private List<Transform> tail = new List<Transform>();
    private bool ate = false;

    void Start()
    {
        // Move periodicamente com base na velocidade
        InvokeRepeating("Move", moveRate, moveRate);
    }

    void Update()
    {
        // Captura de direção
        if (Input.GetKey(KeyCode.RightArrow)) direction = Vector2.right;
        else if (Input.GetKey(KeyCode.LeftArrow)) direction = Vector2.left;
        else if (Input.GetKey(KeyCode.UpArrow)) direction = Vector2.up;
        else if (Input.GetKey(KeyCode.DownArrow)) direction = Vector2.down;
    }

    void Move()
    {
        Vector2 prevPos = transform.position;
        transform.Translate(direction); // Move a cabeça

        // Se comeu: adiciona novo segmento
        if (ate)
        {
            GameObject newTail = Instantiate(tailPrefab, prevPos, Quaternion.identity);
            tail.Insert(0, newTail.transform);
            ate = false;
        }
        else if (tail.Count > 0)
        {
            // Move o último segmento para a frente
            tail[tail.Count - 1].position = prevPos;
            tail.Insert(0, tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "Food")
        {
            ate = true;
            Destroy(coll.gameObject);
            GameManager.instance.Score++;
        }
        else if (coll.tag == "Wall" || coll.tag == "Tail")
        {
            GameManager.instance.GameOver();
        }
    }
}

