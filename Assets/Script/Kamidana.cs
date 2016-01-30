using UnityEngine;
using System.Collections;

public class Kamidana : MonoBehaviour {

    int i = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "kamidana" && Input.GetKey("z"))
        {
            while (i >= 5)
            {
                if(ItemFlags.Items[i] == 2)
                {
                    ++i;
                }
                else
                {
                    i = 6;
                }
            }

            if (i == 5)
            {
                Debug.Log("game_clear");
            }
            else
            {
                //何も起きない
            }
        }
    }
}
