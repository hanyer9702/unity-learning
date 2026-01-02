using UnityEngine;
using static UnityEditor.Progress;

public class Item : MonoBehaviour
{
    /*public string itemName = "Coin"; // 아이템 이름
    public int amount = 1;           // 획득 수량

    public int scoreValue = 10;*/

    public ItemData itemData;

    public void SetData(ItemData data)
    {
        itemData = data;

        // 외형도 데이터 기준으로 변경
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null && data.icon != null)
        {
            sr.sprite = data.icon;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("Player"))
        {
            Inventory playerInventory = other.GetComponentInParent<Inventory>();
            Debug.Log("Inventory: " + playerInventory);
            if (playerInventory != null)
            {
                playerInventory.AddItem(itemName, amount);
            }

            ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(scoreValue);
            }

            Destroy(gameObject); // 아이템 삭제
        }*/

        if (other.CompareTag("Player"))
        {
            Inventory inventory = other.GetComponent<Inventory>();
            if (inventory != null)
            {
                inventory.AddItem(itemData);
            }

            Destroy(gameObject);
        }
    }
}
