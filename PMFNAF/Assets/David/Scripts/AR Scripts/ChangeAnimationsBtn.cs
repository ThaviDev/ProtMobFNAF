using UnityEngine;

public class ChangeAnimationsBtn : MonoBehaviour
{
    [SerializeField] Animator _animator;
    bool _objEnabled = false;
    [SerializeField] TapToPlaceObject _tapToPlaceObject;
    void Update()
    {
        if (_tapToPlaceObject.placedObject != null && _objEnabled == false)
        {
            _objEnabled = true;
            _animator = _tapToPlaceObject.placedObject.GetComponent<Animator>();
        }
    }
    public void BtnChangeAnimation()
    {
        if (_objEnabled)
        _animator.SetInteger("State", Random.Range(0, 2));
    }
}
