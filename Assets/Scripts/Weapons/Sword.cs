using System;
using System.Collections;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Animation _animation;
    [SerializeField] private Camera _camera;
    [SerializeField] float _range = 3f;

    private Vector3 _blockPosition = new Vector3(-0.073f, -0.084f, 0.11f);
    private Quaternion _blockRotation = Quaternion.Euler(11.91f, -28.882f, -60.4f);

    private Vector3 _normalPosition = new Vector3(-0.073f, -0.097f, 0.1304f);
    private Quaternion _normalRotation = Quaternion.Euler(39.915f, -85.999f, -2.726f);

    [SerializeField] private int _damage = 500;

    [SerializeField] private GameObject _bloodEffect;

    private float _timeBetweenWings = 0.9f;

    bool isAttacking = false;

    void Start()
    {
        _animation = GetComponent<Animation>();
    }

    private void OnEnable()
    {
        isAttacking = false;
    }
    private void OnDisable()
    {
        isAttacking = false;
    }
    void Update()
    {
        if (isAttacking == false)
        {
            bool isBlocking = false;
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(SwingWeapon());
            }
            else if (Input.GetMouseButton(1))
            {
                isBlocking = true;
                Block();
            }
            if (isBlocking == false)
            {
                transform.localPosition = _normalPosition;
                transform.localRotation = _normalRotation;
            }
        }
    }
    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject hitEffect = Instantiate(_bloodEffect, hit.point, Quaternion.LookRotation(hit.normal));

        Destroy(hitEffect, 1f);
    }

    private void Block()
    {
        transform.localPosition = _blockPosition;
        transform.localRotation = _blockRotation;
    }

    private IEnumerator SwingWeapon()
    {
        if (!_animation.isPlaying)
        {
            _animation.Play();
        }
        isAttacking = true;
        yield return new WaitForSeconds(_timeBetweenWings);
        isAttacking = false;
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        bool hitSomething = Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, _range);

        if (hitSomething)
        {
            string hitTag = hit.transform.tag;

            if (hitTag == "Enemy")
            {
                CreateHitImpact(hit);
                EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
                target.TakeDamage(_damage);
            }
        }
    }
}
