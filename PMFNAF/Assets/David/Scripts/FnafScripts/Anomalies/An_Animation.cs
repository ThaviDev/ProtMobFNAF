using UnityEngine;

public class An_Animation : MonoBehaviour
{
    Animator _animator;
    bool _savedBoolState = false;
    void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    public void SetAnomalyON()
    {
        _animator.SetBool("isAnomalus", true);
    }
    public void SetAnomalyOFF()
    {
        _animator.SetBool("isAnomalus", false);
    }

    private void OnDisable()
    {
        _savedBoolState = _animator.GetBool("isAnomalus");
    }

    private void OnEnable()
    {
        _animator.SetBool("isAnomalus", _savedBoolState);
    }
}
