using UnityEngine;

public class An_Scale : MonoBehaviour
{
    Vector3 _normalScale;
    [SerializeField] Vector3 _anomalusScale;
    void Start()
    {
        _normalScale = transform.localScale;
    }
    public Vector3 GetNormalScale()
    {
        return _normalScale;
    }

    public Vector3 GetAnomalusScale()
    {
        return _anomalusScale;
    }
}
