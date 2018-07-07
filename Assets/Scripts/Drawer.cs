using UnityEngine;

public class Drawer : MonoBehaviour
{

    public float XMin = 0f;
    public float XMax = 1f;

    private void Awake()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    private void LateUpdate()
    {
        if (this.transform.localPosition.x < XMin)
        {
            this.transform.localPosition = new Vector3(XMin, transform.localPosition.y, transform.localPosition.z);
        }
        else if (this.transform.localPosition.x > XMax)
        {
            this.transform.localPosition = new Vector3(XMax, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
