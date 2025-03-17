using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Enemy _enemySettings;

    private float _speed;

    [SerializeField]
    private float _rotationSpeed;

    private Rigidbody _rigidBody;
    private PlayerAwarenessController _playerAwarenessController;
    private Vector3 _targetDirection;

    private void Awake()
    {
        _enemySettings = GetComponent<Enemy>();
        _playerAwarenessController = GetComponent<PlayerAwarenessController>();
        _rigidBody = GetComponent<Rigidbody>();
        _speed = _enemySettings.speed;
    }

    void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector3.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if(_targetDirection == Vector3.zero)
        {
            return;
        }

        Quaternion targetRotation = Quaternion.LookRotation(_targetDirection, transform.up);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        _rigidBody.MoveRotation(rotation);
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector3.zero) {
            return;
        }
        else
        {
            Vector3 moveDirection = _targetDirection.normalized * _speed * Time.deltaTime;
            _rigidBody.MovePosition(_rigidBody.position + moveDirection);
        }
    }
}
