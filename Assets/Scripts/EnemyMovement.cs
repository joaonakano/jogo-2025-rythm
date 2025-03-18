using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject _enemySettings;

    public Transform Player;

    private float _moveSpeed;
    private Material _material;
    private int _maxDistance;
    private int _minDistance;


    private void Start()
    {
        _material = _enemySettings.color;
        _moveSpeed = _enemySettings.speed;

        gameObject.GetComponent<MeshRenderer>().material = _material;
    }

    private void Update()
    {
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= _minDistance)
        {
            transform.position += transform.forward * _moveSpeed * Time.deltaTime;

            if (Vector3.Distance(transform.position, Player.position) <= _maxDistance)
            {

            }
        }
    }
}
