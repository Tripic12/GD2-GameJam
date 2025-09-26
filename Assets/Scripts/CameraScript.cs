using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Vector3 _mousePosition;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        
    }
}
