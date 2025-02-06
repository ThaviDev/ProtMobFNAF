using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RoomManager : MonoBehaviour
{
    //[SerializeField] Dictionary<string, AnomalyClass> _anomalies = new Dictionary<string, AnomalyClass>();
    [SerializeField] GameObject[] _prefabAnomalies;
    [SerializeField] List<AnomalyClass> _currentAnomalies;
    [SerializeField] GameObject[] _objectsOnRoom;
    void Start()
    {
        // PRUEBA DE ANOMALIA ALEATORIA
        //var ranAnomaly = Random.Range(0, 3);
        var ranAnomaly = 1;
        var myAnom = Instantiate(_prefabAnomalies[ranAnomaly]);
        _currentAnomalies.Add(myAnom.GetComponent<AnomalyClass>());
        ActivateAnomaly(_currentAnomalies[0]);

    }

    private void ActivateAnomaly(AnomalyClass _myAnomaly)
    {
        switch (_myAnomaly.Type)
        {
            case 0:
                _objectsOnRoom[_myAnomaly.AffectedObject].SetActive(false);
                break;
            case 1:
                var curAnomalyTrans = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Translation>();
                _objectsOnRoom[_myAnomaly.AffectedObject]
                    .transform.position = curAnomalyTrans.GetAnomalusPos();
                break;
            case 2:
                var curAnomalyAnim = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Animation>();
                curAnomalyAnim.SetAnomalyON();
                break;
            case 3:
                var curAnomalyRot = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Rotation>();
                _objectsOnRoom[_myAnomaly.AffectedObject]
                    .transform.rotation = curAnomalyRot.GetAnomalusRotation();
                break;
            case 4:
                var curAnomalyScale = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Scale>();
                _objectsOnRoom[_myAnomaly.AffectedObject]
                    .transform.localScale = curAnomalyScale.GetAnomalusScale();
                break;
            case 5:
                var curAnomalyMat = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Material>();
                var renderer = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<MeshRenderer>();
                renderer.material = curAnomalyMat.GetAnomalusMat();
                break;
        }
    }

    private void DeactivateAnomaly(AnomalyClass _myAnomaly)
    {
        switch (_myAnomaly.Type)
        {
            case 0:
                _objectsOnRoom[_myAnomaly.AffectedObject].SetActive(true);
                break;
            case 1:
                var curAnomalyTrans = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Translation>();
                _objectsOnRoom[_myAnomaly.AffectedObject]
                    .transform.position = curAnomalyTrans.GetNormalPos();
                break;
            case 2:
                var curAnomalyAnim = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Animation>();
                curAnomalyAnim.SetAnomalyOFF();
                break;
            case 3:
                var curAnomalyRot = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Rotation>();
                _objectsOnRoom[_myAnomaly.AffectedObject]
                    .transform.rotation = curAnomalyRot.GetNormalRotation();
                break;
            case 4:
                var curAnomalyScale = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Scale>();
                _objectsOnRoom[_myAnomaly.AffectedObject]
                    .transform.localScale = curAnomalyScale.GetNormalScale();
                break;
            case 5:
                var curAnomalyMat = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<An_Material>();
                var renderer = _objectsOnRoom[_myAnomaly.AffectedObject].GetComponent<MeshRenderer>();
                renderer.material = curAnomalyMat.GetNormalMat();
                break;
        }
        _currentAnomalies.Remove(_myAnomaly);
        Destroy(_myAnomaly.gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeactivateAnomaly(_currentAnomalies[0]);
        }
    }
}
