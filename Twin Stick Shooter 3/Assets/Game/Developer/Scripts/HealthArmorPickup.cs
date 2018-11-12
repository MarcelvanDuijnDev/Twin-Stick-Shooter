using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthArmorPickup : MonoBehaviour {

    public Transform player;

    [Header("Settings")]
    public bool Health;
    public bool Ammo;

    public float pickupDistance;
    public float pickupAmount;


    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameObject getHealth = GameObject.Find("Player");
        PlayerScript playerScript = getHealth.GetComponent<PlayerScript>();

        float dist = Vector3.Distance(player.position, transform.position);

        if(dist <= pickupDistance)
        {
            if (Health && playerScript.healthPlayer < 100)
            {
                playerScript.healthPlayer += pickupAmount;
                Destroy(this.gameObject);
            }
            if (Ammo && playerScript.healthPlayer < 100)
            {
                playerScript.healthPlayer += pickupAmount;
                Destroy(this.gameObject);
            }

        }


    }
}
