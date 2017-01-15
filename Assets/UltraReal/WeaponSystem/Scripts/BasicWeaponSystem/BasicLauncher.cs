using UnityEngine;
using System.Collections;
using UltraReal.Utilities;
using UltraReal.WeaponSystem;

/// <summary> 
/// Basic launcher class.  This would be your gun script.
/// </summary>
public class BasicLauncher : MonoBehaviour
{

	/// <summary> 
	/// Time before the next shot can be fired.
	/// </summary>
	float _nextShotTime;

	/// <summary> 
	/// Time delay before next shot can be fired.  A machine gun would use a really small shot delay.
	/// </summary>
	[SerializeField] 
	private float _shotDelay = 0.1f;

	/// <summary> 
	/// Reference to the Transform for the shell ejector.
	/// </summary>
	[SerializeField]
	private Transform _ejectorTransform = null;

	/// <summary> 
	/// Reference to the Transform for the muzzle position.
	/// </summary>
	[SerializeField]
	private Transform _muzzleTransform = null;

	/// <summary> 
	/// Force applied to ejected shells.
	/// </summary>
	[SerializeField]
	protected float _ejectorForce = 100f;

	/// <summary> 
	/// Torque applied to ejected shells.
	/// </summary>
	[SerializeField]
	protected float _ejectorTorque = 100f;

    /// <summary> 
    /// Reference to the AudioSource for the gun.  If it's null, it will create one.
    /// </summary>
    [SerializeField]
    protected AudioSource _audioSource = null;

    /// <summary> 
    /// Reference to animator for the shooting, and reloading
    /// </summary>
    [SerializeField]
    protected Animator _animator = null;

    /// <summary> 
    /// Name of the trigger in the animation controller for Firing.
    /// </summary>
    [SerializeField]
    protected string _fireAnimTriggerName = "Fire";


    [SerializeField]
    protected UltraRealAmmoBase _ammo;

    /// <summary> 
    ///	Sets defaults for weapon
    /// </summary>
    public void Start ()
	{
		_nextShotTime = Time.time;

        if (_audioSource == null)
            _audioSource = gameObject.AddComponent<AudioSource>();
	}

	/// <summary> 
	///	Fires the weapon
	/// </summary>
	public void Fire ()
	{
		if(_muzzleTransform != null)
            _ammo.SpawnAmmo(_muzzleTransform, _ejectorTransform, _ejectorForce, _ejectorTorque, 2f, _audioSource);


        if (_animator != null)
            _animator.SetTrigger(_fireAnimTriggerName);

        _nextShotTime = Time.time + _shotDelay;
		
	}

}
