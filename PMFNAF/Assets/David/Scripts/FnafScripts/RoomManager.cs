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
        var ranAnomaly = 0;
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
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
        }
    }

    private void DeactivateAnomaly(AnomalyClass _myAnomaly)
    {

    }

    void Update()
    {
        
    }
}
