using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase _instance;

    public PlayerDatas _datas;

    public enum ListTeam { TeamA, TeamB, None };
    public ListTeam _team;

    public int _nbOrderLeft;


    // Use this for initialization
    void Awake ()
    {
        _instance = this;
	}

    void Start()
    {
        _nbOrderLeft = _datas._nbMaxOrder;
    }
	

    public void SendOrder(Vector3 destination)
    {
        foreach (EntityBase entity in GameManager._instance._listEntitySelected)
        {
            GameObject movingOrder = Instantiate(_datas._prefabOrder, this.transform.position, Quaternion.identity);
            OrderScript orderScript = movingOrder.AddComponent<OrderScript>();
            orderScript.Initialise(_datas._speedOrder, entity, destination);
        }
        
    }

    public void SendOrder(EntityBase target)
    {
        if (target._team != _team) // if enemy
        {
            foreach (EntityBase entity in GameManager._instance._listEntitySelected)
            {
                GameObject attackOrder = Instantiate(_datas._prefabOrder, this.transform.position, Quaternion.identity);
                OrderScript orderScript = attackOrder.AddComponent<OrderScript>();
                orderScript.Initialise(_datas._speedOrder, entity, target);
            }
        }
    }

}
