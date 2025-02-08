using UnityEngine;

public class An_Replace : MonoBehaviour
{
    [SerializeField] private GameObject _normalObj;
    [SerializeField] private GameObject _anomalusObj;
    public void SetNormalObj()
    {
        _normalObj.SetActive(true);
        _anomalusObj.SetActive(false);
    }
    public void SetAnomalusObj()
    {
        _normalObj.SetActive(false);
        _anomalusObj.SetActive(true);
    }
}
