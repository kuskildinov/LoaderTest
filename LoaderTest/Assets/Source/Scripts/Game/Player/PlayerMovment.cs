using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _root;
    [SerializeField] private float _speed;

    private bool _isAlive = true;
    private IInput _input;
    private float _horizontalInput;
    private float _verticalInput;

    public bool IsAlive => _isAlive;

    public void Initialize(IInput input)
    {
        _input = input;
    }

    private void Update()
    {
        if (_isAlive == false)
            return;

        ReadInput();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveDirection = _root.TransformDirection(new Vector3(_horizontalInput,0f,_verticalInput));
        _rigidbody.MovePosition(_root.transform.position + moveDirection * _speed * Time.fixedDeltaTime);
    }

    private void ReadInput()
    {
        _horizontalInput = _input.HorizontalMove();
        _verticalInput = _input.VerticalMove();
    }
}
