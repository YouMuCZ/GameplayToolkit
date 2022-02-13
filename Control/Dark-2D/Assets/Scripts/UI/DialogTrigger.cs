using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public GameObject buttonUI;
    public GameObject dialogUI;
    public GameObject touchTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag(touchTag.tag)) buttonUI.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag(touchTag.tag)) buttonUI.SetActive(false);
    }

    void Update()
    {
        if (buttonUI.activeSelf && Input.GetKeyDown(KeyCode.X))
        {
            dialogUI.SetActive(true);
        }
    }
}
