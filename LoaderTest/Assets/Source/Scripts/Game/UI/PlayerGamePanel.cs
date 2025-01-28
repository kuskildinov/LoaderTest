using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGamePanel : MonoBehaviour
{
    [SerializeField] private UIRoot _uiRoot;
    [SerializeField] private Target _target;
    [SerializeField] private Button _interactionButton;

    private void OnEnable()
    {
        _interactionButton.onClick.AddListener(OnInteractionButtonCliked);
    }

    private void OnDisable()
    {
        _interactionButton.onClick.RemoveAllListeners();
    }

    public void ActivateTarget()
    {
         _target.Activate();
        _interactionButton.interactable = true;
    }
    public void DeactivateTarget()
    {
        _target.Deactivate();
        _interactionButton.interactable = false;
    }

    private void OnInteractionButtonCliked()
    {
        _uiRoot.OnInteractionButtonCliked();
    }
}
