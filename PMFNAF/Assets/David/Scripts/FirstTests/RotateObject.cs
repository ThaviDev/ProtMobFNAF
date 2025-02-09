using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float _pcRotSpeed = 10f;
    [SerializeField] float _mobRotSpeed = 10f;
    [SerializeField] Vector2 _startTouchPosition; // Posición inicial del toque
    [SerializeField] Vector2 _currentTouchPosition; // Posición actual del toque
    bool _dragging = false;
    [SerializeField] Rigidbody _rb;
    void Start()
    {

    }



    /*
    private void OnMouseDrag()
    {
        float rot = Input.GetAxis("Mouse X") * _pcRotSpeed;

        //Input.touchCount Cantidad de dedos tocando la pantalla
        // Dedo 0 es el primero
        // Detectar la posición inicial a la nueva posición para identificar dirección
        // Click es en el momento en el que se detecta el dedo, haciendo un raycast a la pantalla cuando choque
        // O detectar el click del mouse, Input.GetMouseButtonDown.
        //
        // El APK de unity lo podemos pasar al teléfono, lo mandas cómo un documento

        /*
        Vector3 right = Vector3.Cross
            (rhs: _cam.transform.up, 
            rhs: _cam.transform.position - _cam.transform.position);


    }
            */
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == UnityEngine.TouchPhase.Ended )
        {
            //Input.touches[0].
            print("Tap en " + Input.touches[0].position);
        }

        // Verificar si hay toques en la pantalla
        if (Input.touchCount > 0)
        {
            Touch touch = Input.touches[0];

            switch (touch.phase)
            {
                case UnityEngine.TouchPhase.Began:
                    // Guardar la posición inicial del toque
                    _startTouchPosition = touch.position;
                    _dragging = true;
                    break;

                case UnityEngine.TouchPhase.Moved:
                    if (_dragging)
                    {
                        // Actualizar la posición actual del toque
                        _currentTouchPosition = touch.position;

                        // Calcular la diferencia entre la posición actual y la inicial
                        Vector2 deltaPosition = _currentTouchPosition - _startTouchPosition;

                        // Aplicar rotación al objeto (horizontal y vertical)
                        float rotationX = deltaPosition.y * _pcRotSpeed; // Arriba/abajo rota en X
                        float rotationY = -deltaPosition.x * _pcRotSpeed; // Izquierda/derecha rota en Y

                        transform.Rotate(rotationX, rotationY, 0, Space.World);

                        // Actualizar la posición inicial para el siguiente frame
                        _startTouchPosition = _currentTouchPosition;
                    }
                    break;

                case UnityEngine.TouchPhase.Ended:
                case UnityEngine.TouchPhase.Canceled:
                    // Terminar el deslizamiento
                    _dragging = false;
                    break;
            }
        }
        /*
        // Verificar si hay al menos un toque en la pantalla
        if (Input.touchCount > 0)
        {
            // Obtener el primer toque
            Touch touch = Input.touches[0];

            // Verificar si el toque terminó (indicando un "Tap")
            if (touch.phase == UnityEngine.TouchPhase.Ended)
            {
                // Registrar la posición del toque en la consola
                Debug.Log("Tap detectado en posición: " + touch.position);
            }
        }
        */
        if (Input.GetMouseButtonUp(0))
        {
            _dragging = false;
        }
    }

    void OnMouseDrag()
    {
        _dragging = true;
    }

    private void FixedUpdate()
    {
        if (_dragging)
        {
            //float AxisX = Input.GetAxis ("Mouse X") * _pcRotSpeed * Time.fixedDeltaTime;
            //float AxisY = Input.GetAxis ("Mouse Y") * _pcRotSpeed * Time.fixedDeltaTime;

            //_ObjRB.AddTorque(Vector3.down * x);
            //_ObjRB.AddTorque(Vector3.right * y);
        }
    }
}
