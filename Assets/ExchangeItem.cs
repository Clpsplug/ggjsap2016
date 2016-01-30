using UnityEngine;
using System.Collections;

public class ExchangeItem : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (Input.GetKey("q"))
        {
            switch (col.gameObject.tag.ToString())
            {
                case "izanami":
                    if(ItemFlags.Items[1] == 1)
                    {
                        ItemFlags.Items[1] = 2;
                    }
                    break;

                case "isotakeru":
                    if (ItemFlags.Items[2] == 1)
                    {
                        ItemFlags.Items[2] = 2;
                    }
                    break;

                case "sukunahiko":
                    if (ItemFlags.Items[3] == 1)
                    {
                        ItemFlags.Items[3] = 2;
                    }
                    break;

                case "shiotsutsi":
                    if (ItemFlags.Items[4] == 1)
                    {
                        ItemFlags.Items[4] = 2;
                    }
                    break;

                case "takeminakata":
                    if (ItemFlags.Items[5] == 1)
                    {
                        ItemFlags.Items[5] = 2;
                    }
                    break;
            }
        }
    }
}
