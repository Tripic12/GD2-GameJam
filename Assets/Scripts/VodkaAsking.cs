using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class VodkaAsking : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _drunkies = new List<GameObject>();
    private int _assignTimer;
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
        _assignTimer++;

        if (_assignTimer >= 2)
        {
            //if (_drunkies.Count == 0) return;
            //int randomIndex = Random.Range(0, _drunkies.Count);
            //GameObject chosenObject = _drunkies[randomIndex];
            //Canvas canvas = chosenObject.GetComponent<Canvas>();
            //canvas.enabled = true;
            _vodkaImage.enabled = true;
            _canvas.enabled = true;
                _assignTimer = 0;
        }
    }
}
