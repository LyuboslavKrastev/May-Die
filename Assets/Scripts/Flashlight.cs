using UnityEngine;
using UnityEngine.UI;

public class Flashlight : MonoBehaviour
{
    private float _intensityDecay = 0.2f;
    private float _intensityRecovery = 0.4f;

    private float _minumumIntensity = 0f;
    private float _maximumIntenisty = 3f;

    private float _angleDecay = 2f;
    private float _angleRecovery = 4.4f;

    private float _minimumAngle = 40f;
    private float _maximumAngle = 70f;

    private float _minRange = 0f;
    private float _maxRange = 30f;

    [SerializeField] private Slider _flashlightBar;

    private bool _isOn = true;

    private Light _myLight;

    void Start()
    {
        _myLight = GetComponent<Light>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isOn = !_isOn;
        }
        if (_isOn == true)
        {
            TurnOnLight();
            DrainFlashLight();
        }
        else
        {
            TurnOffLight();
            ChargeFlashLight();
        }

        float lightPercentage = CalculatePercentage();
        UpdateFlashlightBar(lightPercentage);
    }

    private void UpdateFlashlightBar(float percentage)
    {
        _flashlightBar.value = percentage;
    }

    private float CalculatePercentage()
    {
        return _myLight.intensity / _maximumIntenisty;
    }
    private void TurnOnLight()
    {
        _myLight.range = _maxRange;
 
    }
    private void TurnOffLight()
    {
        _myLight.range = _minRange;
    }

    private void ChargeFlashLight()
    {
        IncreaseLightIntensity();
        IncreaseLightAngle();
    }

    private void DrainFlashLight()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (_myLight.spotAngle > _minimumAngle)
        {
            _myLight.spotAngle -= _angleDecay * Time.deltaTime; // freamerate independant
        }
    }
    private void DecreaseLightIntensity()
    {
        if (_myLight.intensity > _minumumIntensity)
        {
            _myLight.intensity -= _intensityDecay * Time.deltaTime;
        }
        else
        {
            _isOn = false;
        }
    }
    private void IncreaseLightAngle()
    {
        if (_myLight.spotAngle < _maximumAngle)
        {
            _myLight.spotAngle += _angleRecovery * Time.deltaTime;

        }
    }
    private void IncreaseLightIntensity()
    {
        if (_myLight.intensity < _maximumIntenisty)
        {
            _myLight.intensity += _intensityRecovery * Time.deltaTime;
        }
    }


}
