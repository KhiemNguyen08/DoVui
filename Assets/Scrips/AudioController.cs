using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    // Start is called before the first frame update
    public static AudioController Ins;
    [Range(0, 1)]
    public float musicVolume;
    public AudioSource ausMusic;
    [Range(0, 1)]
    public float SoundVolume;
    public AudioSource ausSound;
    public AudioClip[] backgroundMusic;
    public AudioClip rightAnswer;
    public AudioClip loseSound;
    public AudioClip winSound;
    private void Awake()
    {
        MakeSingleton();
    }
    void Start()
    {
        PlayBackgroundMucsic();
    }

    // Update is called once per frame
    void Update()
    {
        //if(ausMusic && ausSound)
        //{
        //    ausSound
        //}
    }
    public void PlayRightsound()
    {
        PlaySound(rightAnswer);
    }
    public void PlayloseSound()
    {
        PlaySound(loseSound);
    }
    public void PlaywinSound()
    {
        PlaySound(winSound);
    }
    public void StopMusic()
    {
        if (ausMusic)
        {
            ausMusic.Stop();
        }
    }
    public void PlaySound(AudioClip sound)
    {
        if(ausSound && sound)
        {
            ausSound.PlayOneShot(sound);
            ausSound.volume = SoundVolume;
        }
    }
    public void PlayBackgroundMucsic()
    {
        if(ausMusic && backgroundMusic!= null && backgroundMusic.Length > 0)
        {
            int randIdx = Random.Range(0, backgroundMusic.Length);
            if (backgroundMusic[randIdx])
            {
                ausMusic.clip = backgroundMusic[randIdx];
                ausMusic.volume = musicVolume;
                ausMusic.Play();
            }
        }
    }
    public void MakeSingleton()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else
            Destroy(gameObject);
    }
}
