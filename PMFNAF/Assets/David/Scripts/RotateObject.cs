using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class RotateObject : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] float _pcRotSpeed = 10f;
    [SerializeField] float _mobRotSpeed = 10f;
    bool _dragging = false;
    [SerializeField] Rigidbody _ObjRB;
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
