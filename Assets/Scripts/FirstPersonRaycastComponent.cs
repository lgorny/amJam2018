using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FirstPersonRaycastComponent : MonoBehaviour
{
    const string TAKE_OR_INTERACT_BUTTON = "Fire1";

    [SerializeField] LayerMask interactibleLayers;
    [SerializeField] float interactibleDistance;
    [SerializeField] float force;

    void FixedUpdate()
    {
        FirstPersonController.HoldingThing = false;
        RaycastHit rh;
        Ray r = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(r, out rh, interactibleDistance, interactibleLayers))
        {
            switch (LayerMask.LayerToName(rh.collider.gameObject.layer))
            {
                case "Item":
                    if (Input.GetButtonDown(TAKE_OR_INTERACT_BUTTON))
                    {
                        Debug.LogWarning("Taken " + rh.collider.gameObject.name);
                    }
                    break;
                case "Interactable":
                    if (Input.GetButton(TAKE_OR_INTERACT_BUTTON))
                    {
                        FirstPersonController.HoldingThing = true;
                        rh.collider.gameObject.GetComponent<Rigidbody>().AddForce(transform.TransformVector(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * force / Time.deltaTime));
                    }
                    break;
            }
        }
    }

}
