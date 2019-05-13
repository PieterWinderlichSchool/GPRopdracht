using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;

    private Rigidbody Rb;
    private float MoveInputH;
    private float MoveInputV;

    void Start () {
        Rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        MoveInputH = Input.GetAxisRaw("Horizontal");
        MoveInputV = Input.GetAxisRaw("Vertical");
        Rb.velocity = new Vector3(MoveInputH, 0, MoveInputV);
	}
}
