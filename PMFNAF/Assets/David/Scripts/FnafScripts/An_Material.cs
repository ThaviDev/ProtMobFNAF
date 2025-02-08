using UnityEngine;

public class An_Material : MonoBehaviour
{
    [SerializeField] private Material _normalMat;
    [SerializeField] private Material _anomalusMat;
    public Material GetNormalMat()
    {
        return _normalMat;
    }
    public Material GetAnomalusMat()
    {
        return _anomalusMat;
    }
}
