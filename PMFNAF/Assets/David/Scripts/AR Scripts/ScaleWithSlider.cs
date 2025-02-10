using UnityEngine;

public class ScaleWithSlider : MonoBehaviour
{
    [SerializeField] GameObject _object;
    bool _objEnabled = false;
    [SerializeField] TapToPlaceObject _tapToPlaceObject;
    private void Update()
    {
        if (_tapToPlaceObject.placedObject != null && _objEnabled == false)
        {
            _objEnabled = true;
            _object = _tapToPlaceObject.placedObject;
        }
    }
    public void UpdatedSliderValue(float _value)
    {
        if (_objEnabled)
        _object.transform.localScale = new Vector3(_value, _value, _value);
    }
}
