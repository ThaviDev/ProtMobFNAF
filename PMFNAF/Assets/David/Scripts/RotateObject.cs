using UnityEngine;
public class RotateObject : MonoBehaviour
{
    [SerializeField] Camera _cam;
    [SerializeField] float _pcRotSpeed;
    [SerializeField] float _mobRotSpeed;
    void Start()
    {
        
    }

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
        */

    }
    void Update()
    {
        
    }
}
