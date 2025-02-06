using UnityEngine;

public class AnomalyClass : MonoBehaviour
{
    public int Type;
    public int AffectedObject;
    public AnomalyClass(int type, int affectedObject)
    {
        Type = Mathf.Clamp(type, 0, 5);
        /* 0 - Desactivar Objeto
         * 1 - Traslacion de Objeto
         * 2 - Animacion de Objeto
         * 3 - Rotacion de Objeto
         * 4 - Escala de Objeto
         * 5 - Textura de Objeto */
        AffectedObject = affectedObject;
        // El numero depende del objeto establecido en la escena
    }
}