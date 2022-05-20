using System;
using System.Collections;
using UnityEngine;

public class AutoLanding : MonoBehaviour
{
    [SerializeField] Camera viewCamera;
    private Animator animator;

    public static event Action OnLandingComplete;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void OnEnable()
    {
        RingTrigger.OnRingsFinished += StartLanding;
    }

    void OnDisable()
    {
        RingTrigger.OnRingsFinished -= StartLanding;
    }

    private void StartLanding()
    {
        StartCoroutine(Landing());
    }

    private IEnumerator Landing()
    {
        // Wait a second for a non-immediate transition
        yield return new WaitForSeconds(1f);

        viewCamera.enabled = true;
        animator.enabled = true;

        OnLandingComplete?.Invoke();
    }
}
