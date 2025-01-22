using UnityEngine;

public class ChangeColorMat : MonoBehaviour
{
    [SerializeField] Material[] _mats;
    [SerializeField] MeshRenderer _meshRenderer;
    int _curMatIndex;
    void Start()
    {
        _curMatIndex = 0;
    }

    public void ChangeColor()
    {
        if (_curMatIndex < 2)
        {
            _curMatIndex++;
        } else
        {
            _curMatIndex = 0;
        }
        _meshRenderer.material = _mats[_curMatIndex];
    }
}
