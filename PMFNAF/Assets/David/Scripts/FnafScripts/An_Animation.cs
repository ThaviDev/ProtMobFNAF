using UnityEngine;

public class An_Animation : MonoBehaviour
{
    Animator _animator;
    void Start()
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
}
