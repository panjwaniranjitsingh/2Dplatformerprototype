using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private bool _moveCamera;
    private Vector3 _targetPosition;
    private Vector3 velocity;

    public void SetCameraPosition(Vector3 targetPosition)
    {
        _targetPosition = targetPosition;
        _moveCamera = true;
    }

    private void Update()
    {
        if (_moveCamera)
        {
            transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref velocity, 0.5f);
        }

        if (Vector3.Distance(transform.position, _targetPosition) < 0.1)
        {
            _moveCamera = false;
        }
    }
}