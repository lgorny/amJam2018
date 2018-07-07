using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAfterSecond : MonoBehaviour {
    public List<GameObject> enableAfterSecond;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1f);
        foreach(var o in enableAfterSecond)
        {
            o.SetActive(true);
        }
    }
}
