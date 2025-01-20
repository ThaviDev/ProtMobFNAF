using UnityEngine;
using UnityEngine.InputSystem;

public class MyInputManager : MonoBehaviour
{
    static PlayerInput _input;
    [SerializeField] PlayerInput _playerInputRef;

    Vector2 _touchInput;

    private void Awake()
    {
        _input = _playerInputRef;
    }

    public Vector2 TouchInput
    {
        get { return _touchInput; }
    }
    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnDragInput(InputAction.CallbackContext context)
    {
        _touchInput = context.ReadValue<Vector2>();
    }

    /*
    public static Vector2 OnTouchInput()
    {
        return _input.actions.FindAction("DragInput").activeValueType == typeof(Vector2);
    }*/
}
