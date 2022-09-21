using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    // Start is called before the first frame update
    public Text dialogText;
    public void Show(bool isshow)
    {
        gameObject.SetActive(isshow);
    }
    public void SetdialogContent(string content)
    {
        if (dialogText)
        {
            dialogText.text = content;
        }
    }
}
