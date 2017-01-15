using UnityEngine;
using System.Collections;

public class Recommencer : MonoBehaviour {
    private GameObject canvasGagner;
	// Use this for initialization
	void Start () {
        canvasGagner = GameObject.Find("canvasGagner");
	}
	
	// Update is called once per frame
	void Update () {
        // Si le canvas gagner est activer il fait que l'utilisateur appuye sur enter pour redemarrer le jeu
	    if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return) && canvasGagner.active == true)
        {
            canvasGagner.SetActive(false);
            Application.LoadLevel(Application.loadedLevel);
        }
	}
}
