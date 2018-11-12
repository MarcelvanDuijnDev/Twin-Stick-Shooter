using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    private Transform m_pauseMenu;
    private Transform m_confirmQuitMenu;

    private void Start() {

        m_pauseMenu = transform.GetChild(0).GetChild(0);
        m_confirmQuitMenu = transform.GetChild(0).GetChild(1);
        m_pauseMenu.gameObject.SetActive(false);
        m_confirmQuitMenu.gameObject.SetActive(false);

    }

    private void Update() {

        if (Input.GetKeyDown(KeyCode.Escape)) {

            m_pauseMenu.gameObject.SetActive(!m_pauseMenu.gameObject.activeSelf);
            m_confirmQuitMenu.gameObject.SetActive(false);

        }

    }

    protected void ToPauseMenu() {
            
        if (!transform.parent.transform.parent.GetChild(0).gameObject.activeSelf) {

            transform.parent.transform.parent.GetChild(0).gameObject.SetActive(true);
            transform.parent.transform.parent.GetChild(1).gameObject.SetActive(false);

        }

    }

    protected void ToMainMenu() {

        SceneManager.LoadSceneAsync("Game/General/Scenes/MainMenu/MainMenuScene");

    }

    protected void ToConfirmQuit() {

        if (!transform.parent.transform.parent.GetChild(1).gameObject.activeSelf) {

            transform.parent.transform.parent.GetChild(0).gameObject.SetActive(false);
            transform.parent.transform.parent.GetChild(1).gameObject.SetActive(true);

        }
    }

    protected void ToQuit() {

        Application.Quit();

    }

    protected void Resume() {

        transform.parent.transform.parent.GetChild(0).gameObject.SetActive(false);

    }

}
