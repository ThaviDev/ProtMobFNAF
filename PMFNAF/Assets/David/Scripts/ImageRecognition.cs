using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognition : MonoBehaviour
{
    public GameObject modelPrefab; // Prefab del modelo 3D a instanciar
    private ARTrackedImageManager _trackedImageManager;

    void Awake()
    {
        _trackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        _trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        _trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        // Cuando se detecta una nueva imagen
        foreach (var trackedImage in args.added)
        {
            SpawnModel(trackedImage);
        }

        // Cuando el seguimiento de una imagen cambia
        foreach (var trackedImage in args.updated)
        {
            UpdateModel(trackedImage);
        }

        // Cuando una imagen pierde el seguimiento
        foreach (var trackedImage in args.removed)
        {
            Destroy(trackedImage.gameObject);
        }
    }

    private void SpawnModel(ARTrackedImage trackedImage)
    {
        // Instanciar el modelo en la posición de la imagen detectada
        GameObject spawnedObject = Instantiate(modelPrefab, trackedImage.transform.position, trackedImage.transform.rotation);
        spawnedObject.transform.parent = trackedImage.transform;
    }

    private void UpdateModel(ARTrackedImage trackedImage)
    {
        // Actualizar el estado del modelo según el estado de la imagen
        if (trackedImage.trackingState == TrackingState.Tracking)
        {
            trackedImage.transform.GetChild(0).gameObject.SetActive(true);
        }
        else
        {
            trackedImage.transform.GetChild(0).gameObject.SetActive(false);
        }
    }
}
