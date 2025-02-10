using UnityEngine;

public class MainRoom : MonoBehaviour
{
    [SerializeField] private GameObject _room;
    [SerializeField] private GameObject _zombieLeft;
    [SerializeField] private GameObject _zombieRight;

    public void ActivateRoom()
    {
        _room.SetActive(true);
    }
    public void DeactivateRoom() {
        _room.SetActive(false);
    }
    public void ActivateZombie(bool _isRight)
    {
        if (_isRight)
        {
            _zombieRight.SetActive(true);
        } else
        {
            _zombieLeft.SetActive(true);
        }
    }
    public void DeactivateZombie()
    {
        _zombieLeft.SetActive(false);
        _zombieRight.SetActive(false);
    }
}
