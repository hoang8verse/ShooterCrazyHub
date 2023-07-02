using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DebugMenuController : MonoBehaviour
{
    [SerializeField]
    private Button _btnMenuDebug;
    [SerializeField]
    private Button _btnClose;
    [SerializeField]
    private GameObject _menuObject;

    [SerializeField]
    private GameObject _cameraObject;
    [SerializeField]
    private GameObject _playerObject;
    [SerializeField]
    private GameObject _gameplayObject;
    [SerializeField]
    private GameObject _enemyObject;

    // Use this for initialization
    void Start()
    {
       
    }


    public void ButtonMenuDebug()
    {
        _btnMenuDebug.gameObject.SetActive(false);
        _menuObject.SetActive(true);
    }
    public void ButtonCloseMenuDebug()
    {
        _btnMenuDebug.gameObject.SetActive(true);
        _menuObject.SetActive(false);
    }

    public void ButtonSelectedMenu(string menu)
    {
        switch (menu)
        {
            case "camera":
                _cameraObject.SetActive(true);
                break;
            case "player":
                _playerObject.SetActive(true);
                break;
            case "gameplay":
                _gameplayObject.SetActive(true);
                break;
            case "enemy":
                _enemyObject.SetActive(true);
                break;
            default:
                break;
        }
        _menuObject.SetActive(false);
    }

    public void ButtonBackToMenu(string menu)
    {
        switch (menu)
        {
            case "camera":
                _cameraObject.SetActive(false);
                break;
            case "player":
                _playerObject.SetActive(false);
                break;
            case "gameplay":
                _gameplayObject.SetActive(false);
                break;
            case "enemy":
                _enemyObject.SetActive(false);
                break;
            default:
                break;
        }
        _menuObject.SetActive(true);
    }
}
