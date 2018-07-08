using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FridgeBackSound : MonoBehaviour
{

    public AudioSource specialSource;

    public List<AudioClip> clipsOpen;
    public List<AudioClip> clipsClose;

    public float prevFrameYRotation;
    public float closedRotation;

    public float tgtVolume = .24f;

    private void Update()
    {
        float currRotation = this.transform.localRotation.eulerAngles.y;

        if (prevFrameYRotation != currRotation)
        {
            //open
            if (Mathf.Abs(prevFrameYRotation - closedRotation) < 1f && Mathf.Abs(currRotation - closedRotation) > 1f)
            {

                if (specialSource != null)
                {
                    specialSource.volume = tgtVolume;
                }
            }

            //close
            if (Mathf.Abs(prevFrameYRotation - closedRotation) > 1f && Mathf.Abs(currRotation - closedRotation) < 1f)
            {
                if (specialSource != null)
                {
                    specialSource.volume = 0f;
                }
            }
        }

        this.prevFrameYRotation = currRotation;
    }

}
