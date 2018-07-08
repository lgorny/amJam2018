using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class SoundOnColision : MonoBehaviour
{
    AudioSource CachedAudioSource { get; set; }
    Rigidbody CachedRigidbody { get; set; }
    Vector3 velocity;
    Vector3 angularVelocity;

    [SerializeField] AudioClip[] clips = new AudioClip[0];
    [SerializeField] bool AlsoScrape;

    [SerializeField] bool AlsoOnSlow = false;
    [SerializeField] bool AlsoOnAngularSlow = false;

    bool locked = true;

    private void Awake()
    {
        CachedAudioSource = GetComponent<AudioSource>();
        CachedRigidbody = GetComponent<Rigidbody>();
    }

    private IEnumerator Start()
    {
        locked = true;
        yield return new WaitForSeconds(1.6f);
        locked = false;

        if (clips == null || clips.Length == 0)
        {
            clips = new AudioClip[1] { this.CachedAudioSource.clip };
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (locked) return;
        if (clips.Length > 0)
            CachedAudioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], collision.relativeVelocity.magnitude * .5f);
    }

    private void FixedUpdate()
    {
        if (locked) return;
        if (clips.Length == 0) return;
        if (!CachedRigidbody) return;

        if (AlsoOnAngularSlow && CachedRigidbody.angularVelocity.magnitude < .1f && angularVelocity.magnitude > .1f)
        {
            CachedAudioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], (angularVelocity.magnitude - CachedRigidbody.angularVelocity.magnitude) * .5f);
        }

        if (AlsoOnSlow && velocity.magnitude > .1 && CachedRigidbody.velocity.magnitude < .1)
        {
            CachedAudioSource.PlayOneShot(clips[Random.Range(0, clips.Length)], (velocity.magnitude - CachedRigidbody.velocity.magnitude));
        }

        angularVelocity = CachedRigidbody.angularVelocity;
        velocity = CachedRigidbody.velocity;
    }

    private void Update()
    {
        if (locked) return;
        if (CachedRigidbody == null)
        {
            Object.Destroy(this);
        }

        if (AlsoScrape && AudioMagica.Instance)
            AudioMagica.Instance.SetVol(Mathf.Min(1f, (this.CachedRigidbody.velocity.magnitude * .2f)) / Vector3.Distance(this.transform.position, Camera.main.transform.position));
    }
}
