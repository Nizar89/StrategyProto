using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityAttack : MonoBehaviour
{
    public float _cooldownAttack = 1f;
    public float _distanceAttack = 15f; // should be used for melee attack. TODO : handle enemy hitbox
    public int _damage = 10;
    public bool _spawnProjectile = false; // if true, will spawn gameobject belwo
    public GameObject _projectile;

    private EntityBase _target;
    private EntityBase _baseScript;
    

    private void Awake()
    {
        _baseScript = this.GetComponent<EntityBase>();
    }
    public void ReceivedAttackOrder( EntityBase target)
    {
        //Penser à gérer la vision de l'entity, càd si entity not visible, stop movement
        _target = target;
    }

    IEnumerator MoveAndAttack()
    {
        while (Vector3.Distance(_target.transform.position, this.transform.position) > _distanceAttack)
        {
            if (_baseScript._navMeshAgent.destination != _target.transform.position)
            {
                _baseScript._navMeshAgent.SetDestination(_target.transform.position);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void Attack()
    {
        //spawnEntity
    }

}
