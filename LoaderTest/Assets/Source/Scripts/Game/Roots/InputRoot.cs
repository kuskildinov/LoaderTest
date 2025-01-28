using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputRoot : CompositeRoot
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private PlayerRoot _playerRoot;
    [SerializeField] private CameraMovment _cameraMovment;
    [Header("Input Settings")]
    [SerializeField] private float _cameraSensitivity;

    public PlayerInput PlayerInput => _playerInput;

    public override void Compose()
    {
        _cameraMovment.Initialize(_playerInput, _cameraSensitivity);     
    }
}
