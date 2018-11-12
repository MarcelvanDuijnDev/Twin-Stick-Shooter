using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    [SerializeField]
    private bool m_automaticDoor;

    GameObject m_player;

    [SerializeField]
    private Animator m_animator3;

    private bool m_doorHasAnimated = false;

    private void Start() {

        m_player = GameObject.Find("Player");
        m_animator3 = GetComponent<Animator>();

    }

    private void Update() {

        if (m_automaticDoor) {

            if (Vector3.Distance(m_player.transform.position, this.transform.position) <= 3f) {
                m_animator3.SetBool("DoorOpen", true);
            }
            else {
                m_animator3.SetBool("DoorOpen", false);
            }

        }

    }
}
