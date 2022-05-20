using System;
using UnityEngine;

public class RingTrigger : MonoBehaviour
{
    public static event Action OnTriggerRing;
    public static event Action OnMissedRing;
    public static event Action OnRingsFinished;

    void Update()
    {
        if (RingPool.rings.Count > 0)
        {
            if (MissedRing()) OnMissedRing?.Invoke();
        }

        else
        {
            OnRingsFinished?.Invoke();
        }
    }

    void OnTriggerEnter()
    {
        OnTriggerRing?.Invoke();
    }

    private bool MissedRing()
    {
        GameObject currentRing = RingPool.rings[0];
        return transform.position.z > currentRing.transform.position.z;
    }
}
