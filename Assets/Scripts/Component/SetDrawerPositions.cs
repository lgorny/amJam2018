using UnityEngine;

public class SetDrawerPositions : MonoBehaviour
{
    public Transform[] Drawers;

    private void Start()
    {
        foreach (var t in Drawers)
        {
            t.localPosition = Vector3.zero;
        }
    }
}
