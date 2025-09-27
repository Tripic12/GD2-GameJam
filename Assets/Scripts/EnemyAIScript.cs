using UnityEngine;
using UnityEngine.AI;

public class EnemyAIScript : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;
    
    [SerializeField]
    private GameObject _player;
    private Rigidbody _rb;
    private float _rotationSpeed = 10f;
    private float _movementSpeed = 2f;

    private Hitable _hitable;
    public bool IsChasing = false;
    private float _chasingTime;
    private MeshRenderer _meshRenderer;
    private float _lerpNumber;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _hitable = GetComponent<Hitable>();
        _rb = GetComponent<Rigidbody>();
        _meshRenderer = GetComponent<MeshRenderer>();

        
    }
    private void FixedUpdate()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(_hitable.DrunknessTargetValue!=0)
        {
            _hitable.DrunknessTargetValue -= Time.deltaTime / 5;
        }
        

        if (_hitable.IsAngry) //IsChasing
        {
            //_chasingTime += Time.deltaTime;

            //_meshRenderer.material.color = Color.green;

            Vector3 dir = (_player.transform.position - transform.position).normalized;
            dir.y = 0; // only move on XZ plane
            _rb.MovePosition(transform.position + dir * _movementSpeed * Time.deltaTime);
            // Rotate smoothly
            if (dir.sqrMagnitude > 0.01f)
            {
                Quaternion targetRot = Quaternion.LookRotation(dir);
                _rb.MoveRotation(Quaternion.Slerp(_rb.rotation, targetRot, _rotationSpeed * Time.deltaTime));
            }

            //Stop chasing after N-amount time
            //if (_chasingTime >= 3)
            //{
            //    _hitable.IsAngry = false;
            //    _chasingTime = 0;
            //}
        }
        if (!_hitable.IsAngry)        
        {

            transform.position = transform.position;
        }
        //_lerpNumber =  _hitable.DrunknessAmount/_hitable.MaxDrunkness;
        //_meshRenderer.material.color = Color.Lerp(Color.green, Color.red, _lerpNumber);
    }


  
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _hitable.IsAngry = false;
        }
    }
}

/*            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _agent.SetDestination(_playerTransform.position);
            }*/