using UnityEngine;

public interface ITakebleItem 
{
    public bool Taked { get; set; }
    public void MoveToHand(Transform to);
    public void Drop();
    public void PutOn(PutOnTarget to);
}
