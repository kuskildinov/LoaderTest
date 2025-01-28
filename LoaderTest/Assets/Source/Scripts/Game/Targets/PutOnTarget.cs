using UnityEngine;

public class PutOnTarget : MonoBehaviour
{
    [SerializeField] private GameObject _targetVisual;
    [SerializeField] private Collider _collider;

    private bool _hasItem;

    public bool HasItem { get => _hasItem; set => _hasItem = value; }

    public void PutItem()
    {
        _hasItem = true;
        _targetVisual.gameObject.SetActive(false);
        _collider.enabled = false;
    }

    public void GetItem()
    {
        _hasItem = false;
        _targetVisual.gameObject.SetActive(true);
        _collider.enabled = true;
    }
}
