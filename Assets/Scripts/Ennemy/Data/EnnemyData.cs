using UnityEngine;

[CreateAssetMenu(fileName = "EnnemyData", menuName = "Data/Ennemy", order = 1)]
public class EnnemyData : ScriptableObject
{
    public int HP = 10;
    public int damage = 1;
    public float speed = 1f;
    public float range = 0.1f;
    public float attackSpeed = 0.5f;
}