using UnityEngine;

public class SpeedPowerUp : MonoBehaviour
{
    public float speedBoostDuration = 5f;
    private bool isActive = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            isActive = true;
            other.GetComponent<SnakeController>().moveRate /= 2;  // Aumenta a velocidade
            Destroy(gameObject);
            StartCoroutine(DesativarPowerUp(other));
        }
    }

    IEnumerator DesativarPowerUp(SnakeController player)
    {
        yield return new WaitForSeconds(speedBoostDuration);
        player.moveRate *= 2;  // Retorna à velocidade normal
        isActive = false;
    }
}
