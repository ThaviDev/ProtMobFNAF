using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    [SerializeField] RoomManager[] _myRooms;
    [SerializeField] MainRoom _mainRoom;
    private int _currentRoom = 0;
    private float _currentTime;
    private int _monsterLocation;
    private int _lastCamera = 1; //este checa cual fue la ultima camara que vio el jugador para regresar a esta al abrir las camaras
    [SerializeField] private HideCamera _hideCamera;
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
        if (_currentRoom == 0)
        {
            _mainRoom.DeactivateRoom();
        } else
        {
            _myRooms[_currentRoom - 1].DeactivateRoom();
        }

        if(newRoom == 0)
        {
            _mainRoom.ActivateRoom();
            _lastCamera = _currentRoom;
        } else
        {
            _myRooms[newRoom - 1].ActivateRoom();
        }
        _currentRoom = newRoom;
    }

    public void GoToCameras()
    {
        ChangeRooms(_lastCamera);
    }
}
