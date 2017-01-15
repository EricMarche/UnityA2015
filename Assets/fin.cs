using UnityEngine;
using System.Collections;

public class fin : MonoBehaviour {
    private GameObject canvasGagner;
    private RelativeMovement player;
    private bool terminer;
	// Use this for initialization
	void Start () {
        terminer = false;
        canvasGagner = GameObject.Find("CanvasGagner");
        player = GameObject.Find("Player").GetComponent<RelativeMovement>();
        canvasGagner.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	    if (terminer && Input.GetKeyDown(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        {
            Application.LoadLevel(Application.loadedLevel);
        }
        
	}

    // Lorsque le player entre dans la zone de fin avec l'objectif il gagne
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player" && player.objectifRamasser)
        {
            canvasGagner.SetActive(true);
            Time.timeScale = 0;
            terminer = true;
        }
    }
}
