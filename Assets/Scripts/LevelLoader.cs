using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static int SceneNumber;
    public GameObject player;
    AudioSource m_AudioSource;

    public void Start()
    {
        m_AudioSource = GameObject.FindObjectOfType<AudioSource>();
    }

    private void Awake()
    {
        SceneNumber = SceneManager.GetActiveScene().buildIndex;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("Y", 0);
        PlayerPrefs.SetString("Start", "Center");
    }

    public void NextLevel()
    {
        Debug.Log(SceneNumber);
        SceneNumber++;
        Debug.Log(SceneNumber);
        if (SceneNumber < SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetFloat("Y", player.transform.position.y);
            PlayerPrefs.SetString("Start", "Left");
            SceneManager.LoadScene(SceneNumber);
        }
        PlayerPrefs.SetFloat("ClipTime", m_AudioSource.time);
    }

    public void LastLevel()
    {
        SceneNumber--;

        if (SceneNumber >= 0)
        {
            PlayerPrefs.SetFloat("Y", player.transform.position.y);
            PlayerPrefs.SetString("Start", "Right");
            SceneManager.LoadScene(SceneNumber);
        }
        PlayerPrefs.SetFloat("ClipTime", m_AudioSource.time);
    }
}
