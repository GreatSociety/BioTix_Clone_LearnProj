using UnityEngine;

[CreateAssetMenu(fileName = "CellData", menuName = "CellData", order = 51)]
public class CellData : ScriptableObject
{
    [SerializeField] private int maxHP;

    [SerializeField] private float size;

    public int MaxHP { get => maxHP; }
    public float Size { get => size; }

}
