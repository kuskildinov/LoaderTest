using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakebleItem : MonoBehaviour, ITakebleItem
{
    [SerializeField] private string _name;
    [SerializeField] private Rigidbody _rigidbody;

    private Transform _parentTransform;
    private PutOnTarget _putOnTarget;
    private bool _taked;
    public string Name => _name;

    public bool Taked { get => _taked; set => _taked = value; }

    private void Start()
    {
        _parentTransform = transform.parent;
    }

    public void MoveToHand(Transform to)
    {
        _taked = true;
        transform.SetParent(to);
        _rigidbody.useGravity = false;      
        transform.localPosition = Vector3.zero;

        if (_putOnTarget != null)
        {
            _putOnTarget.GetItem();
            _putOnTarget = null;
        }

        Debug.Log($"Предмет {_name} взяли");
    }

    public void Drop()
    {
        _taked = false;
        transform.SetParent(_parentTransform);
        _rigidbody.useGravity = true;      

        Debug.Log($"Предмет {_name} Уронили");
    }

    public void PutOn(PutOnTarget to)
    {
        _taked = false;
        transform.SetParent(to.transform);
        _putOnTarget = to;
        _putOnTarget.PutItem();
        _rigidbody.useGravity = false;       
        transform.localPosition = Vector3.zero;

        Debug.Log($"Предмет {_name} положили");
    }
}
