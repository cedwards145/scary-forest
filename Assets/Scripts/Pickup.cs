using UnityEngine;
using System.Collections;

[RequireComponent (typeof(Rigidbody))]
[RequireComponent (typeof(Collider))]
public class Pickup : MonoBehaviour 
{
	public float pickupDistance = 3;
	private GameObject player;
	private Transform playerWeaponTransform;

	void Awake()
	{
		player = GameObject.FindWithTag ("Player");
		playerWeaponTransform = GameObject.Find("PlayerWeapon").transform;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Transform transform = GetComponent<Transform> ();

		float distance = Vector3.Distance (transform.position, player.transform.position);

		// If player is close enough to pick up item, and presses E
		if (distance < pickupDistance && Input.GetKeyDown (KeyCode.E))
		{
			// Get player's current weapon
			GameObject playerWeapon = GameObject.Find ("EquippedWeapon");

			// If player has weapon already, drop it
			if (playerWeapon != null)
			{
				playerWeapon.transform.parent = null;
				playerWeapon.name = "Pickup";
				playerWeapon.AddComponent<Pickup>();
				playerWeapon.GetComponents<Rigidbody>()[0].isKinematic = false;;
			}

			GameObject weapon = this.gameObject; 
			weapon.GetComponents<Rigidbody>()[0].isKinematic = true;
			weapon.transform.parent = playerWeaponTransform;
			weapon.transform.localPosition = Vector3.zero;
			weapon.transform.localRotation = Quaternion.identity;
			weapon.transform.localScale = Vector3.one;
			weapon.name = "EquippedWeapon";
			Destroy (this);
		}
	}
}
