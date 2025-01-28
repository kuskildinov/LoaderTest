using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private Transform _handContainer;
    [SerializeField] private int _maxItemOnHand = 1;

    private List<TakebleItem> _itemsOnHand;

    public void Initialize()
    {
        _itemsOnHand = new List<TakebleItem>();
    }

    private void Update()
    {
        SetPositionToItemsOnHand();
    }

    public void TakeItemOnHand(TakebleItem currentDetectedItem)
    {
        if(_itemsOnHand.Count >= _maxItemOnHand)
        {
            TakebleItem firstItemOnHand = _itemsOnHand[0];
            DropItem(firstItemOnHand);
            _itemsOnHand.Remove(firstItemOnHand);
        }
        currentDetectedItem.MoveToHand(_handContainer);
        _itemsOnHand.Add(currentDetectedItem);
    }

    public void DropItem(TakebleItem currentDetectedItem)
    {
        currentDetectedItem.Drop();
    }

    public void PutItemOnPlace(PutOnTarget putTo)
    {
        if (putTo.HasItem)
            return;

        if (_itemsOnHand.Count >= _maxItemOnHand)
        {
            TakebleItem firstItemOnHand = _itemsOnHand[0];
            firstItemOnHand.PutOn(putTo);
            _itemsOnHand.Remove(firstItemOnHand);
        }
    }

    private void SetPositionToItemsOnHand()
    {
        for (int i = 0; i < _itemsOnHand.Count; i++)
        {
            _itemsOnHand[i].transform.localPosition = Vector3.zero;
        }
    }
}
