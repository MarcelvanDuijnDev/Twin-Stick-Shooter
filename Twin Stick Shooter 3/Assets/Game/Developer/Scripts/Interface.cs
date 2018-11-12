using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Opsive.ThirdPersonController.Wrappers;

public class Interface : MonoBehaviour {
	//public Text healthText;
    public Text ammoText;
    //public Text timesPlayedText;
    //public Text killedByText;

	//private float healthCount;
	private Text ammoText2;
    private Text timesPlayed2;
    private Text killedBy2;

	public bool droneActivate;
	public GameObject droneCamera;

    //private int health;

    public PrimitiveType primairy;
    public ConsumableItemType type;

    [SerializeField]
    PrimaryItemType weaponItemType;

    [SerializeField]
    Inventory playerInventory;

    // Use this for initialization
    void Start () {
        SetCountText();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GameObject getHealth = GameObject.Find("Player");
        PlayerScript playerScript = getHealth.GetComponent<PlayerScript>();
        //healthCount = healthPlayer2.healthPlayer;
        try {

			ammoText.text = playerInventory.GetItemCount(weaponItemType.ConsumableItem.ItemType) + "/" + weaponItemType.ConsumableItem.Capacity;
            //timesPlayedText.text = playerScript.timesPlayed.ToString();
            //killedByText.text = playerScript.diedBy.ToString();

            SetCountText();
        } 
		catch 
		{

        }

		if (Input.GetKeyDown ("[7]"))
		{
			droneActivate = !droneActivate;
		}
		if (droneActivate) {
            droneCamera.SetActive (true);
		} else {
            droneCamera.SetActive (false);
		}

    }

    void SetCountText()
    {
        //healthText.text = "Health: " + healthCount;
        GameObject getHealth = GameObject.Find("Player");
        PlayerScript playerScript = getHealth.GetComponent<PlayerScript>();

        try {
            ammoText2.text = "Ammo: " + ammoText;
            //timesPlayed2.text = "Times Played: " + timesPlayedText;
            //killedBy2.text = "Killed By: " + killedByText;
        }
        catch {

        }
    }
}






   



            //print(primairy.)?