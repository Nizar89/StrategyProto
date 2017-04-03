using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EntityControls : MonoBehaviour
{
    public enum TypeOrder { Move, Attack};
    public GameObject _selectionFeedback;

    private bool _isSelected;
    private EntityBase _baseScript;
    private List<OrderScript.OrderDatas> _listOders = new List<OrderScript.OrderDatas>();

    void Awake()
    {
        _baseScript = this.GetComponent<EntityBase>();
        if (_baseScript == null)
        {
            Debug.LogError("ERROR : NO ENTITY BASE SCRIPT FOUND ON ENTITY " + this.gameObject.name);
        }
    }
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
    public void SelectUnit()
    {
        _isSelected = true;
        _selectionFeedback.SetActive(true);
    }

    public void UnselectUnit()
    {
        _isSelected = false;
        _selectionFeedback.SetActive(false);
    }

    public void ReceivedNewOrder(OrderScript.OrderDatas datas)
    {
        if (datas._orderType == TypeOrder.Move)
        {
            _baseScript._moveScript.ReceivedMoveOrder(datas._erasePreviousOrders, datas._posTarget);
        }
    }
}
