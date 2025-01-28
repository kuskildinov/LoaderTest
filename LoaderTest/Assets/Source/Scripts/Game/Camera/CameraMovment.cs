using UnityEngine;

public class CameraMovment : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] private Vector2 _verticalRange;
    [Header("Other links")]
    [SerializeField] private Transform _player;

    private float _sensitivity;
    private float _horizontalRotation;
    private float _verticalRotation;

    private float _horizontalInput;
    private float _verticalInput;

    private IInput _input;
    public void Initialize(IInput input, float sensitivity)
    {
        _input = input;
        _sensitivity = sensitivity;
    }

    private void Update()
    {
        ReadInput();
        RotateCamera();       
    }

    private void RotateCamera()
    {
        _horizontalRotation -= _verticalInput;
        _horizontalRotation = Mathf.Clamp(_horizontalRotation,_verticalRange.x,_verticalRange.y);

        _verticalRotation += _horizontalInput;

        transform.localRotation = Quaternion.Euler(_horizontalRotation,0f, 0f); 
        _player.rotation = Quaternion.Euler(0f, _verticalRotation, 0f);
    }

    private void ReadInput()
    {
        _horizontalInput = _input.HorizontalView() * _sensitivity;
        _verticalInput = _input.VerticalView() * _sensitivity;
    }
}
