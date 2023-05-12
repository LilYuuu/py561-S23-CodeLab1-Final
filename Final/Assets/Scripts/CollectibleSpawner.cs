using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    public GameObject collectiblePrefab;

    public void SpawnCollectible(Vector3 position)
    {
        GameObject newCollectible = Instantiate(collectiblePrefab, position, Quaternion.identity);
    }
}