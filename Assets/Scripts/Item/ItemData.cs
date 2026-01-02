using UnityEngine;

[CreateAssetMenu(menuName = "Item/Item Data")]
public class ItemData : ScriptableObject
{
    public string itemName;
    public int score;
    public Sprite icon;
}
