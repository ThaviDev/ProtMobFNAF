using UnityEngine;

public class TouchZoomAndPan : MonoBehaviour
{
    [Header("Configuracion de Zoom")]
    [SerializeField] private float zoomSpeed = 0.1f;
    [SerializeField] private float minZoom = 10f;
    [SerializeField] private float maxZoom = 60f;

    [Header("Configuracion de Desplazamiento")]
    [SerializeField] private float panSpeed = 0.003f;
    [SerializeField] private Vector2 panLimitX = new Vector2(-10f, 10f);
    [SerializeField] private Vector2 panLimitY = new Vector2(-10f, 10f);
    [SerializeField] private float _rotationSpeed = 0.1f;
    [SerializeField] private Vector2 rotationLimitX = new Vector2(-45f, 45f); // Límites en el eje X
    [SerializeField] private Vector2 rotationLimitY = new Vector2(-45f, 45f); // Límites en el eje Y
    [SerializeField] private float _minXRotation;
    [SerializeField] private float _maxXRotation;
    [SerializeField] private float _minYRotation;
    [SerializeField] private float _maxYRotation;

    private Camera cam;
    private Vector3 initialPosition;
    private float initialFOV;

    void Start()
    {
        cam = GetComponent<Camera>();
        initialPosition = transform.position;
        initialFOV = cam.fieldOfView;
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

            // Obtener rotación actual y convertir a rango -180 a 180
            /*
            Vector3 currentEuler = transform.eulerAngles;
            float currentX = currentEuler.x > 180f ? currentEuler.x - 360f : currentEuler.x;
            float currentY = currentEuler.y > 180f ? currentEuler.y - 360f : currentEuler.y;
            */

            // Calcular rotacion con limites
            float newX = Mathf.Clamp(transform.eulerAngles.x + rotationDelta.x, _minXRotation, _maxXRotation);
            float newY = Mathf.Clamp(transform.eulerAngles.y + rotationDelta.y, _minYRotation, _maxYRotation);

            // Aplicar rotacion
            transform.eulerAngles = new Vector3(newX, newY, transform.eulerAngles.z);

            /*
            transform.eulerAngles += _rotationSpeed * new Vector3(_touch.deltaPosition.y,
                _touch.deltaPosition.x * -1, z: 0);
            /*
            // Desplazamiento con un dedo
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.deltaPosition;
                RotateCamera(touchDelta);
            }
            */
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
            ZoomCamera(difference * zoomSpeed);
        }
    }

    void ZoomCamera(float increment)
    {
        cam.fieldOfView = Mathf.Clamp(cam.fieldOfView - increment, minZoom, maxZoom);
    }
    /*
    void PanCamera(Vector2 delta)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += delta.x * panSpeed;
        newPosition.y -= delta.y * panSpeed;

        // Limitar el movimiento dentro de los límites
        newPosition.x = Mathf.Clamp(newPosition.x, panLimitX.x, panLimitX.y);
        newPosition.y = Mathf.Clamp(newPosition.y, panLimitY.x, panLimitY.y);

        transform.position = newPosition;
    } */
    void RotateCamera(Vector2 delta)
    {
        // Obtener la rotación actual
        Vector3 currentRotation = transform.eulerAngles;

        // Calcular la nueva rotación
        float newRotationX = currentRotation.x - delta.y * _rotationSpeed;
        float newRotationY = currentRotation.y + delta.x * _rotationSpeed;

        // Aplicar límites de rotación
        newRotationX = ClampAngle(newRotationX, rotationLimitX.x, rotationLimitX.y);
        newRotationY = ClampAngle(newRotationY, rotationLimitY.x, rotationLimitY.y);

        // Aplicar la rotación (sin rotación en el eje Z)
        transform.rotation = Quaternion.Euler(newRotationX, newRotationY, 0);
    }

    // Función para asegurar que los ángulos estén dentro de un rango
    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f) angle += 360f;
        if (angle > 360f) angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }
}