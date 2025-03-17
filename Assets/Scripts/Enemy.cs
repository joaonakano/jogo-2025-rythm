using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject enemySettings;

    public string name;
    public float health;
    public float speed;

    private void Start()
    {
        name = enemySettings.name;
        health = enemySettings.health;
        speed = enemySettings.speed;
    }
}
