using UnityEngine;
using System.Collections;

public class EntityBase : MonoBehaviour
{

    public enum EntityState { Idle, Moving};
    public PlayerBase.ListTeam _team;
    public EntityControls _controlScript;
    public EntityLife _lifeScript;
    public EntityMovable _moveScript;

    public Renderer _unitRenderer;
    public Material _matAllyTeam;
    public Material _matEnemyTeam;

    public UnityEngine.AI.NavMeshAgent _navMeshAgent;



    // Use this for initialization
    void Awake ()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Start ()
    {
        //disable control script if not in the same team
        if (_team != PlayerBase._instance._team && _controlScript != null)
        {
            _controlScript.enabled = false;
        }

        //set color. Behaviour might change with real model
        SetColors();
    }
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void SetColors()
    {
        if (_team == PlayerBase._instance._team)
        {
            _unitRenderer.material = _matAllyTeam;
        }
        else if (_team != PlayerBase.ListTeam.None)
        {
            _unitRenderer.material = _matEnemyTeam;
        }
        else
        {
            //Dunno lol
        }
    }
}
