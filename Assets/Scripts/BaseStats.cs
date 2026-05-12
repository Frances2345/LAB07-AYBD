using UnityEngine;

[CreateAssetMenu(fileName = "BaseStats", menuName = "Scriptable Objects/BaseStats")]
public class BaseStats : ScriptableObject
{
    public string entityName;
    public int id;
    public float speed;
}
