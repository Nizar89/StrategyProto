using UnityEngine;
using System.Linq;
using System.Collections;

public class MouseHandler : MonoBehaviour
{
    //part of mouse control is in script SelectionQuad, because fuck it
    public static MouseHandler _instance;

    public Camera _mainCam;
    public PlayerBase _playerScript;
	// Use this for initialization
	void Awake ()
    {
        _instance = this;
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
        if (GameManager._instance._listEntitySelected.Count > 0) // useless, for now, to send raycast if no unit is selected
        {
            RaycastHit[] hits;
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);

            hits = Physics.RaycastAll(ray).OrderBy(h => h.distance).ToArray();
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.tag == ListTags._tagTerrain)
                {
                    _playerScript.SendOrder(hit.point);
                    break;
                }
                else if (hit.collider.tag == ListTags._tagUnit)
                {
                    _playerScript.SendOrder(hit.collider.GetComponent<EntityBase>());
                    break;
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
                    entityHit._controlScript.SelectUnit();
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
