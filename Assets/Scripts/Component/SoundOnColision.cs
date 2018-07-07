using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource), typeof(Rigidbody))]
public class SoundOnColision : MonoBehaviour
{
    AudioSource CachedAudioSource { get; set; }
    Rigidbody CachedRigidbody { get; set; }
    Vector3 velocity;
    Vector3 angularVelocity;

    [SerializeField] bool AlsoOnSlow = false;
    [SerializeField] bool AlsoOnAngularSlow = false;

    private void Awake()
    {
        CachedAudioSource = GetComponent<AudioSource>();
        CachedRigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator Start()
    {
        this.CachedAudioSource.volume = 0f;
        yield return new WaitForSeconds(.7f);
        this.CachedAudioSource.volume = 1f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        CachedAudioSource.PlayOneShot(CachedAudioSource.clip, collision.relativeVelocity.magnitude);
    }

    private void FixedUpdate()
    {
        if (AlsoOnAngularSlow && CachedRigidbody.angularVelocity.magnitude < .1f && angularVelocity.magnitude > .1f)
        {
            CachedAudioSource.PlayOneShot(CachedAudioSource.clip, (angularVelocity.magnitude - CachedRigidbody.angularVelocity.magnitude) * .5f);
        }

        if (AlsoOnSlow && velocity.magnitude > .1 && CachedRigidbody.velocity.magnitude < .1)
        {
            CachedAudioSource.PlayOneShot(CachedAudioSource.clip, (velocity.magnitude - CachedRigidbody.velocity.magnitude));
        }

        angularVelocity = CachedRigidbody.angularVelocity;
        velocity = CachedRigidbody.velocity;
    }
}
