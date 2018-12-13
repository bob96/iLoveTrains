using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax, yMin, yMax;
}


public class PlayerController : MonoBehaviour {

    public float speed;
    public float thrustDown;
    private Quaternion calibrationQuaternion;
    //public float speedForward;
    public Boundary boundary;
    private Rigidbody rb;
    private float screenWidth;
    private float horizontalMove;
    private float maxY;
    

	// Use this for initialization
	void Start () {
        maxY = transform.position.y;
        rb = GetComponent<Rigidbody>();
        screenWidth = Screen.width;
       
	}

        

    private void FixedUpdate()
    {
        Vector3 accelarationRaw = Input.acceleration;
        Vector3 accelaration = FixAcceleration(accelarationRaw);

        //float horizontalMove = Input.();
        //horizontalMove = Input.GetAxis("Horizontal");
        
        // touch input--------------------------------
        int i = 0;
        while (i < Input.touchCount)
        {
            if(Input.GetTouch(i).position.x > screenWidth / 2)
            {
                MoveCharacher(1.0f);
            }
            if (Input.GetTouch(i).position.x < screenWidth / 2)
            {
                MoveCharacher(-1.0f);
            }
            ++i;
        }
        //--------------------------------------------
        
        //Input with accelerometre
        //rb.velocity = new Vector3(accelaration.x * speed, rb.velocity.y, rb.velocity.z);
        //input with the horizontal axis
        rb.velocity = new Vector3(horizontalMove * speed, rb.velocity.y, rb.velocity.z);

        if(transform.position.y >= maxY)
        {
            rb.velocity = Vector3.up * thrustDown;
        }

        rb.position = new Vector3
           (
               Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
               Mathf.Clamp(transform.position.y, boundary.yMin,boundary.yMax),
               Mathf.Clamp(transform.position.x, boundary.zMin, boundary.zMax)
           );

        

       // rb.AddForce(0, 0, speedForward, ForceMode.Impulse);

        

    }

    public void MoveCharacher(float horizontalInput)
    {
        horizontalMove = horizontalInput;
    }

    //calibrate the input.acceleration input
    void CalibrateAccellerometer()
    {
        //get the acceleration vector3 in a local variable
        Vector3 accelerationSnapShot = Input.acceleration;
        //invert the acceleration vector3
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0f, 0.0f, -1.0f), accelerationSnapShot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }
    //get the calibrated value from the input
    Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }

}
