using System.Collections.Generic;
using TMPro; // TextMeshPro 사용
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;       // 플레이어 Inventory 연결
    public TMP_Text inventoryText;    // Panel 안 Text 연결

    // UI 갱신 함수
    /*public void RefreshUI()
    {
        if (inventoryText == null)
        {
            Debug.LogWarning("inventoryText 연결 안 됨!");
            return;
        }

        Debug.Log("RefreshUI 호출, items.Count = " + inventory.items.Count);

        inventoryText.text = "";
        foreach (var item in inventory.items)
        {
            inventoryText.text += $"{item.itemName} x{item.amount}\n";
        }
    }*/

    public void RefreshUI()
    {
        inventoryText.text = "";

        /*foreach (ItemData item in inventory.items)
        {
            inventoryText.text += item.itemName + "\n";
        }*/

        foreach (KeyValuePair<ItemData, int> pair in inventory.items)
        {
            ItemData data = pair.Key;
            int count = pair.Value;

            inventoryText.text += $"{data.itemName} x {count}\n";
        }
    }

}
