using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spw : MonoBehaviour
{
    public List<GameObject> floorPrefabs;
    public Transform playerTransform;
    public float spawnZ = 0;
    public float floorLength = 20.0f;
    public int numberOfFloorsOnScreen = 5;
    public float minY = -1f;
    public float maxY = 1f;

    private List<GameObject> activeFloors;
    private int lastPrefabIndex = 0;

    private void Start()
    {
        activeFloors = new List<GameObject>();

        // Sinh ra floor ban đầu
        for (int i = 0; i < numberOfFloorsOnScreen; i++)
        {
            SpawnFloor();
        }
    }

    private void Update()
    {
        if (playerTransform.position.z - 40 > (spawnZ - numberOfFloorsOnScreen * floorLength))
        {
            SpawnFloor();
            DeleteFloor();
        }
    }

    private void SpawnFloor()
    {
        GameObject go = Instantiate(floorPrefabs[Random.Range(0, floorPrefabs.Count)]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = new Vector3(go.transform.position.x, Random.Range(minY, maxY), spawnZ); // Random vị trí y
        spawnZ += floorLength;
        activeFloors.Add(go);
    }

    private void DeleteFloor()
    {
        Destroy(activeFloors[0]);
        activeFloors.RemoveAt(0);
    }
}
