using UnityEngine;
using UnityEngine.EventSystems;

public class MyARManager : MonoBehaviour
{
    private static MyARManager _instance;
    private GameObject _myChar;

    //Rotacion
    [SerializeField] private float _rotationSpeed = 1;
    private Vector2 _touchStartPosition;
    private bool _isRotating = false;


    public static MyARManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MyARManager();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }
    public void SetCharacter(GameObject _char)
    {
        _myChar = _char;
    }
    public GameObject GetCharacter()
    {
        if (_myChar == null)
        {
            print("There is no character");
            return null;
        }
        else
        {
            return _myChar;
        }
    }

    private void HandleTouchRotation()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            // Ignorar toques en UI
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId)) return;

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _touchStartPosition = touch.position;
                    _isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (_isRotating)
                    {
                        float deltaX = touch.position.x - _touchStartPosition.x;
                        transform.Rotate(Vector3.up, -deltaX * _rotationSpeed * Time.deltaTime);
                        _touchStartPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    _isRotating = false;
                    break;
            }
        }
    }
}
