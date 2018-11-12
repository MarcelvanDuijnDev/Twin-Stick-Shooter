using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Console : MonoBehaviour {

    //private GameObject o_textMesh;
    [SerializeField]
    private GameObject o_text;

    [SerializeField]
    private string o_correctCode;

    [HideInInspector]
    public string o_code = "";

    private void Start()
    {
        //o_textMesh = GameObject.Find("TextMeshPro Text");
        UpdateCode();
    }

    private void Update()
    {
        UpdateCode();
    }

    public void UpdateCode() {

        o_text.transform.GetChild(0).GetComponent<TextMeshProUGUI>().SetText(o_code);

    }

    public void Enter()
    {
        if (o_code == o_correctCode)
        {
            Debug.Log("Deur is open");
        }
    }
}
