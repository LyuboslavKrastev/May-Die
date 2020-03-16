using System;
using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] float _range = 100f;
    [SerializeField] ParticleSystem _muzzleFlash;
    [SerializeField] private GameObject _hitEffect;
    private Ammo _ammoSlot;
    private bool _canShoot = true;
    [SerializeField] float _timeBetweenShots = 0.5f;

    [SerializeField] private int _damage = 1;

    [SerializeField] private AmmoType _ammoType;

    private AudioSource _attackSound;
    void Awake()
    {
        _ammoSlot = GetComponent<Ammo>();

        if (_ammoSlot == null)
        {
            _ammoSlot = GetComponentInParent<Ammo>(); // For ebony and ivory
        }

        NullAlerter.AlertIfNull(_ammoSlot, nameof(_ammoSlot));

        _ammoSlot.UpdateAmmoText();

        _attackSound = GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetMouseButton(0) && _ammoSlot.AmmoAmount > 0)
        {
            if (_canShoot == true)
            {
                StartCoroutine(Shoot());
                PlayShootingSound();
            }
        }
        else
        {
            StopShootingSound();
        }

    }

    private void PlayShootingSound()
    {
        if (!_attackSound.isPlaying)
        {
            _attackSound.Play();
        }
    }

    private void StopShootingSound()
    {
        if (!_attackSound.isPlaying || _ammoType == AmmoType.GunBullets) // the machine gun sound needs to be stopped as it is significantly longer and continues after stopped shooting
        {
            _attackSound.Stop();
        }
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        if (_ammoSlot.AmmoAmount > 0)
        {
            PlayMuzzleFlash();
            ProcessRaycast();
            _ammoSlot.ReduceAmmo();
        }

        yield return new WaitForSeconds(_timeBetweenShots);
        _canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        _muzzleFlash.Play();
    }

    void OnEnable()
    {
        _canShoot = true;
    }

    private void ProcessRaycast()
    {
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range);

        if (hitSomething)
        {
            string hitTag = hit.transform.tag;

            if (hitTag != "Player")
            {
                CreateHitImpact(hit);
            }
            if (hitTag == "Enemy")
            {
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(_damage);
            }
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(_hitEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(hitEffect, 0.02f);
    }
}
