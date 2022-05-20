using System;
using UnityEngine;

public class JetCrash : MonoBehaviour
{
    public static event Action OnJetCrash;

    void OnCollisionEnter(Collision collision)
    {
        OnJetCrash?.Invoke();
    }
}
