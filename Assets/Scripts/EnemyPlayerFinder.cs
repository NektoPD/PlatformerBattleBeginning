using UnityEngine;

public class EnemyPlayerFinder : MonoBehaviour
{
    [SerializeField] private LayerMask _playerMask;

    private RaycastHit2D _hit;
    private Enemy _enemy;

    private void Start()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        if (_enemy.IsFacingLeft)
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
        _hit = Physics2D.Raycast(transform.position, position, 10, _playerMask);
        Debug.DrawRay(transform.position, position * 10, Color.red);

        if (_hit)
        {
            _enemy.FollowTarget(_hit.transform.position);
        }
    }
}
