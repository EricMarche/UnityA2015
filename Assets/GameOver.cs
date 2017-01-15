using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
    GameObject canvasGameOver;
	// Use this for initialization
	void Start () {
        canvasGameOver = GameObject.Find("GameOver");
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Si le canvas gameover est activé il faut que l'utilisateur appuye sur enter pour continuer
        if (Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return) && canvasGameOver.active == true)
        {
            canvasGameOver.SetActive(false);
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
