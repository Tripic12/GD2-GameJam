using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField]
    private float _speed = 50f;
    [SerializeField]
    private float _rotationSpeed = 10f;
    private Vector3 _move;
    private Vector3 _mousePosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Movement
        _move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rb.MovePosition(_rb.position + _move * _speed * Time.deltaTime);

        // Rotation
        _mousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Camera.main.transform.position.y - transform.position.y)
        );

        Vector3 lookDir = _mousePosition - transform.position;
        lookDir.y = 0;

        if (lookDir.sqrMagnitude > 0.01f)
        {
            Quaternion rot = Quaternion.LookRotation(lookDir);
            _rb.MoveRotation(Quaternion.Slerp(_rb.rotation, rot, _rotationSpeed * Time.fixedDeltaTime));
        }

    }

    void Update()
    {
    }
}
