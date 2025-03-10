using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField] RoomManager[] _myRooms;
    [SerializeField] MainRoom _mainRoom;
    private int _currentRoom = 0;
    private float _currentAgresivity;
    /* -1: ningun lado
     * -2: en la puerta derecha de la oficina
     * -3: en la puerta izquierda de la oficina
     * 0: adentro de la oficina
     * 1: habitacion 1
     * 2...
     */
    private int _lastCamera = 1; //este checa cual fue la ultima camara que vio el jugador para regresar a esta al abrir las camaras
    [SerializeField] private HideCamera _hideCamera;
    private bool _isInOffice;
    [SerializeField] private Canvas _cameraCanvas;
    public bool GetIsInOffice
    {
        get { return _isInOffice; }
    }
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameManager();
            }
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        _isInOffice = true;
        //_mainRoom.ActivateRoom();
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.T)) 
        {
            ChangeRooms(0);
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            ChangeRooms(1);
        }
        if (Input.GetKeyUp(KeyCode.R))
        {
            ChangeRooms(2);
        }
    }

    public void Hide()
    {
        _hideCamera.HideCam();
    }
    public void UnHide()
    {
        _hideCamera.UnhideCam();
    }

    public void ChangeRooms(int newRoom)
    {
        if (_currentRoom == newRoom)
        {
            return;
        }
        if (_currentRoom == 0)
        {
            _mainRoom.DeactivateRoom();
        } else
        {
            _myRooms[_currentRoom - 1].DeactivateRoom();
        }

        if(newRoom == 0)
        {
            _isInOffice = true;
            _mainRoom.ActivateRoom();
            _lastCamera = _currentRoom;
        } else
        {
            _isInOffice = false;
            _myRooms[newRoom - 1].ActivateRoom();
        }
        _currentRoom = newRoom;
        _cameraCanvas.worldCamera = Camera.main;
    }

    public void GoToCameras()
    {
        ChangeRooms(_lastCamera);
    }
}
