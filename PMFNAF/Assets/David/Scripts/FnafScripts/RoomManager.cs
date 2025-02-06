using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RoomManager : MonoBehaviour
{
    //[SerializeField] Dictionary<string, AnomalyClass> _anomalies = new Dictionary<string, AnomalyClass>();
    [SerializeField] GameObject[] _prefabAnomalies;
    Dictionary<int, AnomalyClass> _currentAnomalies = new Dictionary<int, AnomalyClass>();
    //[SerializeField] List<AnomalyClass> _currentAnomalies;
    //[SerializeField] List<int> _currentIDAnomalies;
    [SerializeField] GameObject[] _objectsOnRoom;

    [SerializeField] private GameObject _zombieActor;
    [SerializeField] private GameObject _roomParent;


    void Start()
    {
        /*
        // PRUEBA DE ANOMALIA ALEATORIA
        print(_prefabAnomalies.Length);
        //print(_currentIDAnomalies.Count);
        print(_currentAnomalies.Count);
        for (int i = 0; i < 6; i++)
        {
            StartRandomAnomaly();
        }
        DestroyAnAnomaly();
        */
    }

    public void StartRandomAnomaly()
    {
        if (_currentAnomalies.Count >= _prefabAnomalies.Length)
        {
            print("Ya estan todas las anomalias posibles");
            return;
        } else
        {
            // Primero se genera un numero aleatorio para instanciar una anomalia aleatoria
            var ranAnomaly = Random.Range(0, _prefabAnomalies.Length);
            // Si ya fue instanciada esa anomalia se vuelve a generar un numero aleatorio hasta que
            // se encuentre una anomalia que no haya sido instanciada anteriormente
            while (_currentAnomalies.ContainsKey(ranAnomaly))
            {
                ranAnomaly = Random.Range(0, _prefabAnomalies.Length);
            }
            // Se instancia el objeto guardandolo en una variable temporal
            var myAnom = Instantiate(_prefabAnomalies[ranAnomaly]);
            // Se guarda la variable de la clase para la información
            _currentAnomalies.Add(ranAnomaly,myAnom.GetComponent<AnomalyClass>());
            // Se activa la anomalia, aniadiendo una anomalia a la cantidad actual de anomalias
            ActivateAnomaly(_currentAnomalies[ranAnomaly]);
        }
    }

    public void DestroyAnAnomaly()
    {
        if (_currentAnomalies.Count <= 0)
        {
            print("No hay anomalias en la habitacion");
        } else
        {
            // Se encuentra la anomalia mas obvia de la lista (de la ultima a la primera en las prefab anomalies)
            int anomalyKey = FindMaxKeyForObviusness();
            DeactivateAnomaly(_currentAnomalies[anomalyKey]);
            Destroy(_currentAnomalies[anomalyKey].gameObject);
            _currentAnomalies.Remove(anomalyKey);
        }
    }

    private int FindMaxKeyForObviusness()
    {
        int maxKey = -1;
        foreach(int key in _currentAnomalies.Keys) {
            if (key > maxKey){
                maxKey = key;
            }
        }
        return maxKey;
    }

    private void ActivateAnomaly(AnomalyClass _myAnomaly)
    {
        Debug.Log($"Activando anomalía de tipo {_myAnomaly.Type} en el objeto {_myAnomaly.AffectedObject}");
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
    }

    void Update()
    {
        /*
        // ESTO ES DE PRUEBA
        if (Input.GetKeyDown(KeyCode.Space))
        {
            DeactivateAnomaly(_currentAnomalies[0]);
        }
        */
        if (Input.GetKeyDown(KeyCode.J))
        {
            StartRandomAnomaly();
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            DestroyAnAnomaly();
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            _zombieActor.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            _zombieActor.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            _roomParent.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            _roomParent.SetActive(true);
        }
    }
}
