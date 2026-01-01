using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    public string itemName = "Coin"; // 아이템 이름
    public int amount = 1;           // 획득 수량

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponentInParent<Inventory>();
            Debug.Log("Inventory: " + playerInventory);
            if (playerInventory != null)
            {
                playerInventory.AddItem(itemName, amount);
            }
            Destroy(gameObject); // 아이템 삭제
        }
    }
}
