using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Cameraanim : MonoBehaviour {

    private Animator m_animator;

    private bool m_isPlaying = false;

    private void Start() {

        m_animator = GetComponent<Animator>();

    }

    public void Play() {

        if (!m_isPlaying) {

            m_animator.SetTrigger("MainMenuPlayStart");
            m_isPlaying = true;

        }

    }

    public void HowToPlay() {

        if (!m_isPlaying) {

            m_animator.SetTrigger("MainMenuHowToPlay");
            m_isPlaying = true;

        }

    }

    public void HowToPlayBack() {

        if (!m_isPlaying) {

            m_animator.SetTrigger("MainMenuHowToPlayBack");
            m_isPlaying = true;

        }

    }

    public void Credits() {

        if (!m_isPlaying) {

            m_animator.SetTrigger("MainMenuCreditsStart");
            m_isPlaying = true;

        }

    }

    public void AllowAnimationPlay() {

        m_isPlaying = false;

    }

}
