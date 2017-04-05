using UnityEngine;
using System.Collections;

public class EntityLife : MonoBehaviour
{
    public int _lifemax = 10;
    //handle armor type - LATER
    private EntityBase _baseScript;
    private int _actualLife;

    private void Awake()
    {
        _baseScript = this.GetComponent<EntityBase>();
    }

    void Start()
    {
        _actualLife = _lifemax;
    }

    public void SufferDamage(int damage) //add attack type - LATER
    {
        _actualLife -= damage;
        if (_actualLife <= 0)
        {
            _actualLife = 0;
            _baseScript.DestroyEntity();
        }
    }
    
}
