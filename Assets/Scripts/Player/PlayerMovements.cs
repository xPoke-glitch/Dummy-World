using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private Transform _playerCamera;

    [Header("Settings")]
    [SerializeField]
    private float _moveSpeed = 2.5f;
    [SerializeField]
    private float _smoothingRotation = 0.1f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 forward = new Vector3(_playerCamera.forward.x, 0, _playerCamera.forward.z);
        Vector3 right = _playerCamera.right;

        Vector3 direction = (forward * moveVertical + right * moveHorizontal).normalized;

        this.transform.position += direction * Time.deltaTime * _moveSpeed;

        if(direction != Vector3.zero)
        {
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), _smoothingRotation);
        }
    }
}
