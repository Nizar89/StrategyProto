using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    public float _speed = 20f;
    public float _stopDistance = 3f; //should take into account the size of the enemy hitbox. Might not be necessary if no autotarget
    public bool _shouldStick = true; // if true, will stuck to entity for a certain amount of time
    public float _durationStuck = 2f;

    private EntityBase _target;
    private int _damage;

    public void Initialise(EntityBase target, int damage)
    {
        _target = target;
        _damage = damage;
        StartCoroutine(GoToTarget());
    }


    IEnumerator GoToTarget()
    {
        while (Vector3.Distance(this.transform.position,_target.transform.position) > _stopDistance)
        {
            this.transform.LookAt(_target.transform.position);
            transform.Translate(this.transform.forward * _speed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        this.transform.parent = _target.transform;
        yield return new WaitForSeconds(_durationStuck);
    }
}
