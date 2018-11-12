using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GotoNextLevel : MonoBehaviour {

    public string sceneName;
    public Transform target;
    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        float dist = Vector3.Distance(target.position, transform.position);
        if (dist <= 2)
        {
            Debug.Log("NextLevel");
            SceneManager.LoadScene(sceneName);
        }

    }
}
