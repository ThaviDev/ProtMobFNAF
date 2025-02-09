using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _options;
    public void GoToOptions()
    {
        _mainMenu.SetActive(false);
        _options.SetActive(true);
    }
    public void GoToMainMenu()
    {
        _mainMenu.SetActive(true);
        _options.SetActive(false);
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Mobile Test Scene");
    }
}
