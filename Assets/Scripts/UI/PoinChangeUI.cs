using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PoinChangeUI : MonoBehaviour {

    public Text t;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PointChange(int change)
    {
        StopCoroutine("HideDel");

        if (change > 0)
        {
            t.color = new Color(0, 1, 0, 1);
            t.text = "+" + change.ToString();
        }else if (change < 0)
        {
            t.color = new Color(1, 0, 0, 1);
            t.text = change.ToString();
        }

        StartCoroutine("HideDel");
    }

    IEnumerator HideDel()
    {
        yield return new WaitForSeconds(2f);

        t.color = new Color(0, 0, 0, 0);
    }
}
