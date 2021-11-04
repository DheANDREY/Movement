using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementLogic : MonoBehaviour
{
    [SerializeField] private DashValueLogic _dashValue;
    [SerializeField] private float _moveSpeed = 5;
    [SerializeField] private float _dashSpeed = 20;
    [SerializeField] private float _dashTime = 0.1f;

    private Rigidbody2D _rigidBody;

    private Vector3 _moveDir;
    private bool _isDashing;
    private float _dashTimer;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    
    private void Update()
    {
        if(!_isDashing)
        {
            HandleMovement();    
        }

        HandleDash();
    }

    private void HandleMovement()
    {
        Vector3 dir = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        if(dir != Vector3.zero)
        {
            _moveDir = dir;
            _rigidBody.velocity = _moveDir.normalized * _moveSpeed;
        }
        else
        {
            _rigidBody.velocity = Vector3.zero;
        }
    }

    private void HandleDash()
    {
        if(_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if(_dashTimer <= 0)
            {
                _isDashing = false;
            }
            return;
        }

        if(Input.GetKeyDown(KeyCode.Space) && _dashValue.CurrentDashCount > 0)
        {
            _dashValue.CurrentDashCount--;
            
            _isDashing = true;
            _dashTimer = _dashTime;
            _rigidBody.velocity = _moveDir.normalized * _dashSpeed;
        }
    }
}
