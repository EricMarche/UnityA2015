using UnityEngine;
using System.Collections;
using UltraReal.Utilities;
using UltraReal.WeaponSystem;

/// <summary> 
/// This is just a dirt simple imput script.  This can easily be replaced with a custom version.
/// </summary>
public class BasicInputExample : Singleton {

    private BasicLauncher launcher;
    private PointDeVie player;
	/// <summary> 
	/// Finds the launcher script.
	/// </summary>
	public void Start ()
	{
        launcher = GetComponent<BasicLauncher>();
        player = GameObject.Find("Player").GetComponent<PointDeVie>();
    }

	/// <summary> 
	/// Tests to see if the player is pressing the fire button, or the reload button.  Activateds
	/// methods on launcher accordingly.
	/// </summary>
	public void Update ()
	{
        // timescale pcq c'est sur pause j'veux pas qui puisse tirer
		if (Input.GetMouseButtonDown (0) && launcher != null && Time.timeScale != 0 && player.estVivant)
			launcher.Fire ();
	}
}
