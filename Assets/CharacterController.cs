using UnityEngine;
using System.Collections;

public class CharacterController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("w"))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0.01f * Time.fixedTime, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Transform>().position += new Vector3(0, 0, 0.01f * Time.fixedTime);
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Transform>().position -= new Vector3(0, 0, 0.01f * Time.fixedTime);
        }

        if (Input.GetKey("s"))
        {
            gameObject.GetComponent<Transform>().position -= new Vector3(0.01f * Time.fixedTime, 0, 0);
        }
    }
}
