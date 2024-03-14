using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFloor : MonoBehaviour
{
    public List<GameObject> floorPrefabs;
    public Transform playerTransform;
    public float spawnZ = 0;
    public float floorLength = 10.0f;
    public int numberOfFloorsOnScreen = 7;

    private List<GameObject> activeFloors;
    private int lastPrefabIndex = -1; // Khởi tạo lastPrefabIndex với giá trị -1 để đảm bảo prefab đầu tiên được sinh ra không giống với prefab trước đó

    private void Awake()
    {
        activeFloors = new List<GameObject>();

        // Sinh ra floor ban đầu
        for (int i = 0; i < numberOfFloorsOnScreen; i++)
        {
            SpawnFloors();
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - 30 > (spawnZ - numberOfFloorsOnScreen * floorLength))
        {
            SpawnFloors();
            DeleteFloor();
        }
    }

    private void SpawnFloors()
    {
        int randomIndex = Random.Range(0, floorPrefabs.Count);

        // Kiểm tra xem prefab mới có trùng với prefab trước đó không
        while (randomIndex == lastPrefabIndex)
        {
            randomIndex = Random.Range(0, floorPrefabs.Count);
        }

        lastPrefabIndex = randomIndex; // Lưu lại chỉ số của prefab được sinh ra gần nhất

        GameObject go = Instantiate(floorPrefabs[randomIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        spawnZ += floorLength;
        activeFloors.Add(go);
    }

    private void DeleteFloor()
    {
        Destroy(activeFloors[0]);
        activeFloors.RemoveAt(0);
    }
}
