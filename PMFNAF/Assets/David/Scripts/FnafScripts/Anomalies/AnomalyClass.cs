using UnityEngine;

public class AnomalyClass : MonoBehaviour
{
    [Header("Tipos de Anomalia")]
    [Tooltip("0 - Desactivar Objeto\n" +
        "1 - Traslacion de Objeto\n" +
        "2 - Animacion de Objeto\n" +
        "3 - Rotacion de Objeto\n" +
        "4 - Escala de Objeto\n" +
        "5 - Textura de Objeto\n" +
        "6 - Activar Objeto\n" +
        "7 - Reemplazar Objeto\n")]
    public int Type;
    public int AffectedObject;
    public AnomalyClass(int type, int affectedObject)
    {
        Type = Mathf.Clamp(type, 0, 5);
        AffectedObject = affectedObject;
        // El numero depende del objeto establecido en la escena
    }
}