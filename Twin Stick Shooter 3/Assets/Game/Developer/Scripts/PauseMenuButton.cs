using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenuButton : PauseMenu {
    
    public enum Action { MAINMENU, QUIT, RESUME, YES, NO}
    public Action m_action;

    private void Start() {

        switch (transform.name) {

            case "Main Menu":
                this.GetComponent<Button>().onClick.AddListener(ToMainMenu);
                return;

            case "Menu":
                this.GetComponent<Button>().onClick.AddListener(ToMainMenu);
                return;

            case "Quit":
                this.GetComponent<Button>().onClick.AddListener(ToConfirmQuit);
                return;

            case "Quit Game":
                this.GetComponent<Button>().onClick.AddListener(ToConfirmQuit);
                return;

            case "Exit":
                this.GetComponent<Button>().onClick.AddListener(ToConfirmQuit);
                return;

            case "Exit Game":
                this.GetComponent<Button>().onClick.AddListener(ToConfirmQuit);
                return;

            case "Resume":
                this.GetComponent<Button>().onClick.AddListener(Resume);
                return;

            case "Resume Game":
                this.GetComponent<Button>().onClick.AddListener(Resume);
                return;

            case "Continue":
                this.GetComponent<Button>().onClick.AddListener(Resume);
                return;

            case "Continue Game":
                this.GetComponent<Button>().onClick.AddListener(Resume);
                return;

            case "Back":
                this.GetComponent<Button>().onClick.AddListener(Resume);
                return;

            case "Yes":
                this.GetComponent<Button>().onClick.AddListener(ToQuit);
                return;

            case "No":
                this.GetComponent<Button>().onClick.AddListener(ToPauseMenu);
                return;

            default:
                CheckWithEnum();
                return;

        }

    }

    private void CheckWithEnum() {

        switch (m_action) {

            case Action.MAINMENU:
                this.GetComponent<Button>().onClick.AddListener(ToMainMenu);
                return;

            case Action.QUIT:
                this.GetComponent<Button>().onClick.AddListener(ToQuit);
                return;

            case Action.RESUME:
                this.GetComponent<Button>().onClick.AddListener(Resume);
                return;

            default:
                Debug.LogError("Zeg tegen Levi dat de naam van de button hier in de switch-statement moet komen, of stel handmatig in wat de button moet doen in zijn inspector!");
                return;

        }

    }

}
