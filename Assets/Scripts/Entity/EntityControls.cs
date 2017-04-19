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
        CheckIfInSelectionQuad();

    }
    public void SelectUnit()
    {
        _isSelected = true;
        _selectionFeedback.SetActive(true);
        if (!GameManager._instance._listEntitySelected.Contains(this._baseScript))
        {
            GameManager._instance._listEntitySelected.Add(this._baseScript);
        }
    }

    public void UnselectUnit()
    {
        GameManager._instance._listEntitySelected.Remove(_baseScript);
        _isSelected = false;
        _selectionFeedback.SetActive(false);
    }

    private void CheckIfInSelectionQuad()
    {
        if (_baseScript._unitRenderer.isVisible && Input.GetMouseButton(0) && (Time.time - SelectionQuad._instance._startClickTime) > 0.1f)
        {
            Vector3 posOnCam = MouseHandler._instance._mainCam.WorldToScreenPoint(transform.position);
            posOnCam.y = SelectionQuad._instance.InvertMouseY(posOnCam.y);

            if (SelectionQuad._instance._quad.Contains(posOnCam,true))
            {
                SelectUnit();
            }
            else if (_isSelected) //if outside of box
            {
                UnselectUnit();
            }
        }
    }

    public void ReceivedNewOrder(OrderScript.OrderDatas datas)
    {
        if (datas._orderType == TypeOrder.Move)
        {
            _baseScript._moveScript.ReceivedMoveOrder(datas._erasePreviousOrders, datas._posTarget);
        }
        else if (datas._orderType == TypeOrder.Attack)
        {
            _baseScript._attackScript.ReceivedAttackOrder(datas._entityTarget);
        }
    }
}
