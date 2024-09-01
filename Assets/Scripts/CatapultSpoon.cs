using UnityEngine;

public class CatapultSpoon : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJointSpoon;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _idlePoint;
    [SerializeField] private Transform _projectilePoint;
    [SerializeField] private Rigidbody _projectilePrefab;
    [SerializeField] private float _lifetimeProjectile;

    private Rigidbody _rigidbodyProjectile;
    private bool _isStateAttack;

    public void Attack()
    {
        if (_isStateAttack)
        {
            return;
        }

        Shoot();
        _rigidbody.WakeUp();
        _isStateAttack = true;
    }

    public void Restart()
    {
        _springJointSpoon.connectedAnchor = _idlePoint.position;
        SpawnProjectile();
        _rigidbody.WakeUp();
        _isStateAttack = false;
    }

    public void SetSpring(float spring)
    {
        _springJointSpoon.spring = spring;
    }

    private void Shoot()
    {
        _springJointSpoon.connectedAnchor = _attackPoint.position;
        _rigidbodyProjectile.isKinematic = false;
        _rigidbodyProjectile.transform.parent = null;
        Destroy(_rigidbodyProjectile, _lifetimeProjectile);
        _rigidbodyProjectile = null;
    }

    private void SpawnProjectile()
    {
        if (_rigidbodyProjectile != null)
        {
            return;
        }

        _rigidbodyProjectile = Instantiate(_projectilePrefab, _projectilePoint.position, transform.rotation, transform);
        _rigidbodyProjectile.isKinematic = true;
    }
}