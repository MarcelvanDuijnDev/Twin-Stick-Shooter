using Opsive.ThirdPersonController.Wrappers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject PlayerCharacter;

    private GameObject m_Character;
    private RigidbodyCharacterController m_CharacterController;
    private Inventory m_CharacterInventory;
    private AnimatorMonitor m_CharacterAnimatorMonitor;
    private CameraController m_CameraController;
    private CameraHandler m_CameraHandler;
    private GameObject m_WeaponWheel;

    /// <summary>
    /// Cache the component references.
    /// </summary>
    private void Awake()
    {
        m_CameraController = Camera.main.GetComponent<CameraController>();
        if (m_CameraController == null)
        {
            Debug.LogError("Error: Unable to find the CameraController.");
            enabled = false;
        }
        m_CameraHandler = m_CameraController.GetComponent<CameraHandler>();
    }

    private void Start()
    {
        SetCharacter();
    }

    private void SetCharacter()
    {
        // Cache the character components.
        m_Character = PlayerCharacter;
        m_CharacterController = PlayerCharacter.GetComponent<RigidbodyCharacterController>();
        m_CharacterInventory = PlayerCharacter.GetComponent<Inventory>();
        m_CharacterAnimatorMonitor = PlayerCharacter.GetComponent<AnimatorMonitor>();
        m_CameraController.Character = PlayerCharacter;
        m_CameraController.Anchor = PlayerCharacter.transform;
        m_CameraController.DeathAnchor = PlayerCharacter.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head);
        m_CameraController.FadeTransform = PlayerCharacter.GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Chest);

        StartCoroutine(DelayedStart());
    }

    IEnumerator DelayedStart() {

        yield return new WaitForSeconds(.2f);

        m_CharacterInventory.LoadDefaultLoadout();


    }
}
