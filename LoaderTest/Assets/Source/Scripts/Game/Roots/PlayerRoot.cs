using System;
using UnityEngine;

public class PlayerRoot : CompositeRoot
{
    [SerializeField] private Player _player;
    [SerializeField] private InputRoot _inputRoot;
    [SerializeField] private UIRoot _uiRoot;

    private TakebleItem _currentDetectedItem;
    private PutOnTarget _currentPutOnTarget;

    public event Action TargetDetected;
    public event Action TargetLost;

    public override void Compose()
    {
        _player.Initialize(this,_inputRoot.PlayerInput);
    }

    private void OnEnable()
    {
        _uiRoot.TargetButtonClicked += TryTakeItemToHand;
        _uiRoot.TargetButtonClicked += TryPutOnCurrentItem;
    }

    private void OnDisable()
    {
        _uiRoot.TargetButtonClicked -= TryTakeItemToHand;
        _uiRoot.TargetButtonClicked -= TryPutOnCurrentItem;
    }

    public void OnPlayerFindItem(TakebleItem item)
    {
        _currentDetectedItem = item;
        TargetDetected?.Invoke();
    }

    public void OnPlayerLostItem()
    {
        _currentDetectedItem = null;
        TargetLost?.Invoke();
    }

    public void PutOntargetDetected(PutOnTarget target)
    {
        _currentPutOnTarget = target;
        TargetDetected?.Invoke();
    }

    public void PutOnTargetLost()
    {
        _currentPutOnTarget = null;
        TargetLost?.Invoke();
    }

    public void TryTakeItemToHand()
    {
        if (_currentDetectedItem == null)
            return;

        _player.TryTakeItemToHand(_currentDetectedItem);
        _currentDetectedItem = null;
    }

    public void TryPutOnCurrentItem()
    {
        if (_currentPutOnTarget == null)
            return;

        _player.PutOnItemToTarget(_currentPutOnTarget);
        _currentPutOnTarget = null;
    }
}
