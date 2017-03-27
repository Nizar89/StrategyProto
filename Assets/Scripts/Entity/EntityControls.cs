using UnityEngine;
using System.Collections;

public class EntityControls : MonoBehaviour
{
    public enum TypeOrder { Move, Attack};

    private bool _isSelected;


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
}
