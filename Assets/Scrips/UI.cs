using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    // Start is called before the first frame update
    public static UI Ins;
    public Text timeText;
    public Text questiomText;
    public Dialog dialog;
    public Answerbuton[] answerbuton;
    public void Awake()
    {
        MakeSingleton();
    }
   
    public void SetTimeText(string time)
    {
        if (timeText)
        {
            timeText.text = time;
        }
    }
    public void SetQuestionText(string content)
    {
        if (questiomText)
        {
            questiomText.text = content;
        }
    }
    public void ShuffAnswer() //gán tag cho các câu trả lời
    {
        if(answerbuton!= null && answerbuton.Length > 0)
        {
            for (int i = 0; i <answerbuton.Length; i++)
            {
                if (answerbuton[i])
                {
                    answerbuton[i].tag = "Untagged";
                }
            }
            // gán tag cho câu trả lời đúng
            int randIdx = Random.Range(0, answerbuton.Length);
            if (answerbuton[randIdx])
            {
                answerbuton[randIdx].tag = "RightAnswer";
            }
        }
    }
    public void MakeSingleton()
    {
        if(Ins == null)
        {
            Ins = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
