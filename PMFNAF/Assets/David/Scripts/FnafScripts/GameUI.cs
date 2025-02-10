using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{
    [SerializeField] GameObject _cameraUI;
    [SerializeField] GameObject _officeUI;
    [SerializeField] GameObject _hideUI;
    [SerializeField] GameObject _pauseUI;
    [SerializeField] GameObject _camBtn;
    void Start()
    {
        ActivateOfficeUI();
        UnpauseGame();
    }
    void Update()
    {
        
    }
    public void BtnChangeCamera(int _camIndex)
    {
        GameManager.Instance.ChangeRooms(_camIndex + 1);
    }

    public void BtnFlipCameraAndOffice()
    {
        if (_cameraUI.activeSelf)
        {
            GameManager.Instance.ChangeRooms(0);
            ActivateOfficeUI();
        } else
        {
            ActivateCamUI();
        }
    }
    public void ActivateCamUI()
    {
        GameManager.Instance.GoToCameras();
        _cameraUI.SetActive(true);
        _officeUI.SetActive(false);
        _hideUI.SetActive(false);
    }
    public void ActivateOfficeUI()
    {
        GameManager.Instance.UnHide();
        _cameraUI.SetActive(false);
        _officeUI.SetActive(true);
        _hideUI.SetActive(false);
        _camBtn.SetActive(true);
    }
    public void ActivateHideUI()
    {
        GameManager.Instance.Hide();
        _cameraUI.SetActive(false);
        _officeUI.SetActive(false);
        _hideUI.SetActive(true);
        _camBtn.SetActive(false);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        _pauseUI.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1.0f;
        _pauseUI.SetActive(false);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Menu Scene");
    }
}
