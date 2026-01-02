using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    private ItemSpawner itemSpawner;

    private void Awake()
    {
        // 싱글톤 기본 패턴
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        // 같은 오브젝트에 붙은 ItemSpawner 가져오기
        itemSpawner = GetComponent<ItemSpawner>();
    }

    public void SpawnItem()
    {
        if (itemSpawner == null)
        {
            Debug.LogWarning("ItemSpawner가 없습니다.");
            return;
        }

        itemSpawner.Spawn();
    }
}
