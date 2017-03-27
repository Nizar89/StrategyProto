using UnityEngine;
using System.Collections;

public class MouseHandler : MonoBehaviour
{
    public Camera _mainCam;
    public PlayerBase _playerScript;
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if (Input.GetMouseButtonDown(0))
        {
            LeftClickPressed();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            RightClickPressed();
        }
    }

    private void RightClickPressed()
    {
        RaycastHit[] hits;
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.tag == ListTags._tagTerrain)
            {
                if (GameManager._instance._listEntitySelected.Count > 0)
                {
                    _playerScript.SendOrder(hit.point);
                }
            }
        }
    }

    private void LeftClickPressed()
    {
        RaycastHit[] hits;
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

        hits = Physics.RaycastAll(ray);

        foreach(RaycastHit hit in hits)
        {
            if (hit.collider.tag == ListTags._tagUnit)
            {
                EntityBase entityHit = hit.collider.GetComponent<EntityBase>();
                if (entityHit._team == PlayerBase._instance._team)
                {
                    GameManager._instance.SelectUnit(entityHit);
                }
                else //if ship is enemy
                {
                    //Display infos or something.
                }
            }
            else //should add condition when overing UI
            {
                GameManager._instance.UnselectAllUnit();
            }
        }
    }


}
