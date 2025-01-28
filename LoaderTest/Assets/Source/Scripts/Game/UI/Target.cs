using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    [SerializeField] private Image _targetImage;   
    [SerializeField] private GameObject _clickToTakeText;

    public void Activate()
    {
        _targetImage.color = Color.green;
        _targetImage.transform.localScale = new Vector3(2f,2f,2f);
        _clickToTakeText.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _targetImage.color = Color.white;
        _targetImage.transform.localScale = Vector3.one;
        _clickToTakeText.gameObject.SetActive(false);     
    }
}
