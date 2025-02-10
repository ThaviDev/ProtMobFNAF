using UnityEngine;

public class RotateWithTouch : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 0.5f;
    private bool isRotating = false;
    private Vector2 initialTouchPosition;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    //Detecta si el toque está sobre el objeto
                    Ray ray = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit) && hit.transform == transform)
                    {
                        isRotating = true;
                        initialTouchPosition = touch.position;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isRotating)
                    {
                        //Calcula el dedo horizontal
                        float deltaX = touch.deltaPosition.x;
                        float rotationAmount = deltaX * rotationSpeed * Time.deltaTime;
                        transform.Rotate(0, -rotationAmount, 0);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isRotating = false;
                    break;
            }
        }
    }
}