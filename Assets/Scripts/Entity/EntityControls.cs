using UnityEngine;
using System.Collections;

public class EntityControls : MonoBehaviour
{
    public enum TypeOrder { Move, Attack};

    private bool _isSelected;
    private EntityBase _baseScript;

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
    }

    public void UnselectUnit()
    {
        _isSelected = false;
    }

    public void ReceivedNewOrder(OrderScript.OrderDatas datas)
    {
        if (datas._orderType == TypeOrder.Move)
        {

        }
    }
}
