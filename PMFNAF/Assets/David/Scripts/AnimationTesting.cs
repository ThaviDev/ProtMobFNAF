using UnityEngine;

public class AnimationTesting : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    public void SetNewAnimation(int _idAnim)
    {
        _animator.SetInteger("State", _idAnim);
    }
}
