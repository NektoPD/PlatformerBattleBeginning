using UnityEngine;

[RequireComponent (typeof(Enemy))]
[RequireComponent (typeof(EnemyView))]
public class EnemyPlayerFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;

    private RaycastHit2D _hit;
    private Enemy _enemy;
    private EnemyView _enemyView;
    private int _viewDistance = 10;

    private void Awake()
    {
        _enemyView = GetComponent<EnemyView>();
        _enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        if (_enemyView.IsFacingLeft)
        {
            LookForTarget(Vector2.right);
        }
        else
        {
            LookForTarget(Vector2.left);
        }
    }

    private void LookForTarget(Vector2 position)
    {
        _hit = Physics2D.Raycast(transform.position, position, _viewDistance, _playerMask);

        if (_hit)
        {
            _enemy.FollowTarget(_hit.transform.position);
        }
    }
}
