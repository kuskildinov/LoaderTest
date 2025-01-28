using UnityEngine;

public class PlayerInput : MonoBehaviour, IInput
{
    [SerializeField] private Joystick _moveJoystick;
    [SerializeField] private Joystick _viewJoystick;
    public float HorizontalMove()
    {
        return _moveJoystick.Horizontal;
    }

    public float HorizontalView()
    {
        return _viewJoystick.Horizontal;
    }

    public float VerticalMove()
    {
        return _moveJoystick.Vertical;
    }

    public float VerticalView()
    {
        return _viewJoystick.Vertical;
    }
}
