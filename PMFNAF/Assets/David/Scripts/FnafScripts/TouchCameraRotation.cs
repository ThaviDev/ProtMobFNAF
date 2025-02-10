using UnityEngine;
using UnityEngine.EventSystems;

public class TouchCameraRotation : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField][Range(0f, 0.5f)] private float uiDeadZone = 0.05f;

    private float targetRotationY;
    private float currentVelocity;

    void Update()
    {
        HandleMobileInput();

        ApplyRotation();
    }

    void HandleMobileInput()
    {
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                // Ignorar toques sobre UI
                if (IsPointerOverUIObject(touch.fingerId)) return;

                // Calcular zonas activas
                float screenWidth = Screen.width;
                float activeZoneLeft = screenWidth * uiDeadZone;
                float activeZoneRight = screenWidth * (1 - uiDeadZone);

                if (touch.position.x < activeZoneLeft || touch.position.x > activeZoneRight) return;

                if (touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved)
                {
                    float screenMiddle = Screen.width * 0.5f;

                    if (touch.position.x < screenMiddle)
                    {
                        targetRotationY -= rotationSpeed;
                    }
                    else
                    {
                        targetRotationY += rotationSpeed;
                    }
                }
            }
        }
    }
    [SerializeField] private Vector2 yRotationLimits = new Vector2(-45f, 45f);
    void ApplyRotation()
    {
        targetRotationY = Mathf.Clamp(targetRotationY, yRotationLimits.x, yRotationLimits.y);

        float smoothedY = Mathf.SmoothDampAngle(
            transform.eulerAngles.y,
            targetRotationY,
            ref currentVelocity,
            smoothTime
        );

        transform.rotation = Quaternion.Euler(
            transform.eulerAngles.x,
            smoothedY,
            transform.eulerAngles.z
        );
    }
    private bool IsPointerOverUIObject(int fingerId = -1)
    {
        if (fingerId != -1)
        {
            return EventSystem.current.IsPointerOverGameObject(fingerId);
        }
        else
        {
            return EventSystem.current.IsPointerOverGameObject();
        }
    }
}