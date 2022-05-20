using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] ParticleSystem successParticle;
    [SerializeField] ParticleSystem explosion;

    void OnEnable()
    {
        RingTrigger.OnTriggerRing += Success;
        JetCrash.OnJetCrash       += Explode;
    }

    void OnDisable()
    {
        RingTrigger.OnTriggerRing -= Success;
        JetCrash.OnJetCrash       -= Explode;
    }

    private void Success()
    {
        successParticle.Play();
    }

    private void Explode()
    {
        explosion.Play();
    }
}
