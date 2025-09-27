using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class VodkaAsking : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _drunkies = new List<GameObject>();
    private float _assignTimer;
    private bool _isAssigned;
    [SerializeField]
    private Image _vodkaImage;
    [SerializeField]
    private Canvas _canvas;

    private GameObject _obj;
    private int _index;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _assignTimer += Time.deltaTime;

        if (_assignTimer >= 3)
        {
            _vodkaImage.gameObject.SetActive( true);
                _assignTimer = 0;
        }
    }
}
