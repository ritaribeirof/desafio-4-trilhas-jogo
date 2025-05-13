using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource gameMusic;
    public AudioSource eatSound;
    public AudioSource gameOverSound;

    public void PlayEatSound()
    {
        eatSound.Play();
    }

    public void PlayGameOverSound()
    {
        gameOverSound.Play();
    }

    public void StopMusic()
    {
        gameMusic.Stop();
    }
}
