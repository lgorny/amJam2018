using UnityEngine;
using UnityEngine.Video;

public class IntroScript : MonoBehaviour
{
    public VideoPlayer vidReference;
    float cntr = 0;

    void Start()
    {
        vidReference.loopPointReached += VidReference_loopPointReached;
    }

    private void VidReference_loopPointReached(VideoPlayer source)
    {
        vidReference.Stop();
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }

    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            cntr += Time.deltaTime;
            if (cntr > 1.5f)
            {
                VidReference_loopPointReached(vidReference);
            }
        }
        else
        {
            cntr = 0f;
        }
    }

}
