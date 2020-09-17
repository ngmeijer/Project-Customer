using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer = null;
    private Animator animator = null;
    [SerializeField] private float soundVolume = 0;
    [SerializeField] private GameObject aboutUsHolder = null;
    [SerializeField] private GameObject achievementsHolder = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void pauseGameWrapper()
    {
        StartCoroutine(pauseGame());
    }

    public IEnumerator pauseGame()
    {
        animator.SetTrigger("Pause");

        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0f;

        yield break;
    }

    public void resumeGameWrapper()
    {
        StartCoroutine(resumeGame());
    }

    public IEnumerator resumeGame()
    {
        animator.SetTrigger("Resume");
        Time.timeScale = 1;

        yield break;
    }

    public void muteAllAudio()
    {
        audioMixer.SetFloat("VolumeMaster", -80);
    }

    public void unmuteAllAudio()
    {
        audioMixer.SetFloat("VolumeMaster", soundVolume);
    }

    public void achievementsActive()
    {
        animator.SetTrigger("Achievements");
    }

    public void aboutUs()
    {
        animator.SetTrigger("AboutUs");
    }

    public void backToPause()
    {
        animator.SetTrigger("Pause");
    }

    public void quitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void websiteButton()
    {
        Application.OpenURL("https://theoceancleanup.com/");
    }

    public void donateButton()
    {
        Application.OpenURL("https://theoceancleanup.com/donate/");
    }
}
