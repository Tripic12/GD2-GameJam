using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private float _speed = 500f;
    [SerializeField]
    private float _rotationSpeed = 10f;
    private Vector3 _move;
    private Vector3 _mousePosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        rb.linearVelocity = _move * Time.deltaTime * _speed;
    }

    void Update()
    {

        _mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 
            Camera.main.transform.position.y - transform.position.y));

        Vector3 lookDir = _mousePosition - transform.position;
        lookDir.y = 0; // keep only horizontal rotation

        Quaternion rot = Quaternion.LookRotation(lookDir);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, rot, _rotationSpeed * Time.deltaTime));
    }
}
