using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RekenOpdrachtSysteem : MonoBehaviour {

    private float m_mouseButtonDownTime = 0f;
    private float m_timePassed = 0f;

    public float[] _timeStamps = new float[9];
    public int _timeStampIndex;

    private void Update() {

        m_timePassed = Time.time;

        if (m_timePassed <= 20f) {

            _timeStampIndex = 0;

            if (Input.GetMouseButton(0)) {

                _timeStamps[0] += Time.deltaTime;

            }

        }

        if (m_timePassed > 20f && m_timePassed <= 40f) {

            _timeStampIndex = 1;

            if (Input.GetMouseButton(0)) {

                _timeStamps[1] += Time.deltaTime;

            }

        }
        if (m_timePassed > 40f && m_timePassed <= 60f) {

            _timeStampIndex = 2;

            if (Input.GetMouseButton(0)) {

                _timeStamps[2] += Time.deltaTime;

            }

        }

        if (m_timePassed > 60f && m_timePassed <= 80f) {

            _timeStampIndex = 3;

            if (Input.GetMouseButton(0)) {

                _timeStamps[3] += Time.deltaTime;

            }

        }

        if (m_timePassed > 80f && m_timePassed <= 100f) {

            _timeStampIndex = 4;

            if (Input.GetMouseButton(0)) {

                _timeStamps[4] += Time.deltaTime;

            }

        }

        if (m_timePassed > 100f && m_timePassed <= 120f) {

            _timeStampIndex = 5;

            if (Input.GetMouseButton(0)) {

                _timeStamps[5] += Time.deltaTime;

            }

        }

        if (m_timePassed > 120f && m_timePassed <= 140f) {

            _timeStampIndex = 6;

            if (Input.GetMouseButton(0)) {

                _timeStamps[6] += Time.deltaTime;

            }

        }

        if (m_timePassed > 140f && m_timePassed <= 160f) {

            _timeStampIndex = 7;

            if (Input.GetMouseButton(0)) {

                _timeStamps[7] += Time.deltaTime;

            }

        }

        if (m_timePassed > 160f && m_timePassed <= 180f) {

            _timeStampIndex = 8;

            if (Input.GetMouseButton(0)) {

                _timeStamps[8] += Time.deltaTime;

            }

        }


    }
}
