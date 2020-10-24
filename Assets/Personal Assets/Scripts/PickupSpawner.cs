using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public Transform PickupParent;
    public List<Transform> spawnLocations;

    private void Awake()
    {
        SpawnPickups();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPickups()
    {
        foreach (Transform _spawnPoint in spawnLocations)
        {
            GameObject pickup = Instantiate(pickupPrefab);
            pickup.transform.position = _spawnPoint.position;
            pickup.transform.parent = PickupParent;
        }
    }
}