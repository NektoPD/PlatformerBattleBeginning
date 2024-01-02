using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimator : MonoBehaviour
{
    private const string JumpComponentName = "Jump";
    private const string SpeedComponentName = "Speed";
    private const string AttackComponentName = "Attack";

    private Animator _animator;

    public void ActivateRunAnimation(float speed)
    {
        _animator.SetFloat(SpeedComponentName, speed);
    }

    public void ActivateJumpingAnimation()
    {
        _animator.SetTrigger(JumpComponentName);
    }

    public void ActivateAttackAnimation()
    {
        _animator.SetTrigger(AttackComponentName);
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
}
