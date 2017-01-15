using UnityEngine;
using System.Collections;

public class ActionZombie : MonoBehaviour {
    Transform joueur;
    public bool estVivant;
    public static float moveSpeed = 2.0f;
    public float rotSpeed = 15.0f;
    private Animator animateur;
    private CharacterController _charController;
    float distanceZombiePlayer = 50.0f;
    float distanceAttaque = 1.5f;
    private float gravity = -20.0f;

    // Use this for initialization
    void Start () {
        joueur = GameObject.FindGameObjectWithTag("Player").transform;
        estVivant = true;
        animateur = GetComponent<Animator>();
        _charController = GetComponent<CharacterController>();
    }

    void Awake()
    {
        Messenger<float>.AddListener(GameEvent.DIFFICULTE_CHANGE, ChangerVitesse);
    }

    void OnDestroy()
    {
        Messenger<float>.RemoveListener(GameEvent.DIFFICULTE_CHANGE, ChangerVitesse);
    }

	// Update is called once per frame
	void Update () {
        // Si le zombie est vivant et qu
	    if (estVivant && Vector3.Distance(transform.position, joueur.position) < distanceZombiePlayer)
        {
            if (Vector3.Distance(transform.position, joueur.position) < distanceAttaque)
            {
                animateur.SetBool("Attaque", true);
            }
            else
            {
                transform.LookAt(new Vector3(joueur.position.x, joueur.position.y, joueur.position.z));
                Vector3 movement = new Vector3(0, 1, 1 * moveSpeed);
                movement.y += gravity * 5 * Time.deltaTime;
                transform.Translate(new Vector3(0, 0, moveSpeed * Time.deltaTime));
                animateur.SetBool("Attaque", false);
            }
        }             
    }

    public void EstVivant(bool enVie)
    {
        estVivant = enVie;
    }

    public void ChangerVitesse(float vitesse)
    {
        if (vitesse == 0)
        {
            moveSpeed = 2.0f;
        }
        if (vitesse == 1)
        {
            moveSpeed = 4.0f;
        }
        if (vitesse == 2)
        {
            moveSpeed = 6.0f;
        }
    }
}
