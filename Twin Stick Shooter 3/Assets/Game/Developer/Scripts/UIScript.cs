using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
public class UIScript : MonoBehaviour {

    [SerializeField]
    private Canvas _pauseMenu;

    [SerializeField]
    private GameObject _player;

    private bool _openMenu = false;


    private void Start() {
        _pauseMenu.enabled = false;
    }

    private void Update() {

        #region PauseMenu
        if (Input.GetKeyDown(KeyCode.Escape)) {
            _openMenu = !_openMenu;
            PauseMenu();
        }
        #endregion

    }

    private void PauseMenu() {

        if (_openMenu) {
            _player.GetComponent<Opsive.ThirdPersonController.ItemHandler>().enabled = false;
            _pauseMenu.enabled = true;
        }
        if (!_openMenu) {
            _player.GetComponent<Opsive.ThirdPersonController.ItemHandler>().enabled = true;
            _pauseMenu.enabled = false;
        }
    }

    public void ResumeGame() {
        _openMenu = false;
        PauseMenu();
    }

    public void QuitGame() {
        SceneManager.LoadScene(0);
    }
}


/* 


    
    public PrimitiveType primairy;
    public ConsumableItemType type;

    Debug.Log(playerInventory.GetItemCount(weaponItemType.ConsumableItem.ItemType) + "/" + weaponItemType.ConsumableItem.Capacity);

    


    [SerializeField]
    PrimaryItemType weaponItemType;

    [SerializeField]
    Inventory playerInventory;



            print(primairy.)?
    */
