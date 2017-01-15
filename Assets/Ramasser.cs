using UnityEngine;
using System.Collections;

public class Ramasser : MonoBehaviour {
    private GameObject ramasser;
    private bool enter;
    private RelativeMovement player;
    // Use this for initialization
    void Start () {
        ramasser = GameObject.Find("CanvasRamasser");
        ramasser.SetActive(false);
        enter = false;
        player = GameObject.Find("Player").GetComponent<RelativeMovement>();
    }

	
	// Update is called once per frame
	void Update ()
    {
        // Si le player 
	    if (enter && Input.GetKeyDown(KeyCode.E))
        {
            player.objectifRamasser = true;
            player.moveSpeed = 4.0f;
            Destroy(this.gameObject);
            ramasser.SetActive(false);
        }
	}

    // Lorsque le joueur entre dans le box collider de l'objectif un canvas apparaitrera et
    // lui permettrera de rammaser l'objectif
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            enter = true;
            ramasser.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            ramasser.SetActive(false);
            enter = false;
        }
    }
}
