using UnityEngine;
using System.Collections;

public class EntityMovable : MonoBehaviour
{
    public float _speed;

    private NavMeshAgent _navMeshAgent;

    // Use this for initialization
    void Awake ()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
	}

    void Start()
    {
        _navMeshAgent.speed = _speed;
    }
	
    
}
