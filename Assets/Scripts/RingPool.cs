using System.Collections.Generic;
using UnityEngine;

public class RingPool : MonoBehaviour
{
    public GameObject ringPrefab;
    public static List<GameObject> rings = new();

    private float xMin = -15f, xMax = 15f;
    private float yMin = 10f, yMax = 25f;

    private float ringDistance = 0f;
    private float distanceMin = 100f, distanceMax = 150f;

    private int poolSize = 5;
    
    void Start()
    {
        GenerateRingPool();
    }

    void OnEnable()
    {
        RingTrigger.OnTriggerRing += ReturnRing;
        RingTrigger.OnMissedRing  += ReturnRing;
    }

    void OnDisable()
    {
        RingTrigger.OnTriggerRing -= ReturnRing;
        RingTrigger.OnMissedRing  -= ReturnRing;

        rings.Clear();
    }

    private void GenerateRingPool()
    {
        float xRange, yRange;
        
        for (int i = 0; i < poolSize; i++)
        {
            xRange = Random.Range(xMin, xMax);
            yRange = Random.Range(yMin, yMax);

            ringDistance += Random.Range(distanceMin, distanceMax);

            Vector3 spawnPos = new(xRange, yRange, ringDistance);

            GameObject ring = Instantiate(ringPrefab, spawnPos, Quaternion.identity, transform);
            rings.Add(ring);
        }       
    }

    private void ReturnRing()
    {
        if(rings.Count > 0)
        {
            rings[0].SetActive(false);
            rings.RemoveAt(0);
        }        
    }

    
}
