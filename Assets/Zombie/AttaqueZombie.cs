using UnityEngine;
using System.Collections;

public class AttaqueZombie : MonoBehaviour {
    GameObject joueur;
    PointDeVie pvJoueur;
    int damage = 1;
	// Use this for initialization
	void Start () {
        joueur = GameObject.FindGameObjectWithTag("Player");
        pvJoueur = joueur.GetComponent<PointDeVie>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player")
        {
            if (pvJoueur.estVivant)
                pvJoueur.Blessé(damage);
        }
    }
}
