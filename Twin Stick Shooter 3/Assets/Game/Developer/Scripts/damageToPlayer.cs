using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageToPlayer : MonoBehaviour {

    
    public float attackDamage;
    public float attackSpeed;
    public float attackDistance;
    private float Timer1;
    public Transform target;
	
	// Update is called once per frame
	void Update ()
    {
        GameObject getHealth = GameObject.Find("Player");
        PlayerScript playerScript = getHealth.GetComponent<PlayerScript>();


        float dist = Vector3.Distance(target.position, transform.position);
        Timer1 -= 1 * Time.deltaTime;
        if (dist <= 3)
        {
            if (Timer1 <= 0)
            {
                if (dist <= attackDistance)
                {
                    playerScript.healthPlayer -= attackDamage;
                    Timer1 = attackSpeed;
                }
            }
        }
    }

}
