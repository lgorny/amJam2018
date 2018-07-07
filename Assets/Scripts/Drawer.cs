using UnityEngine;

public class Drawer : MonoBehaviour
{
    public bool X = true;
    public float XMin = 0f;
    public float XMax = 1f;

    public bool Y = false;
    public float YMin = 0f;
    public float YMax = 0f;

    public bool Z = false;
    public float ZMin = 0f;
    public float ZMax = 0f;

    private void Awake()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Interactable");
    }

    private void FixedUpdate()
    {
        if (X)
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

        if (Y)
        {
            if (this.transform.localPosition.y < YMin)
            {
                this.transform.localPosition = new Vector3(transform.localPosition.x, YMin, transform.localPosition.z);
            }
            else if (this.transform.localPosition.y > YMax)
            {
                this.transform.localPosition = new Vector3(transform.localPosition.x, YMax, transform.localPosition.z);
            }
        }

        if (Z)
        {
            if (this.transform.localPosition.z < ZMin)
            {
                this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, ZMin);
            }
            else if (this.transform.localPosition.z > ZMax)
            {
                this.transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, ZMax);
            }
        }
    }
}
