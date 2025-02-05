using UnityEngine;

public class AnomalyClass : MonoBehaviour
{
    public int Type;
    public int Obviousness;
    public int AffectedObject;
    public AnomalyClass(int type, int obviousness, int affectedObject)
    {
        Type = Mathf.Clamp(type, 0, 5);
        /* 0 - Desactivar Objeto
         * 1 - Traslacion de Objeto
         * 2 - Animacion de Objeto
         * 3 - Rotacion de Objeto
         * 4 - Escala de Objeto
         * 5 - Textura de Objeto */
        Obviousness = Mathf.Clamp(obviousness, 0, 3);
        /* 0 - Nada Obvio
         * 1 - Poco Obvio
         * 2 - Algo Obvio
         * 3 - Muy Obvio */
        AffectedObject = affectedObject;
        // El numero depende del objeto establecido en la escena
    }
}