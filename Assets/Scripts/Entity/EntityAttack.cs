using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    public float _cooldownAttack = 1f;
    public float _distanceAttack = 15f; // should be used for melee attack. TODO : handle enemy hitbox
    public bool _spawnProjectile = false; // if true, will spawn gameobject belwo
    public GameObject _projectile;

    public void ReceivedEraseOrder(bool eraseOrder, EntityBase destination)
    {
        //Penser à gérer la vision de l'entity, càd si entity not visible, stop movement
        if (eraseOrder)
        {
            //When order list i
        }
        else
        {
            // add order to the orderlist - which needs to be created first
        }
    }

}
