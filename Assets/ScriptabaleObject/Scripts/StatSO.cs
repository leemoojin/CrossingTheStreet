
using UnityEngine;

[CreateAssetMenu(fileName = "defaultStatSO", menuName = "Characters/Stats/Default", order = 0)]
public class StatSO : ScriptableObject
{
    [Header("Stat Info")]        
    public float speed;
    public float size;
    public float power;
    public float maxHealth;
    public bool isLeft;

    public LayerMask target;

}
