using UnityEngine;

[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private int _damage => _attacker.Damage;

    private float _speed = 3;
    private Health _health;
    private Attacker _attacker;

    private void Awake()
    {
        _attacker = GetComponent<Attacker>();
        _health = GetComponent<Health>();
        _health.HealthEmptied += Die;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent<Player>(out Player player))
        {
            if (player.TryGetComponent<Health>(out Health health))
            {
                health.Decreace(_damage);
            }
        }
    }

    private void OnDisable()
    {
        _health.HealthEmptied -= Die;
    }

    public void FollowTarget(Vector2 targetPosition)
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _speed * Time.deltaTime);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}