using UnityEngine;
using System.Collections;

// 3rd-person movement that picks direction relative to target (usually the camera)
// commented lines demonstrate snap to direction and without ground raycast
//
// To setup animated character create an animation controller with states for idle, running, jumping
// transition between idle and running based on added Speed float, set those not atomic so that they can be overridden by...
// transition both idle and running to jump based on added Jumping boolean, transition back to idle

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour {
	// le mouvement du personnage est relatif a la camera
	// donc ici la target est la caméra
	[SerializeField] private Transform target;
    PointDeVie pv;
    ReactionZombie zombie;
    public bool objectifRamasser;
	public float moveSpeed = 6.0f;
	public float rotSpeed = 15.0f;
    public float forceContact = 14.0f;

    private float gravity = -20.0f;

    private ControllerColliderHit _contact;
	private CharacterController _charController;
	private Animator _animator;

    void Start()
    {
        // on y accède pour effectuer le déplacement  du joueur
        _charController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        pv = GetComponent<PointDeVie>();
        zombie = GameObject.Find("zombie").GetComponent<ReactionZombie>();
        objectifRamasser = false;
    }

	void Update()
    {
       
        if (pv.estVivant)
        {
            //_animator.SetBool("Fire", false);
            // start with zero and add movement components progressively
            Vector3 movement = Vector3.zero;

            // x z movement transformed relative to target
            float horInput = Input.GetAxis("Horizontal");
            float vertInput = Input.GetAxis("Vertical");
            if (horInput != 0 || vertInput != 0)
            {
                // mouvement seulement si on appuie sur les fleches
                movement.x = horInput * moveSpeed;
                movement.z = vertInput * moveSpeed;
                // on limite (clamp) la valeur du mouvement diagonal 
                movement = Vector3.ClampMagnitude(movement, moveSpeed);
                // on conserve la rotation de la caméra avant le mouvement
                Quaternion tmp = target.rotation;
                // on effectue la rotation de la caméra. En Y seulement.
                target.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);
                // on transforme (TransformDirection(movement)) les coordonnées locales de la caméra en coordonnées globales
                movement = target.TransformDirection(movement);
                // on restore les valeurs initiales de rotation pour la caméra
                target.rotation = tmp;

                // face movement direction
                //transform.rotation = Quaternion.LookRotation(movement);
                Quaternion direction = Quaternion.LookRotation(movement);
                transform.rotation = Quaternion.Lerp(transform.rotation,
                                                     direction, rotSpeed * Time.deltaTime);
            }
            _animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetMouseButtonDown(0))
            {
                _animator.SetBool("Fire", true);
            }
            movement.y += gravity * 5 * Time.deltaTime;
            movement *= Time.deltaTime;
            _charController.Move(movement);
        }
	}

	// store collision to use in Update
	void OnControllerColliderHit(ControllerColliderHit hit) {
		_contact = hit;

        Rigidbody body = hit.collider.attachedRigidbody;

        // J'ai mis de la physique sur l'objectif
        if (body != null && !body.isKinematic)
        {
            body.velocity = hit.moveDirection * forceContact;
        }

        // Les deux power up
        if (hit.collider.name == "Vie")
        {
            pv.setVie(5);
            Destroy(hit.collider.gameObject);
        }

        // je change la vie des zombie car je ne peux pas augmenter les degats de mon arme
        if (hit.collider.name == "Degats")
        {
            zombie.setVieMonstre();
            Destroy(hit.collider.gameObject);
        }
    }
}
