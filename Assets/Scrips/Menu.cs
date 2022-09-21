using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public void Vatly()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Hoahoc()
    {
        SceneManager.LoadScene("HOA");
    }
    public void Sinhhoc()
    {
        SceneManager.LoadScene("SINH");
    }
    public void ReplayVatLy()
    {
        AudioController.Ins.StopMusic();
           SceneManager.LoadScene("SampleScene");
    }
    public void ReplayHoa()
    {
        AudioController.Ins.StopMusic();
        SceneManager.LoadScene("HOA");
    }
    public void ReplaySinhHoc()
    {
        AudioController.Ins.StopMusic();
        SceneManager.LoadScene("SINH");
    }
}
