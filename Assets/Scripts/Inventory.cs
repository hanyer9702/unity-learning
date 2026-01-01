using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<ItemData> items = new List<ItemData>();
    public Dictionary<string, ItemData> itemDict = new Dictionary<string, ItemData>();

    public InventoryUI inventoryUI; // UI 연결

    // 아이템 추가
    public void AddItem(string name, int count = 1)
    {
        if (itemDict.ContainsKey(name))
        {
            itemDict[name].amount += count;
        }
        else
        {
            ItemData newItem = new ItemData { itemName = name, amount = count };
            items.Add(newItem);
            itemDict.Add(name, newItem);
        }

        Debug.Log(name + " 획득! 현재 수량: " + itemDict[name].amount);

        // UI 갱신
        if (inventoryUI != null)
            inventoryUI.RefreshUI();
    }
}
