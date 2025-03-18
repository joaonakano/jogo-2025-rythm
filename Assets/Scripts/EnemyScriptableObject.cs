using UnityEngine;

[CreateAssetMenu(fileName = "enemySettings", menuName = "Inimigos/EnemyScriptableObject")]
public class EnemyScriptableObject : ScriptableObject
{
    public float speed;
    public Material color;
}
