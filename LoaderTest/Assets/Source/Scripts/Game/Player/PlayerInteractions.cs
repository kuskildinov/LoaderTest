using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    private Player _player;

   public void Initialize(Player player)
    {
        _player = player;
    }

    private void Update()
    {
        SetRay();
    }

    private void SetRay()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 2f))
        {
           if(hit.transform.TryGetComponent<TakebleItem>(out TakebleItem item))
            {               
                _player.TakebleTargetDetected(item);
            }  
           else if(hit.transform.TryGetComponent<PutOnTarget>(out PutOnTarget target))
            {                
                _player.PutOntargetDetected(target);
            }
        }
        else
        {
            _player.TakebleTargetLost();
            _player.PutOnTargetLost();
        }
    }
}
