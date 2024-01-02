using UnityEngine;

[RequireComponent (typeof(EnemyAnimator))]
[RequireComponent(typeof(Attacker))]
[RequireComponent(typeof(Health))]
[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : MonoBehaviour
{
    public bool IsFacingLeft { get; private set; }
    private int _damage => _attacker.Damage;

    private SpriteRenderer _spriteRenderer;
    private Transform _path;
    private Transform[] _targets;
    private float _speed = 3;
    private int _currentPosition;
    private Health _health;
    private Attacker _attacker;

    private void Start()
    {
        _attacker = GetComponent<Attacker>();
        _health = GetComponent<Health>();
        _health.HealthEmptied += Die;
        IsFacingLeft = false;
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _targets = new Transform[_path.childCount];

        for (int i = 0; i < _targets.Length; i++)
        {
            _targets[i] = _path.GetChild(i);
        }
    }

    private void Update()
    {
        MoveToTarget();
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

    private void OnDestroy()
    {
        _health.HealthEmptied -= Die;
    }

    public void SetTarget(Transform target)
    {
        _path = target;
    }

    private void MoveToTarget()
    {
        Transform target = _targets[_currentPosition];

        transform.position = Vector2.MoveTowards(transform.position, target.position, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target.position) < 1f)
        {
            Flip();
            MoveToNextTarget();
        }
    }

    private void MoveToNextTarget()
    {
        _currentPosition++;

        if (_currentPosition >= _targets.Length)
        {
            _currentPosition = 0;
        }
    }

    private void Flip()
    {
        if (_spriteRenderer.flipX == false)
        {
            IsFacingLeft = true;
            _spriteRenderer.flipX = true;
        }
        else
        {
            IsFacingLeft = false;
            _spriteRenderer.flipX = false;
        }
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