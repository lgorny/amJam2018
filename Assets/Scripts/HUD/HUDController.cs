using UnityEngine;

public class HUDController : MonoBehaviour
{
    [SerializeField] GameObject DisplayWhenNone;
    [SerializeField] GameObject DisplayWhenItem;
    [SerializeField] GameObject DisplayWhenInteractable;

    public void DisplayNone()
    {
        this.DisplayWhenNone.SetActive(true);
        this.DisplayWhenItem.SetActive(false);
        this.DisplayWhenInteractable.SetActive(false);
    }

    public void DisplayOverItem(SceneItem item)
    {
        this.DisplayWhenNone.SetActive(false);
        this.DisplayWhenItem.SetActive(true);
        this.DisplayWhenInteractable.SetActive(false);
    }

    public void DisplayOverInteractable(GameObject go)
    {
        this.DisplayWhenNone.SetActive(false);
        this.DisplayWhenItem.SetActive(false);
        this.DisplayWhenInteractable.SetActive(true);
    }
}
