
using UnityEngine;
using UnityEngine.UI;


public class VodkaAsking : MonoBehaviour
{
    
    
    private float _assignTimer;
    private bool _isAssigned;
    [SerializeField]
    private Image _vodkaImage;
    [SerializeField]
    private Canvas _canvas;

    private GameObject _obj;
    private int _index;
    private Hitable _hitableScript;

    void Start()
    {
        _hitableScript=gameObject.GetComponent<Hitable>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (_hitableScript.DrunknessAmount<=5)
        {
            _vodkaImage.gameObject.SetActive( true);
            _hitableScript.IsAngry = true;
                
        }
        if (_hitableScript.DrunknessAmount > 5)
        {
            _vodkaImage.gameObject.SetActive(false);
        }
    }
}
