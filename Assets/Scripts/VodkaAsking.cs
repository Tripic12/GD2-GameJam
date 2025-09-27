using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class VodkaAsking : MonoBehaviour
{
    private List<GameObject> _drunkies = new List<GameObject>();
    private int _assignTimer;
    private bool _isAssigned;

    private GameObject _obj;
    private int _index;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _assignTimer++;

        if (_assignTimer >= 5)
        {
        }

        if (Input.GetMouseButtonDown(0))
        {
            _index++;
        }
        if (Input.GetMouseButtonDown(1))
        {
            _obj = GameObject.Find($"VodkaImage{_index}");
            _obj.SetActive(false);
        }
    }
}
