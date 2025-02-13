using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TouchCameraRotation : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float rotationSpeed = 0.5f;
    [SerializeField] private float smoothTime = 0.1f;
    [SerializeField][Range(0f, 0.5f)] private float uiDeadZone = 0.05f;
    [SerializeField] private Vector2 yRotationLimits = new Vector2(-45f, 45f);

    private float targetRotationY;
    private float currentVelocity;

    private GraphicRaycaster graphicRaycaster; // Para detectar UI
    private EventSystem eventSystem;

    void Update()
    {
        HandleMobileInput();
        ApplyRotation();
    }

    void HandleMobileInput()
    {
        if (Input.touchCount > 0)
        {
            // Verificar primero si hay toques sobre UI
            foreach (Touch touch in Input.touches)
            {
                if (IsPointerOverUIObject(touch.fingerId))
                {
                    return; // Si cualquier toque está sobre UI, no procesar
                }
            }

            // Procesar toques solo si ninguno está sobre UI
            foreach (Touch touch in Input.touches)
            {
                float screenWidth = Screen.width;
                float activeZoneLeft = screenWidth * uiDeadZone;
                float activeZoneRight = screenWidth * (1 - uiDeadZone);

                if (touch.position.x < activeZoneLeft || touch.position.x > activeZoneRight) continue;

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