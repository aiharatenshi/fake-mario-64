using UnityEngine;
using System.Collections;

public class ArrowMove : MonoBehaviour {
	
	Vector3 moveVector;
	public float speed = 5;
	public float jumpSpeed = 2;
	public float turnspeed = 1;
	public float fallSpeed = 1;
	public bool grounded = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		moveVector = Vector3.zero;
		if (Input.GetKey(KeyCode.W)){
			moveVector += transform.forward;
			
			
		}
		
		if (Input.GetKey (KeyCode.S)){
			//rigidbody.AddForce(-transform.forward * speed);
			moveVector += -transform.forward;
		}
			
		
		if (Input.GetKey (KeyCode.A)){
			//rigidbody.AddForce(Vector3.right * speed);
			transform.Rotate (0f, -turnspeed * Time.deltaTime, 0f);
		
		
		}
		
		if (Input.GetKey (KeyCode.D)){
			//rigidbody.AddForce(Vector3.left * speed);
			transform.Rotate (0f, turnspeed * Time.deltaTime, 0f);
			
		}
		
		if( Physics.Raycast(transform.position, -transform.up, 1.5f)){
			grounded = true;
			
		if (Input.GetKey (KeyCode.Space)){
		
			moveVector += Vector3.up * jumpSpeed;
		}
			else{
				grounded = false;
			}
		}
	
	}
	
	void FixedUpdate(){
		if (moveVector != Vector3.zero){
			rigidbody.AddForce(moveVector * speed, ForceMode.VelocityChange );
		}
		
		else{
			rigidbody.AddForce(-rigidbody.velocity + Physics.gravity * fallSpeed, ForceMode.Acceleration);
		}
		
	}
}
