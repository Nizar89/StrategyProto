using UnityEngine;
using System.Collections;

public class OrderScript : MonoBehaviour
{
    private float _speed;
    private EntityBase _entityOrigin;
    private EntityBase _entityDestination;

    public class OrderDatas
    {
        public EntityControls.TypeOrder _orderType;
        public EntityBase _entityTarget;
        public Vector3 _posTarget;
        public bool _erasePreviousOrders = true;
    }

    private OrderDatas _orderToSend;

    public void Initialise (float speed, EntityBase origin, EntityBase destination, EntityBase target) //if target is a unit
    {
        //specific value for the "bird"
        _speed = speed;
        _entityOrigin = origin;
        _entityDestination = destination;

        //Value for the order itself
        _orderToSend._entityTarget = target;
        _orderToSend._orderType = EntityControls.TypeOrder.Attack; // Need to add a check if entity is ally, and add an order type. 

        StartCoroutine(MoveToEntity());
        
    }

    public void Initialise(float speed, EntityBase origin, EntityBase destination, Vector3 target) //if target is a unit
    {
        //specific value for the "bird"
        _speed = speed;
        _entityOrigin = origin;
        _entityDestination = destination;

        //Value for the order itself
        _orderToSend._posTarget = target;
        _orderToSend._orderType = EntityControls.TypeOrder.Move;

        StartCoroutine(MoveToEntity());
    }

    IEnumerator MoveToEntity()
    {
        while (Vector3.Distance(this.transform.position, _entityDestination.transform.position) > 0.5f)
        {
            Vector3 direction = _entityDestination.transform.position - this.transform.position;
            direction.Normalize();
            this.transform.Translate(direction * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        //handle send orders
         
    }

}
