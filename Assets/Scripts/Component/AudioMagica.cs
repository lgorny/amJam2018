using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioMagica : MonoBehaviour {


    public static AudioMagica Instance {get; set;}
    private void Awake()
    {
        Instance = this;
    }

    float max = 0f;

    public void SetVol(float v)
    {
        max = Mathf.Max(max, v);
    }

    private void Update()
    {
        max = 0f;
    }

    private void LateUpdate()
    {
        this.GetComponent<AudioSource>().volume = max;
    }
}
