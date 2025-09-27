using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class VodkaAsking : MonoBehaviour
{
    private List<GameObject> _drunkies = new List<GameObject>();
    private int _assignTimer;
    private bool _isAssigned;
    private Sprite _vodkaImage;

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
            if (_drunkies.Count == 0) return;

            // Pick a random index
            int randomIndex = Random.Range(0, _drunkies.Count);

            // Get the chosen GameObject
            GameObject chosenObject = _drunkies[randomIndex];

            // Convert world position to screen position
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

            // Apply position to the UI image (anchored in screen space)
            _vodkaImage.rectTransform.position = screenPos;
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
