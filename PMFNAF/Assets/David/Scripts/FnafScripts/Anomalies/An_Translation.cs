using UnityEngine;

public class An_Translation : MonoBehaviour
{
    Vector3 _normalPosition;
    [SerializeField] Vector3 _anomalusPosition;
    private void Start()
    {
        _normalPosition = transform.position;
    }

    public Vector3 GetNormalPos()
    {
        return _normalPosition;
    }

    public Vector3 GetAnomalusPos()
    {
        return _anomalusPosition;
    }
}
