using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float throwStrength = 500;
	private GameObject playerCamera;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		playerCamera = GameObject.Find ("PlayerCamera");
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetMouseButtonDown (1)) 
		{
			GameObject weapon = GameObject.Find ("EquippedWeapon");
			if (weapon != null)
			{
				Rigidbody body = weapon.GetComponent<Rigidbody> ();
				dropWeapon(weapon);
				body.AddForce (playerCamera.transform.forward * throwStrength);
			}
		}
	}

	public void dropWeapon(GameObject weapon)
	{
		dropWeapon (weapon, null);
	}

	public void dropWeapon(GameObject weapon, Rigidbody body)
	{
		if (body == null)
			body = weapon.GetComponent<Rigidbody> ();

		weapon.transform.parent = null;
		weapon.name = "Pickup";
		weapon.AddComponent<Pickup>();
		body.isKinematic = false;
	}
}
