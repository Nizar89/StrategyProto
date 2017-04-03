using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityMovable : MonoBehaviour
{
    public float _speed;

    private EntityBase _baseScript;
    private UnityEngine.AI.NavMeshAgent _navMeshAgent;
    private bool _isMoving = false;
    private List<Vector3> _listDestination = new List<Vector3>();
    private int _indexOrder = 0;
    private bool _isFollowingMoveOrder;

    // Use this for initialization
    void Awake ()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _baseScript = GetComponent<EntityBase>();
    }

    void Start()
    {
        _navMeshAgent.speed = _speed;
    }	
    

    public void ReceivedMoveOrder(bool eraseOrder, EntityBase destination)
    {
        //Penser à gérer la vision de l'entity, càd si entity not visible, stop movement
        if (eraseOrder)
        {
            //When order list i
        }
        else
        {
            // add order to the orderlist - which needs to be created first
        }
    }

    public void ReceivedMoveOrder(bool eraseOrder, Vector3 destination) //this function should be called only when the order is active !²
    {
        //Penser à gérer la vision de l'entity, càd si entity not visible, stop movement
        if (eraseOrder)
        {
            _listDestination.Clear();
            _listDestination.Add(destination);
            _navMeshAgent.SetDestination(destination);
        }
        else
        {
            // add order to the orderlist - which needs to be created first
        }
    }

    


}
