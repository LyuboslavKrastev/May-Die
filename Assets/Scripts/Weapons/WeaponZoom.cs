using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera _camera;
    private float _normalFieldOfView;
    private float _zoomedFieldOfView;

    private Vector3 _normalPosition;
    private Vector3 _zoomedPosition = new Vector3(-0.05f, -0.084f, 0.1152f);

    private Quaternion _normalRotation;
    private Quaternion _zoomedRotation = Quaternion.Euler(-2.7f, -13.3f, 0f);

    [SerializeField] private Canvas _crossHair;

    private float _zoomStrength = -20;

    void Start()
    {
        _camera = transform.parent.parent.GetComponentInChildren<Camera>();
        if (_camera == null)
        {
            Debug.LogError("Camera is NULL!");
        }

        SetupZoom();

        _normalPosition = transform.localPosition;
        _normalRotation = transform.localRotation;
    }
    private void SetupZoom()
    {
        _normalFieldOfView = _camera.fieldOfView;
        _zoomedFieldOfView = _normalFieldOfView + _zoomStrength;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            IronSightsFire();
        }
        else
        {
            HipFire();
        }
    }

    private void HipFire()
    {
        _crossHair.enabled = true;
        _camera.fieldOfView = _normalFieldOfView;
        transform.localPosition = _normalPosition;
        transform.localRotation = _normalRotation;
    }

    private void IronSightsFire()
    {
        _crossHair.enabled = false;
        _camera.fieldOfView = _zoomedFieldOfView;
        transform.localPosition = _zoomedPosition;
        transform.localRotation = _zoomedRotation;
    }
}
