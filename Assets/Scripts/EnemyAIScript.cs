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

    private bool _isHit = false;
    private float _lerpTime = 2f;
    private float t;
    private float f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Transform _playerTransform = _player.transform;
        MeshRenderer _agentMesh = _agent.GetComponent<MeshRenderer>();

        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {

                _agent.SetDestination(_playerTransform.position);
            }
            if (_agent.transform.position == _playerTransform.position)
            {
                _agent.transform.position = _agent.transform.position;
            }

        }

        if (_isHit)
        {
            t += Time.deltaTime / _lerpTime;
            _agentMesh.material.color = Color.Lerp(Color.green, Color.red, t);
        }     
        if (!_isHit)
        {
            _agentMesh.material.color = Color.green;
        }

        if (Input.GetMouseButton(1))
        {
            _isHit = true;
        }
    }
}
