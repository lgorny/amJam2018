using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SpecialDoor : MonoBehaviour
{
    AudioSource CachedSource;

    public AudioSource specialSource;

    public List<AudioClip> clipsOpen;
    public List<AudioClip> clipsClose;

    public float prevFrameYRotation;
    public float closedRotation;

    private void Awake()
    {
        CachedSource = this.GetComponent<AudioSource>();
    }

    private void Update()
    {
        float currRotation = this.transform.localRotation.eulerAngles.y;

        if (prevFrameYRotation != currRotation)
        {
            //open
            if (Mathf.Abs(prevFrameYRotation - closedRotation) < 1f && Mathf.Abs(currRotation - closedRotation) > 1f)
            {
                CachedSource.PlayOneShot(clipsOpen[Random.Range(0, clipsOpen.Count)]);
                if (specialSource != null)
                {
                    specialSource.PlayOneShot(specialSource.clip);
                }
            }
            //close
            if (Mathf.Abs(prevFrameYRotation - closedRotation) > 1f && Mathf.Abs(currRotation - closedRotation) < 1f)
            {
                CachedSource.PlayOneShot(clipsClose[Random.Range(0, clipsClose.Count)]);
                if (specialSource != null)
                {
                    specialSource.Stop();
                }
            }


        }

        this.prevFrameYRotation = currRotation;
    }


}
