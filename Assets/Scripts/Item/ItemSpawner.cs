using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public Item itemPrefab;
    public ItemData[] spawnItems;

    //public GameObject itemPrefab; // 배치할 Prefab
    //public Vector3 spawnPosition; // 위치 지정

    void Start()
    {
        /*Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        Vector3[] positions = new Vector3[] {
            new Vector3(0,0,0),
            new Vector3(2,0,0),
            new Vector3(4,0,0)
        };

        foreach (Vector3 pos in positions)
        {
            Instantiate(itemPrefab, pos, Quaternion.identity);
        }*/

        for (int i = 0; i < spawnItems.Length; i++)
        {
            /*Vector3 pos = new Vector3(i * 2f, 5, 0);

            Item item = Instantiate(itemPrefab, pos, Quaternion.identity);
            item.SetData(spawnItems[i]);*/

            Vector3[] positions = new Vector3[] {
                new Vector3(i * 2f, 5, 0),
                new Vector3(i * 2f, 10, 0)
            };

            foreach (Vector3 pos in positions)
            {
                Item item = Instantiate(itemPrefab, pos, Quaternion.identity);
                item.SetData(spawnItems[i]);
            }
        }
    }

    public void Spawn()
    {
        Instantiate(itemPrefab, transform.position, Quaternion.identity);
    }
}
