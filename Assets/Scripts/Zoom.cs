using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float sensitivity = 1;
    public Camera MainCamera;
    [HideInInspector]
    public float defaultFOV;
    [Tooltip("Effectively the min FOV that we can reach while zooming with this camera.")]
    public float maxZoom = 10;
    [HideInInspector]
    public float zoomAmount;


    void Awake()
    {
        MainCamera = gameObject.GetComponent<Camera>();
    }

    void Start()
    {
        defaultFOV = MainCamera.fieldOfView;
    }

    void Update()
    {
        zoomAmount += Input.mouseScrollDelta.y * sensitivity * .05f;
        zoomAmount = Mathf.Clamp01(zoomAmount);
        MainCamera.fieldOfView = Mathf.Lerp(defaultFOV, maxZoom, zoomAmount);
    }
}
