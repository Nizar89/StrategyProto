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
    private float _lastTimeAttack = Time.time;
    

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
        while (_target != null && _target.isActiveAndEnabled) // should also stop if new order.
        {
            //move to target
            while (Vector3.Distance(_target.transform.position, this.transform.position) > _distanceAttack)
            {
                if (_baseScript._navMeshAgent.destination != _target.transform.position)
                {
                    _baseScript._navMeshAgent.SetDestination(_target.transform.position);
                }
                yield return new WaitForEndOfFrame();
            }
            //attack if possible
            if ((Time.time - _lastTimeAttack) < _cooldownAttack)
            {
                Attack();
            }
            yield return new WaitForEndOfFrame();
        }
    }

    private void Attack()
    {
        if (_spawnProjectile)
        {
            GameObject projectile = GameObject.Instantiate(_projectile, this.transform.position, Quaternion.identity);
            projectile.GetComponent<ProjectileBehavior>().Initialise(_target, _damage);
        }
    }

}
