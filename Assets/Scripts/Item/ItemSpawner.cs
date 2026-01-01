using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject itemPrefab; // 배치할 Prefab
    public Vector3 spawnPosition; // 위치 지정

    void Start()
    {
        Instantiate(itemPrefab, spawnPosition, Quaternion.identity);

        Vector3[] positions = new Vector3[] {
            new Vector3(0,0,0),
            new Vector3(2,0,0),
            new Vector3(4,0,0)
        };

        foreach (Vector3 pos in positions)
        {
            Instantiate(itemPrefab, pos, Quaternion.identity);
        }
    }
}
