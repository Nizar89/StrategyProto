using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour
{

    public enum EntityState { Idle, Moving};
    public PlayerBase.ListTeam _team;
    public EntityControls _controlScript;
    public EntityLife _lifeScript;
    public EntityMovable _moveScript;


    // Use this for initialization
    void Awake ()
    {
	    
	}

    void Start ()
    {
        if (_team != PlayerBase._instance._team && _controlScript != null)
        {
            _controlScript.enabled = false;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
