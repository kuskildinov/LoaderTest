using System;
using UnityEngine;

public class UIRoot : CompositeRoot
{
    [SerializeField] private PlayerGamePanel _playerGamePanel;
    [Header("Other Links")]
    [SerializeField] private PlayerRoot _playerRoot;

    public event Action TargetButtonClicked;

    public override void Compose()
    {
        _playerRoot.TargetDetected += ActivateTarget;
        _playerRoot.TargetLost += DeactivateTarget;
    }

    private void OnDisable()
    {
        _playerRoot.TargetDetected -= ActivateTarget;
        _playerRoot.TargetLost -= DeactivateTarget;
    }

    public void OnInteractionButtonCliked()
    {
        TargetButtonClicked?.Invoke();
    }

    private void ActivateTarget()
    {
        _playerGamePanel.ActivateTarget();
    }

    private void DeactivateTarget()
    {
        _playerGamePanel.DeactivateTarget();
    }
}
