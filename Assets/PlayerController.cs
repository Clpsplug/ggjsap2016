using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed = 3.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            //var dir = transformdirection(Vector3.forward)
            //conrtl.move(dir*speed)
            gameObject.GetComponent<Transform>().position += transform.right * Time.deltaTime;
        }

        if (Input.GetKey("d"))
        {
            gameObject.GetComponent<Transform>().Rotate(0, 2.0f, 0);
        }

        if (Input.GetKey("a"))
        {
            gameObject.GetComponent<Transform>().Rotate(0, -2.0f, 0);
        }

        if (Input.GetKey("s"))
        {
            gameObject.GetComponent<Transform>().position -= transform.right * Time.deltaTime;
        }
    }
}
