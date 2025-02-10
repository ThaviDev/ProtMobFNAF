using UnityEngine;

public class HideCamera : MonoBehaviour
{
    [SerializeField] Vector3 _normalPos;
    [SerializeField] Vector3 _hidePos;
    private void Start()
    {
        UnhideCam();
    }
    public void HideCam()
    {
        this.gameObject.transform.position = _hidePos;
    }
    public void UnhideCam()
    {
        this.gameObject.transform.position = _normalPos;
    }
}
