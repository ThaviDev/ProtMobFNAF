using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ARCharacterController : MonoBehaviour
{
    [Header("Animations")]
    [SerializeField] private Animator characterAnimator;
    private int currentAnimationIndex = 0;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 10f;
    private Vector2 touchStartPosition;
    private bool isRotating = false;

    [Header("Scale")]
    [SerializeField] private Slider scaleSlider;
    [SerializeField] private Vector2 scaleRange = new Vector2(0.5f, 2f);

    private void Start()
    {
        // Configurar slider
        scaleSlider.minValue = scaleRange.x;
        scaleSlider.maxValue = scaleRange.y;
        scaleSlider.value = 1f;
        scaleSlider.onValueChanged.AddListener(ScaleCharacter);

        // Iniciar con primera animación
        ChangeAnimation(0);
    }

    private void Update()
    {
        HandleTouchRotation();
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
                    touchStartPosition = touch.position;
                    isRotating = true;
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        float deltaX = touch.position.x - touchStartPosition.x;
                        transform.Rotate(Vector3.up, -deltaX * rotationSpeed * Time.deltaTime);
                        touchStartPosition = touch.position;
                    }
                    break;

                case TouchPhase.Ended:
                    isRotating = false;
                    break;
            }
        }
    }

    public void ScaleCharacter(float newScale)
    {
        transform.localScale = Vector3.one * newScale;
    }

    public void ChangeAnimation()
    {
        currentAnimationIndex = (currentAnimationIndex + 1) % 3;
        ChangeAnimation(currentAnimationIndex);
    }

    private void ChangeAnimation(int index)
    {
        switch (index)
        {
            case 0:
                characterAnimator.Play("Animation1");
                break;
            case 1:
                characterAnimator.Play("Animation2");
                break;
            case 2:
                characterAnimator.Play("Animation3");
                break;
        }
    }
}