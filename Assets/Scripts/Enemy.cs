using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyScriptableObject enemySettings;

    public Material color;
    public float speed;

    private void Start()
    {
        color = enemySettings.color;
        speed = enemySettings.speed;
    }
}
