using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RekenOpdrachtVisueel : MonoBehaviour {

    [SerializeField]
    private GameObject m_graphicElement;

    private Transform m_parent;

    private Vector3[,] m_grid = new Vector3[20, 9];

    private float m_spacing = 20f;

    private void Start() {

        // find background
        m_parent = transform.parent;

        for (int x = 0; x < 20; x++) {

            for (int y = 0; y < 9; y++) {

                m_grid[x, y] = new Vector3(x * m_spacing, y * m_spacing);

            }

        }

    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.K)) {

            AttachTiles();

        }

    }

    private void AttachTiles() {

        Vector3 offset = new Vector3(transform.localScale.x / 2, transform.localScale.y / 2);

        for (int i = 0; i < m_parent.GetComponent<RekenOpdrachtSysteem>()._timeStamps.Length; i++) {

            for (int x = 1; x < m_parent.GetComponent<RekenOpdrachtSysteem>()._timeStamps[i]; x++) {

                Instantiate(m_graphicElement, m_grid[x, m_parent.GetComponent<RekenOpdrachtSysteem>()._timeStampIndex], Quaternion.identity, transform);

            }

        }

        //foreach(Vector3 element in m_grid) {

        //    Instantiate(m_graphicElement, element + offset * 15, Quaternion.identity, this.transform);

        //}

    }

}
