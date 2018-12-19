using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
    public float speed=30f;
    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.D))
            transform.Translate(new Vector2(speed*Time.deltaTime,0f));
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector2(-speed * Time.deltaTime, 0f));
        if (Input.GetKey(KeyCode.W))
            transform.Translate(new Vector3(0f,0f,speed * Time.deltaTime));
        if (Input.GetKey(KeyCode.S))
            transform.Translate(new Vector3(0f,0f,-speed * Time.deltaTime));

        if (Input.GetKey(KeyCode.RightArrow))
        transform.Rotate(new Vector3(0f, 7f, 0f));
        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Rotate(new Vector3(0f, -7f, 0f));

            
       

		
	}
}
