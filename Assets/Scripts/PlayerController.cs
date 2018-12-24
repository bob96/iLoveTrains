using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax, yMin, yMax;
}


public class PlayerController : MonoBehaviour {

    private Vector3 desiredPosition;
    public float speed;
    public float thrust;
    private Quaternion calibrationQuaternion;
    //public float speedForward;
    public Boundary boundary;
    private Rigidbody rb;
    private float screenWidth;
    private float horizontalMove;
    private float vecticalMove;
    private float maxY;
    //public static bool isGrounded;
    

	// Use this for initialization
	void Start () {
        maxY = transform.position.y;
        rb = GetComponent<Rigidbody>();
        screenWidth = Screen.width;
       
	}


    private void FixedUpdate()
    {
        if (Input.touches.Length != 0)
        {
            if (Input.touches[0].position.x > screenWidth / 2)
            {
                //moveRight;
                transform.position += transform.right * Time.deltaTime * thrust;
            }
            else if (Input.touches[0].position.x < screenWidth / 2)
            {
                //moveleft
                transform.position += -transform.right * Time.deltaTime*thrust;
            }
        }
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);

        Mathf.Clamp(transform.position.x, -4, 4);

    }





}
