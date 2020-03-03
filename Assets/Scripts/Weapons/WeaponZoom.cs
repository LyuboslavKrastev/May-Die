using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

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

    private RigidbodyFirstPersonController _fpsController;

    private float _hipSensitivity = 2f;
    private float _sightsSensitivity = 1f;


    private float _zoomStrength = -20;

    void Awake()
    {
        _camera = FindObjectOfType<Camera>();
        NullAlerter.AlertIfNull(_camera, nameof(_camera));

        _fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
        NullAlerter.AlertIfNull(_fpsController, nameof(_fpsController));

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

    private void OnDisable()
    {
        HipFire();
    }

    private void HipFire()
    {
        if (_crossHair != null)
        {
            _crossHair.enabled = true;
        }
        _camera.fieldOfView = _normalFieldOfView;
        transform.localPosition = _normalPosition;
        transform.localRotation = _normalRotation;
        _fpsController.mouseLook.XSensitivity = _hipSensitivity;
    }

    private void IronSightsFire()
    {
        _crossHair.enabled = false;
        _camera.fieldOfView = _zoomedFieldOfView;
        transform.localPosition = _zoomedPosition;
        transform.localRotation = _zoomedRotation;
        _fpsController.mouseLook.XSensitivity = _sightsSensitivity;
    }
}
