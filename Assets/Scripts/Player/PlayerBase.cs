using UnityEngine;
using System.Collections;

public class PlayerBase : MonoBehaviour
{
    public static PlayerBase _instance;

    public PlayerDatas _datas;

    public enum ListTeam { TeamA, TeamB };
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
        
    }

}
