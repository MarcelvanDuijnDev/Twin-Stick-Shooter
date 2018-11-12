using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    [SerializeField]
    private float m_detectDistance = 2f;
    [SerializeField]
    private float m_loseDistance = 5f;

    private NavMeshAgent m_navMeshAgent;

    private GameObject m_player;

    [SerializeField]
    private GameObject m_waypointParent;

    private Transform m_currentWaypoint;

    [SerializeField]
    private float m_enemyIdleTimeAmount;

    private float m_enemyIdleTime;

    private bool m_isFollowingPlayer = false;

    private void Start() {

        m_navMeshAgent = GetComponent<NavMeshAgent>();

        m_player = GameObject.Find("Player");

        if (m_waypointParent == null || m_waypointParent.transform.childCount == 0) {

            Debug.Log("Er is geen waypoint parent (of hij heeft geen children) bij : " + transform.name);

        }
        else {

            GetNewWaypoint();

        }

    }

    private void Update() {
        
        if (m_player != null) {

            if (Vector3.Distance(transform.position, m_navMeshAgent.destination) <= 2f && m_waypointParent != null) {

                if (!m_isFollowingPlayer) {

                    m_enemyIdleTime -= Time.deltaTime;

                    if (m_enemyIdleTime <= 0) {

                        GetNewWaypoint();

                    }

                }

            }

            if (Vector3.Distance(transform.position, m_player.transform.position) <= m_detectDistance) {

                m_isFollowingPlayer = true;
                m_navMeshAgent.SetDestination(m_player.transform.position);

            }

            if (m_isFollowingPlayer && Vector3.Distance(transform.position, m_player.transform.position) >= m_loseDistance) {

                m_isFollowingPlayer = false;
                m_navMeshAgent.destination = m_currentWaypoint.position;

            }

        }

    }

    private void GetNewWaypoint() {

        if (m_waypointParent != null) {

            m_currentWaypoint = m_waypointParent.transform.GetChild(Random.Range(0, m_waypointParent.transform.childCount));

            m_navMeshAgent.destination = m_currentWaypoint.position;

            m_enemyIdleTime = m_enemyIdleTimeAmount;

        }
        else {

            return;
           
        }

    }

    public void OnDisable() {

        GameObject getHealth = GameObject.Find("Player");
        
        if (getHealth != null) {

            PlayerScript playerScript = getHealth.GetComponent<PlayerScript>();
            playerScript.score += 100;

        }

    }

}
