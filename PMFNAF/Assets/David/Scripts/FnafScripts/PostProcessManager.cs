using UnityEngine;

public class PostProcessManager : MonoBehaviour
{
    [SerializeField] private GameObject _normalView;
    [SerializeField] private GameObject _cameraView;
    private bool _isInOffice;
    void Start()
    {
        _isInOffice = GameManager.Instance.GetIsInOffice;
        ChangePostProcessingEffect(_isInOffice);
    }
    void Update()
    {
        if (_isInOffice != GameManager.Instance.GetIsInOffice)
        {
            _isInOffice = GameManager.Instance.GetIsInOffice;
            ChangePostProcessingEffect(_isInOffice);
        }
    }

    void ChangePostProcessingEffect(bool curState)
    {
        if (curState)
        {
            _normalView.SetActive(true);
            _cameraView.SetActive(false);
        } else
        {
            _normalView.SetActive(false);
            _cameraView.SetActive(true);
        }
    }
}
