using UnityEngine;

public class TouchZoomAndPan : MonoBehaviour
{
    [Header("Configuracion de Zoom")]
    [SerializeField] private float _zoomSpeed = 0.1f;
    [SerializeField] private float _zoomSpeedMouse = 20f;
    [SerializeField] private float _minZoom = 10f;
    [SerializeField] private float _maxZoom = 60f;

    [Header("Configuracion de Desplazamiento")]
    [SerializeField] private float _panSpeed = 0.003f;
    [SerializeField] private Vector2 _panLimitX = new Vector2(-10f, 10f);
    [SerializeField] private Vector2 _panLimitY = new Vector2(-10f, 10f);
    [SerializeField] private float _rotationSpeed = 0.1f;
    [SerializeField] private float _rotationSpeedMouse = 20f;
    [SerializeField] private Vector2 _rotationLimitX = new Vector2(-45f, 45f); // Límites en el eje X
    [SerializeField] private Vector2 _rotationLimitY = new Vector2(-45f, 45f); // Límites en el eje Y
    [SerializeField] private float _minXRotation;
    [SerializeField] private float _maxXRotation;
    [SerializeField] private float _minYRotation;
    [SerializeField] private float _maxYRotation;

    private Camera _cam;
    private Vector3 _initialPosition;
    private float _initialFOV;

    void Start()
    {
        _cam = GetComponent<Camera>();
        _initialPosition = transform.position;
        _initialFOV = _cam.fieldOfView;
    }

    void Update()
    {
        HandleTouchInput();
    }

    void HandleTouchInput()
    {
        if (Input.touchCount == 1)
        {
            Touch _touch = Input.GetTouch(0);
            Vector3 rotationDelta = _rotationSpeed * new Vector3(
                _touch.deltaPosition.y,
                -_touch.deltaPosition.x,
                0
            );

            ApplyRotation(rotationDelta);
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 rotationDelta = _rotationSpeedMouse * new Vector3(
                Input.GetAxis("Mouse Y"),    // Invertido para coincidir con touch
                -Input.GetAxis("Mouse X"),  // Invertido para coincidir con touch
                0
            );

            ApplyRotation(rotationDelta);
        }
        else if (Input.touchCount == 2)
        {
            // Zoom con dos dedos
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            float prevMagnitude = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float currentMagnitude = (touchZero.position - touchOne.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;
            ZoomCamera(difference * _zoomSpeed);
        }
        float scroll = Input.mouseScrollDelta.y;
        Debug.Log(scroll);
        if (scroll != 0)
        {
            Debug.Log("Hago Zoom");
            ZoomCamera(-scroll * _zoomSpeedMouse);
        }
    }
    void ApplyRotation(Vector3 rotationDelta)
    {
        // Calcular rotación con límites
        float newX = Mathf.Clamp(
            transform.eulerAngles.x + rotationDelta.x,
            _minXRotation,
            _maxXRotation
        );

        float newY = Mathf.Clamp(
            transform.eulerAngles.y + rotationDelta.y,
            _minYRotation,
            _maxYRotation
        );

        // Aplicar rotación
        transform.eulerAngles = new Vector3(
            newX,
            newY,
            transform.eulerAngles.z
        );
    }
    void ZoomCamera(float increment)
    {
        _cam.fieldOfView = Mathf.Clamp(_cam.fieldOfView - increment, _minZoom, _maxZoom);
    }
    // Función para asegurar que los ángulos estén dentro de un rango
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}