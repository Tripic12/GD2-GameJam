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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                Vector3 pos = hitInfo.point;
                pos = new Vector3(pos.x, 0, pos.z);
                //_agent.SetDestination(pos);
                _agent.SetDestination(_player.transform.position);
            }
        }
    }
}
