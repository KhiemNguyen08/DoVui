using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    int m_rightCount; // đếm câu trả lời đúng
    public float timeQuestion; // thời gian trả lời câu hỏi
    float m_curTime;
    // Start is called before the first frame update
    private void Awake()
    {
        m_curTime = timeQuestion;
    }
    void Start()
    {
        UI.Ins.SetTimeText("00: " + m_curTime);
        CreateQuestion();
        StartCoroutine(TimeCoutingDown());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CreateQuestion()
    {
        QuestionData qs = QuestionManager.Ins.GetRandomquestion();// gọi hàm quétiondata
        if(qs!= null)
        {
            UI.Ins.SetQuestionText(qs.question);//hiển thị câu hỏi ngoài giao diện
            string[] wrongAnser = new string[] { qs.answerA, qs.answerB, qs.answerC };// mảng câu trả lời sai
            UI.Ins.ShuffAnswer();//gán tag
            var temp = UI.Ins.answerbuton;// biến đại diện các câu trả lời
            if(temp!=null && temp.Length > 0)
            {
                int wrongAnswerCount = 0;
                for (int i = 0; i < temp.Length; i++)
                {
                    int answerid = i;
                    if (string.Compare(temp[i].tag, "RightAnswer") == 0)
                    {
                        temp[i].SetAnswerText(qs.rightAnswer);
                    }
                    else
                    {
                        temp[i].SetAnswerText(wrongAnser[wrongAnswerCount]);
                        wrongAnswerCount++;
                    }
                    temp[answerid].btnComp.onClick.RemoveAllListeners();
                    // mỗi khi nhấn click gọi vào hàm checkrightanswer
                    temp[answerid].btnComp.onClick.AddListener(() => CheckRightAnswerEvent(temp[answerid]));
                }
            }
        }
    }
    public void CheckRightAnswerEvent(Answerbuton answerbuton)
    {
        if (answerbuton.CompareTag("RightAnswer"))
        {
            m_curTime = timeQuestion;
            UI.Ins.SetTimeText("00: " + m_curTime);
            m_rightCount++;
            if (m_rightCount == QuestionManager.Ins.questions.Length)
            {
                Debug.Log("ban da thg");
                UI.Ins.dialog.SetdialogContent("Bạn đã chiến thắng <3");
                AudioController.Ins.PlaywinSound();
                UI.Ins.dialog.Show(true);
                StopAllCoroutines();
            }
            else
            {
                AudioController.Ins.PlayRightsound();
                CreateQuestion();
                            Debug.Log("dung");
            }
           
        }
        else
        {
            Debug.Log("ban da thua");
            AudioController.Ins.PlayloseSound();
            UI.Ins.dialog.SetdialogContent("Bạn đã thua");
            UI.Ins.dialog.Show(true);
            StopAllCoroutines();
        }
           
    }
    IEnumerator TimeCoutingDown()//thời gian thay đổi
    {
        yield return new WaitForSeconds(1);//thời gian thay đổi (1)
        
        if (m_curTime > 0)
        {
            m_curTime--;
            StartCoroutine(TimeCoutingDown());
            UI.Ins.SetTimeText("00: " + m_curTime);
        }
        else
        {
            AudioController.Ins.StopMusic();
            UI.Ins.dialog.SetdialogContent("Đã hết thời gian trả lời");
            UI.Ins.dialog.Show(true);
            StopAllCoroutines();
        }
       
    }
    //public void Replay()
    //{
    //    AudioController.Ins.StopMusic();
    //    SceneManager.LoadScene("SampleScene");
        
    //}
    public void Exit()
    {
        Application.Quit();
    }
    public void Home()
    {
        SceneManager.LoadScene("Menu");
    }
}
