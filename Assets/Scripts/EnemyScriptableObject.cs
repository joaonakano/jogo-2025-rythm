using UnityEngine;

[CreateAssetMenu(fileName = "enemySettings", menuName = "Scriptable Objects/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public string name;
    public float health;
    public float speed;
}
