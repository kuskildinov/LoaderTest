using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerMovment _playerMovment;
    [SerializeField] private PlayerInteractions _playerInteractions;
    [SerializeField] private PlayerCollector _playerCollector;

    private PlayerRoot _playerRoot;
    private IInput _input;

    public void Initialize(PlayerRoot playerRoot, IInput input)
    {
        _playerRoot = playerRoot;
        _input = input;
        _playerInteractions.Initialize(this);
        _playerMovment.Initialize(_input);
        _playerCollector.Initialize();
    }

    public void TakebleTargetDetected(TakebleItem item)
    {
        _playerRoot.OnPlayerFindItem(item);
    }

    public void TakebleTargetLost()
    {
        _playerRoot.OnPlayerLostItem();
    }

    public void PutOntargetDetected(PutOnTarget target)
    {
        _playerRoot.PutOntargetDetected(target);
    }

    public void PutOnTargetLost()
    {
        _playerRoot.PutOnTargetLost();
    }

    public void TryTakeItemToHand(TakebleItem currentDetectedItem)
    {
        _playerCollector.TakeItemOnHand(currentDetectedItem);
    }

    internal void PutOnItemToTarget(PutOnTarget currentPutOnTarget)
    {
        _playerCollector.PutItemOnPlace(currentPutOnTarget);
    }
}
