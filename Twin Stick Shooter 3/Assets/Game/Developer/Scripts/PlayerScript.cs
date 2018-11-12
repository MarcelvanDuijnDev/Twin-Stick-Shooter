using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [Header("Option")]
    public bool die;
    public bool respawn;
    public bool restartScene;
    public bool mainMenu;

    [Header("Player")]
    public float healthPlayer;

    [Header("Set")]
    public Transform thisObject;
    public Transform respawnPosition;

    [Header("info")]
    public int score;
    public float timer;
    public int timesPlayed;
    public int timesDied;
    public string diedBy;

    public Text scoreText;

    //Gun

    //[Header("Gun")]

    //public Transform gun;
    private int ammo;
    private int magezine;
    private int fireSpeed;
    private int reloadTime;

	
	// Update is called once per frame
	void Update ()
    {
        SendToText();
        //
        timer += 1 * Time.deltaTime;
        //
        if (healthPlayer <= 0)
        {
            if (die)
            {
                thisObject.gameObject.SetActive(false);
            }
            if (respawn)
            {
                thisObject.transform.position = respawnPosition.position;
                thisObject.transform.rotation = respawnPosition.rotation;
                healthPlayer = 100;
            }
            if (restartScene)
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (mainMenu)
            {
                Application.LoadLevel(1);
            }
            timesPlayed += 1;
            timesDied += 1;
        }
        if (healthPlayer >100)
        {
            healthPlayer = 100;
        }
    }

    public void SendToText()
    {

        scoreText.text = "Score: " + score.ToString();
    }
}
