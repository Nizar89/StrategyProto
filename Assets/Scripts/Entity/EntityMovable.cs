using UnityEngine;
using System.Collections;

public class EntityMovable : MonoBehaviour
{
    public float _speed;

    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private bool _isMoving = false;

    // Use this for initialization
    void Awake ()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
	}

    void Start()
    {
        _navMeshAgent.speed = _speed;
    }	
    

    public void ReceivedMoveOrder(bool eraseOrder, EntityBase destination)
    {
        //Penser à gérer la vision de l'entity, càd si entity not visible, stop movement
    }

    public void ReceivedMoveOrder(bool eraseOrder, Vector3 destination)
    {
        if (eraseOrder)
        {

        }
    }
}
