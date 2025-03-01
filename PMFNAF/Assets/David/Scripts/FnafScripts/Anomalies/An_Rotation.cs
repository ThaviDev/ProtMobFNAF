using UnityEngine;

public class An_Rotation : MonoBehaviour
{
    Quaternion _normalRotation;
    [SerializeField] Quaternion _anomalusRotation;
    void Start()
    {
        _normalRotation = transform.rotation;
    }
    public Quaternion GetNormalRotation()
    {
        return _normalRotation;
    }

    public Quaternion GetAnomalusRotation()
    {
        return _anomalusRotation;
    }
}
