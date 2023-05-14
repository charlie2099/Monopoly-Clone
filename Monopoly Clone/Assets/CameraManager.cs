using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CameraManager : MonoBehaviour // Camera Target / Active Camera / Toggle Camera / Camera Controller
{
    [SerializeField] private Camera frontCamera;
    [SerializeField] private Camera topDownCamera;
    [SerializeField] private Camera followCamera;
    [SerializeField] private Button frontCameraButton;
    [SerializeField] private Button topDownCameraButton;
    [SerializeField] private Button followCameraButton;
    private Dictionary<Camera, bool> activeCameras;
    private UnityAction frontCameraListener;
    private UnityAction topDownCameraListener;
    private UnityAction followCameraListener;

    private void Awake()
    {
        activeCameras = new Dictionary<Camera, bool>
        {
            {frontCamera, true},
            {topDownCamera, false},
            {followCamera, false}
        };
    }

    private void Start() => OnlyShowCamera(frontCamera);
    private void OnEnable() => SubscribeToButtonListeners();
    private void OnDisable() => UnsubscribeToButtonListeners();

    private void OnlyShowCamera(Camera chosenCamera)
    {
        var cameraKeys = activeCameras.Keys.ToList();
        foreach (var cam in cameraKeys)
        {
            bool isActive = cam == chosenCamera;
            activeCameras[cam] = isActive;
            cam.gameObject.SetActive(isActive);
        }
    }

    private void SetCameraActive(Camera chosenCamera)
    {
        OnlyShowCamera(chosenCamera);
    }

    private void SubscribeToButtonListeners()
    {
        frontCameraListener = () => SetCameraActive(frontCamera);
        topDownCameraListener = () => SetCameraActive(topDownCamera);
        followCameraListener = () => SetCameraActive(followCamera);
        
        frontCameraButton.onClick.AddListener(frontCameraListener);
        topDownCameraButton.onClick.AddListener(topDownCameraListener);
        followCameraButton.onClick.AddListener(followCameraListener);
    }

    private void UnsubscribeToButtonListeners()
    {
        frontCameraButton.onClick.RemoveListener(frontCameraListener);
        topDownCameraButton.onClick.RemoveListener(topDownCameraListener);
        followCameraButton.onClick.RemoveListener(followCameraListener);
    }
}
