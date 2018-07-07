﻿using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class FirstPersonRaycastComponent : MonoBehaviour
{
    const string TAKE_OR_INTERACT_BUTTON = "Fire1";
    const string HOLD = "Hold";
    public SessionPlayer CurrentPlayer;
    int lastFrameTaw = 0;

    [SerializeField] LayerMask interactibleLayers;
    [SerializeField] float interactibleDistance;
    [SerializeField] float force;

    [SerializeField] HUDController HUD;

    Rigidbody holdedItem;
    Vector3 point;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            var g = CurrentPlayer.PlayerHideInventory.SpawnSelected(transform.position + transform.forward);
            if (g)
            {
                var rb = g.GetComponent<Rigidbody>();
                if (rb)
                {
                    rb.AddForce(this.transform.forward * 2000f);
                }
            }
            return;
        }
    }

    void FixedUpdate()
    {

        if ((Input.GetAxisRaw(HOLD) == 0 && Input.GetButton(TAKE_OR_INTERACT_BUTTON) == false) || (holdedItem != null && Vector3.Distance(this.transform.position, holdedItem.position) > interactibleDistance * 1.8f))
        {
            FirstPersonController.HoldingThing = false;
            holdedItem = null;
            HUD.DisplayNone();
        }
        else if (holdedItem != null)
        {
            HUD.DisplayOverInteractable(holdedItem.gameObject);
            holdedItem.AddForceAtPosition(
                transform.TransformVector(new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * force / Time.deltaTime),
                point
            );
        }

        RaycastHit rh;
        Ray r = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(r, out rh, interactibleDistance, interactibleLayers))
        {
            switch (LayerMask.LayerToName(rh.collider.gameObject.layer))
            {
                case "Item":
                    var hitItem = rh.collider.gameObject.GetComponent<SceneItem>();
                    HUD.DisplayOverItem(hitItem);
                    if (Input.GetButtonDown(TAKE_OR_INTERACT_BUTTON))
                    {
                        if(hitItem.ItemDescription.Owner == CurrentPlayer)                        
                            CurrentPlayer.PlayerHideInventory.AddItem(hitItem.ItemDescription);
                        else
                            CurrentPlayer.PlayerInventory.AddItem(hitItem.ItemDescription);

                        hitItem.Collect();                        
                    }
                    break;
                case "Interactable":
                    holdedItem = rh.collider.gameObject.GetComponent<Rigidbody>();
                    HUD.DisplayOverInteractable(rh.collider.gameObject);
                    if (lastFrameTaw  == 0 && Input.GetAxisRaw(HOLD) != 0 || Input.GetButtonDown(TAKE_OR_INTERACT_BUTTON))
                    {
                        FirstPersonController.HoldingThing = true;
                        point = rh.transform.InverseTransformPoint(rh.point);
                    }

                    lastFrameTaw = Mathf.RoundToInt(Input.GetAxisRaw(HOLD));
                    break;
                default:
                    if (!FirstPersonController.HoldingThing)
                    {
                        HUD.DisplayNone();
                    }
                    break;
            }
        }
    }

}
