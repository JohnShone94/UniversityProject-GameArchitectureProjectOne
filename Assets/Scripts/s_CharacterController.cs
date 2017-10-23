using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_CharacterController : MonoBehaviour
{
    public bool grounded;
    public bool midJump;
    public bool canJump = true;
    public float runningSpeed = 70.0f;
    public float jumpSpeed = 25.0f;
    public float gravityValue = 50.0f;
    public GameObject mainCamera;
    public CharacterController charCon;

    private bool midWalk;
    private Vector3 walkingDirection = Vector3.zero;
    private string playerStatus = "idle";
    private float walkingSpeed = 90.0f;
    private float rotationSpeed = 120.0f;
    private float charAng = 0.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (grounded)
        {

            midJump = false;

            if (mainCamera.transform.gameObject.transform.GetComponent<s_Camera>().inFirstPerson == true)
            {
                walkingDirection = new Vector3((Input.GetMouseButton(0) ? Input.GetAxis("Horizontal") : 0), 0, Input.GetAxis("Vertical"));
            }
            walkingDirection = new Vector3((Input.GetMouseButton(1) ? Input.GetAxis("Horizontal") : 0), 0, Input.GetAxis("Vertical"));

            walkingDirection = transform.TransformDirection(walkingDirection);
            walkingDirection *= midWalk ? walkingSpeed : runningSpeed;

            playerStatus = "idle";



            if (walkingDirection != Vector3.zero)
            {
                playerStatus = midWalk ? "walking" : "running";
            }

            if (Input.GetKeyDown(KeyCode.Space) && canJump)
            {
                walkingDirection.y = jumpSpeed;
                midJump = true;
            }

        }

        if (mainCamera.transform.gameObject.transform.GetComponent<s_Camera>().inFirstPerson == false)
        {
            if (Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            }
            else
            {
                transform.Rotate(0, Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime, 0);

            }
        }
        else
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1))
            {
                transform.rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
            }

        }

        walkingDirection.y -= gravityValue * Time.deltaTime;

        CollisionFlags flags;
        if (midJump)
        {
            flags = charCon.Move(walkingDirection * Time.deltaTime);
        }
        else
        {
            flags = charCon.Move((walkingDirection + new Vector3(0, -100, 0)) * Time.deltaTime);
        }

        grounded = (flags & CollisionFlags.Below) != 0;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        charAng = Vector3.Angle(Vector3.up, hit.normal);
    }
}
