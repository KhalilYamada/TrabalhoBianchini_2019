using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script requires you to have setup your animator with 3 parameters, "InputMagnitude", "InputX", "InputZ"
//With a blend tree to control the inputmagnitude and allow blending between animations.
[RequireComponent(typeof(CharacterController))]
public class MovementInput : MonoBehaviour {

    public float InputX;
    public float InputZ;
	public Vector3 desiredMoveDirection;
	public bool blockRotationPlayer;
	public float desiredRotationSpeed = 0.1f;
	public Animator anim;
    public float Speed;
	public float allowPlayerRotation = 0.1f;
	public Camera cam;
	public CharacterController controller;
	public bool isGrounded;

    [Header("Animation Smoothing")]
    [Range(0, 1f)]
    public float HorizontalAnimSmoothTime = 0.2f;
    [Range(0, 1f)]
    public float VerticalAnimTime = 0.2f;
    [Range(0,1f)]
    public float StartAnimTime = 0.3f;
    [Range(0, 1f)]
    public float StopAnimTime = 0.15f;


    private float verticalVel;
    private Vector3 moveVector;


	void Start () {
		anim = this.GetComponent<Animator> ();
		cam = Camera.main;
		controller = this.GetComponent<CharacterController> ();
	}
	

	void Update () {
        InputMagnitude();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Run", true);
        }
        else
        {
            anim.SetBool("Run", false);
        }



        //If you don't need the character grounded then get rid of this part.
        isGrounded = controller.isGrounded;        
        if (isGrounded) {
			verticalVel -= 0;
            /*if (Input.GetButtonDown("Jump"))
            {
                verticalVel = 0.055f;
            }*/
        } else {
            verticalVel -= 0.05f * Time.deltaTime;
        }
		moveVector = new Vector3 (0, verticalVel, 0);
		controller.Move (moveVector);

    }

    void PlayerMoveAndRotation() {
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		var camera = Camera.main;
		var forward = cam.transform.forward;
		var right = cam.transform.right;

		forward.y = 0f;
		right.y = 0f;

		forward.Normalize ();
		right.Normalize ();

		desiredMoveDirection = forward * InputZ + right * InputX;

		if (blockRotationPlayer == false) {
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (desiredMoveDirection), desiredRotationSpeed);
		}
	}

	void InputMagnitude() {
		//Calculate Input Vectors
        
		InputX = Input.GetAxis ("Horizontal");
		InputZ = Input.GetAxis ("Vertical");

		anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
		anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

		//Calculate the Input Magnitude
		Speed = new Vector2(InputX, InputZ).sqrMagnitude;

		//Physically move player
		if (Speed > allowPlayerRotation) {
			anim.SetFloat ("InputMagnitude", Speed, StartAnimTime, Time.deltaTime);
			PlayerMoveAndRotation ();
		} else if (Speed < allowPlayerRotation) {
			anim.SetFloat ("InputMagnitude", Speed, StopAnimTime, Time.deltaTime);
		}
	}



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Npc"))
        {
            Debug.Log("Death to Player");
        }       
    }

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rb = hit.gameObject.GetComponent<Rigidbody>();        
        if (rb != null)
        {
            rb.AddForce(hit.moveDirection * 20);
        }
    }
}
