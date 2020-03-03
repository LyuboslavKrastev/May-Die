using System.Collections;
using UnityEngine;

public class GunDash : MonoBehaviour
{
    private const float _dashTime = 0.3f;

    public float _dashForce = 30;
    private Rigidbody _rigidBody;

    private float _dashMultiplier = 2000;

    private float _cooldown = 1f;

    private bool _canDash = true;

    private void Awake()
    {
        _rigidBody = transform.root.GetComponent<Rigidbody>();

        NullAlerter.AlertIfNull(_rigidBody, nameof(Rigidbody));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && _canDash == true) //Right mouse button
        {
            StartCoroutine(Dash());
        }
    }

    private void OnEnable()
    {
        _canDash = true;
    }

    private IEnumerator Dash()
    {
        _canDash = false;

        Vector3 oldVelocity = _rigidBody.velocity;

        Vector3 moveDirection = new Vector3(transform.forward.x, 0f, transform.forward.z) * _dashForce;
        _rigidBody.AddForce(moveDirection * Time.deltaTime * _dashMultiplier, ForceMode.Impulse);

        yield return new WaitForSeconds(_dashTime); // reset the velocity when the dash ends
        _rigidBody.velocity = oldVelocity;

        yield return new WaitForSeconds(_cooldown); // dash has a set cooldown time
        _canDash = true;
    }
}