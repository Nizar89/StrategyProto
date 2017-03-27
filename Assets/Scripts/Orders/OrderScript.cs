using UnityEngine;
using System.Collections;

public class OrderScript : MonoBehaviour
{
    private float _speed;
    private EntityControls.TypeOrder _orderType;
    private EntityBase _entityOrigin;
    private EntityBase _entityDestination;
    private Vector3 _posTarget;
    private EntityBase _entityTarget;
    

    public void Initialise (float speed, EntityBase origin, EntityBase destination, EntityBase target) //if target is a unit
    {
        _speed = speed;
        _entityOrigin = origin;
        _entityDestination = destination;
        StartCoroutine(MoveToEntity());
        _entityTarget = target;
    }

    public void Initialise(float speed, EntityBase origin, EntityBase destination, Vector3 target) //if target is a unit
    {
        _speed = speed;
        _entityOrigin = origin;
        _entityDestination = destination;
        _posTarget = target;
        StartCoroutine(MoveToEntity());
    }

    IEnumerator MoveToEntity()
    {
        while (Vector3.Distance(this.transform.position, _entityDestination.transform.position) > 0.5f)
        {
            Vector3 direction = _posTarget - this.transform.position;
            direction.Normalize();
            this.transform.Translate(direction * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        //handle send orders 
    }

}
