using UnityEngine;
using UnityEngine.AI;

public class ClickToMove : MonoBehaviour
{
    private Camera _mainCamera;
    [SerializeField] private NavMeshAgent _agent;
    private void Awake() 
    { 
        _mainCamera = Camera.main;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);         
            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, 1 << 3))
            {
                _agent.SetDestination(hit.point);
            }
        }
    }
}
