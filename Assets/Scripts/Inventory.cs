using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //public List<ItemInfo> items = new List<ItemInfo>();
    //public List<ItemData> items = new List<ItemData>();

    public Dictionary<ItemData, int> items = new Dictionary<ItemData, int>();
    public Dictionary<string, ItemInfo> itemDict = new Dictionary<string, ItemInfo>();

    public InventoryUI inventoryUI; // UI ¿¬°á

    public ScoreManager scoreManager;

    // ¾ÆÀÌÅÛ Ãß°¡
    /*public void AddItem(string name, int count = 1)
    {
        if (itemDict.ContainsKey(name))
        {
            itemDict[name].amount += count;
        }
        else
        {
            ItemInfo newItem = new ItemInfo { itemName = name, amount = count };
            items.Add(newItem);
            itemDict.Add(name, newItem);
        }

        Debug.Log(name + " È¹µæ! ÇöÀç ¼ö·®: " + itemDict[name].amount);

        // UI °»½Å
        if (inventoryUI != null)
            inventoryUI.RefreshUI();
    }*/

    public void AddItem(ItemData itemData)
    {
        /*items.Add(itemData);

        Debug.Log(itemData.itemName + " È¹µæ");

        InventoryUI ui = FindObjectOfType<InventoryUI>();
        if (ui != null)
        {
            ui.RefreshUI();
        }*/

        if (items.ContainsKey(itemData))
        {
            items[itemData]++;
        }
        else
        {
            items.Add(itemData, 1);
        }

        Debug.Log(itemData.itemName + " : " + items[itemData]);

        InventoryUI ui = FindObjectOfType<InventoryUI>();
        if (ui != null)
        {
            ui.RefreshUI();
        }

        scoreManager.AddScore(itemData.score);
    }
}
