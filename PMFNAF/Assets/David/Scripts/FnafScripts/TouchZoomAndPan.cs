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
    [SerializeField] private float rotationSpeed = 0.1f;
    [SerializeField] private Vector2 rotationLimitX = new Vector2(-45f, 45f); // Límites en el eje X
    [SerializeField] private Vector2 rotationLimitY = new Vector2(-45f, 45f); // Límites en el eje Y

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
            // Desplazamiento con un dedo
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                Vector2 touchDelta = touch.deltaPosition;
                RotateCamera(touchDelta);
            }
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
        float newRotationX = currentRotation.x - delta.y * rotationSpeed;
        float newRotationY = currentRotation.y + delta.x * rotationSpeed;

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