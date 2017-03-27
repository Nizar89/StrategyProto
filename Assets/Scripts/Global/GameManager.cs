using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public List<EntityBase> _listEntitySelected = new List<EntityBase>();

	// Use this for initialization
	void Awake ()
    {
        _instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void UnselectAllUnit()
    {
        _listEntitySelected.ForEach(b => b._controlScript.UnselectUnit());
        _listEntitySelected.Clear();
    }

    public void SelectUnit(EntityBase entityToAdd)
    {
        _listEntitySelected.Add(entityToAdd);
        entityToAdd._controlScript.SelectUnit();
    }

    public void SelectUnit(EntityBase[] entitiesToAdd)
    {
        foreach(EntityBase entity in entitiesToAdd)
        {
            _listEntitySelected.Add(entity);
        }
    }
}
