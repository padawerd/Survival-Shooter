using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	public float speed = 6;
	private Vector3 movement;
	private Animator animator;
	private Rigidbody playerRigidbody;
	private int floorMask;
	private float cameraRayLength = 100;

	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		animator = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		float horizontalMovement = Input.GetAxisRaw("Horizontal");
		float verticalMovement = Input.GetAxisRaw("Vertical");
		Move(horizontalMovement, verticalMovement);
		Turning();
		Animating(horizontalMovement, verticalMovement);
	}

	void Move(float horizontal, float vertical) {
		movement.Set(horizontal, 0, vertical);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
	}

	void Turning() {
		Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit floorHit;
		if (Physics.Raycast(cameraRay, out floorHit, cameraRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0;

			Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
			playerRigidbody.MoveRotation(newRotation);
		}
	}

	void Animating(float horizontal, float vertical) {
		bool walking = horizontal != 0 || vertical != 0;
		animator.SetBool("IsWalking", walking);
	}
}
