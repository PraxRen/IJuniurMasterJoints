using UnityEngine;

public class Catapult : MonoBehaviour
{
    [SerializeField] private SpringJoint _springJointSpoon;
    [SerializeField] private Transform _attackPoint;
    [SerializeField] private Transform _idlePoint;
    [SerializeField] private Transform _projectilePoint;
    [SerializeField] private Rigidbody _projectilePrefab;
    [SerializeField] private float _lifetimeProjectile;
    [SerializeField] private float _spting;
    [SerializeField] private KeyCode _buttonAttack;
    [SerializeField] private KeyCode _buttonRestart;

    private bool _isStateAttack;
    private Rigidbody _rigidbodyProjectile;
    private Rigidbody _rigidbodySpoon;

    private void Start()
    {
        _rigidbodySpoon = _springJointSpoon.GetComponent<Rigidbody>();
        _springJointSpoon.connectedAnchor = _idlePoint.position;
        _springJointSpoon.spring = _spting;
        SpawnProjectile();
    }

    private void Update()
    {
        if (_isStateAttack)
        {
            if (Input.GetKeyDown(_buttonRestart) == false)
            {
                return;
            }

            Restart();
        }
        else
        {
            if (Input.GetKeyDown(_buttonAttack) == false)
            {
                return;
            }

            Attack();
        }
    }

    private void Attack()
    {
        _rigidbodyProjectile.isKinematic = false;
        _rigidbodyProjectile.transform.parent = null;
        _springJointSpoon.connectedAnchor = _attackPoint.position;
        Destroy(_rigidbodyProjectile, _lifetimeProjectile);
        _rigidbodySpoon.WakeUp();
        _isStateAttack = true;
    }

    private void Restart()
    {
        _springJointSpoon.connectedAnchor = _idlePoint.position;
        SpawnProjectile();
        _rigidbodySpoon.WakeUp();
        _isStateAttack = false;
    }

    private void SpawnProjectile()
    {
        _rigidbodyProjectile = Instantiate(_projectilePrefab, _projectilePoint.position, _springJointSpoon.transform.rotation, _springJointSpoon.transform);
        _rigidbodyProjectile.isKinematic = true;
    }
}