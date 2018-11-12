using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleInput : MonoBehaviour {

    [SerializeField]
    private string o_input;

	public void Interact()
    {
        //if (transform.parent.GetComponent<Console>().o_code.Length < 4) {

            if (o_input == "Enter") {
                transform.parent.GetComponent<Console>().Enter();
            }
            else if (o_input == "Clear") {
                transform.parent.GetComponent<Console>().o_code = "";
                transform.parent.GetComponent<Console>().UpdateCode();
            }
            else {
                transform.parent.GetComponent<Console>().o_code += o_input;
                transform.parent.GetComponent<Console>().UpdateCode();
                print(o_input);
            }

        //}

    }
}
