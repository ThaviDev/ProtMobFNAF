using UnityEngine;
public class ScaleObject : MonoBehaviour
{
    [SerializeField] GameObject _object;
    public void UpdatedSliderValue(float _value)
    {
        //var _myTransform = _object.transform;
        _object.transform.localScale = new Vector3(_value, _value, _value);
    }
}
