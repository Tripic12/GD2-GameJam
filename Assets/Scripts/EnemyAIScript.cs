using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private GameObject _player;
    private Rigidbody _rb;
    private float _rotationSpeed = 10f;
    private float _movementSpeed = 2f;

    private Hitable _hitable;
    private bool _isChasing = true;
    private float _chasingTime;
    private MeshRenderer _meshRenderer;
    private float _lerpNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hitable = GetComponent<Hitable>();
        _rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();

        _hitable.DrunknessAmount = 2;

        _agent.updateRotation = false;
    }
    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isChasing)
        {
            _chasingTime += Time.deltaTime;

            _meshRenderer.material.color = Color.red;

            Vector3 dir = (_player.transform.position - transform.position).normalized;
            dir.y = 0; // only move on XZ plane
            _rb.MovePosition(transform.position + dir * _movementSpeed * Time.fixedDeltaTime);
            // Rotate smoothly
            if (dir.sqrMagnitude > 0.01f)
            {
                Quaternion targetRot = Quaternion.LookRotation(dir);
                _rb.MoveRotation(Quaternion.Slerp(_rb.rotation, targetRot, _rotationSpeed * Time.fixedDeltaTime));
            }

            //Stop chasing after N-amount time
            if (_chasingTime >= 3)
            {
                _isChasing = false;
                _chasingTime = 0;
            }
        }
        if (!_isChasing)        
        {

            transform.position = transform.position;
        }
        _lerpNumber += Time.deltaTime / _hitable.DrunknessAmount;
        _meshRenderer.material.color = Color.Lerp(Color.red, Color.green, _lerpNumber);
    }


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _isChasing = false;
        }
    }
}

/*            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _agent.SetDestination(_playerTransform.position);
            }*/