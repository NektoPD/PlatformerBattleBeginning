using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyView : MonoBehaviour
{
    public bool IsFacingLeft { get; private set; } = false;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Flip()
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
}
