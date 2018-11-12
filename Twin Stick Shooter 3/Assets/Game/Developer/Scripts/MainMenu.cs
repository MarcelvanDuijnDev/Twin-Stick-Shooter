using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour {


	public void QuitGame() {
        Application.Quit();
    }

    public void StartGame() {
        SceneManager.LoadScene("Micha");
    }

    public void Play()
    {
		GameObject cameraAnim = GameObject.Find ("Main Camera");
		Cameraanim cameraAnimScript = cameraAnim.GetComponent<Cameraanim> ();
        cameraAnimScript.Play();
    }

	public void HowToPlay()
	{
		GameObject cameraAnim = GameObject.Find ("Main Camera");
		Cameraanim cameraAnimScript = cameraAnim.GetComponent<Cameraanim> ();
        cameraAnimScript.HowToPlay();
    }

	public void HowToPlayBack()
	{
		GameObject cameraAnim = GameObject.Find ("Main Camera");
		Cameraanim cameraAnimScript = cameraAnim.GetComponent<Cameraanim> ();
        cameraAnimScript.HowToPlayBack();
    }

	public void Credits()
	{
		GameObject cameraAnim = GameObject.Find ("Main Camera");
		Cameraanim cameraAnimScript = cameraAnim.GetComponent<Cameraanim> ();
        cameraAnimScript.Credits();
    }
}
