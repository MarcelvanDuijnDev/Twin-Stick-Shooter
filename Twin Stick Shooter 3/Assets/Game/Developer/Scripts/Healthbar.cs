using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Opsive.ThirdPersonController;

public class Healthbar : MonoBehaviour {

    [SerializeField]
    private GameObject m_player;

    private Health m_healthScript;

    [SerializeField]
    private Image m_backGround;

    [SerializeField]
    private Image m_foreGround;

    private float m_health;

    private float m_multiplyAmount;

    private static float m_previousHealth;
    public static float p_previousHealth {set { m_previousHealth = value; }}

    private void Start()
    {
        m_player = GameObject.Find("Player");
        m_health = m_player.GetComponent<PlayerScript>().healthPlayer;

        m_multiplyAmount = m_foreGround.rectTransform.localScale.x / m_health;
    }

    private void Update()
    {
        // update health
        m_health = m_player.GetComponent<PlayerScript>().healthPlayer;

        // apply to healthbar   
        m_foreGround.rectTransform.localScale = new Vector3(m_health * m_multiplyAmount, m_foreGround.rectTransform.localScale.y, m_foreGround.rectTransform.localScale.z);
    }
}
