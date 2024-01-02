using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private int _healingAmount = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Player>(out Player player))
        {
            player.GetComponent<Health>().Increace(_healingAmount);
            Destroy(gameObject);
        }
    }
}
