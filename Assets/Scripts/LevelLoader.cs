using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static int SceneNumber;
    public GameObject player;
    AudioSource m_AudioSource;
    public int enemyNumber = 3;

    public void Start()
    {
        m_AudioSource = GameObject.FindObjectOfType<AudioSource>();
        enemyNumber = GameObject.FindObjectsOfType<Enemy>().Length;
    }

    public void Update()
    {
        enemyNumber = GameObject.FindObjectsOfType<Enemy>().Length;
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
        if (enemyNumber == 0)
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
    }

    public void Up()
    {
        if (enemyNumber == 0)
        {


            Debug.Log(SceneNumber);
            SceneNumber++;
            Debug.Log(SceneNumber);
            if (SceneNumber < SceneManager.sceneCountInBuildSettings)
            {
                PlayerPrefs.SetString("Start", "Bottom");
                SceneManager.LoadScene(SceneNumber);
            }
            PlayerPrefs.SetFloat("ClipTime", m_AudioSource.time);
        }
    }

    public void Down()
    {
        if (enemyNumber == 0)
        {
            SceneNumber--;

            if (SceneNumber >= 0)
            {
                PlayerPrefs.SetString("Start", "Top");
                SceneManager.LoadScene(SceneNumber);
            }
            PlayerPrefs.SetFloat("ClipTime", m_AudioSource.time);
        }
    }


        public void LastLevel()
    {
        if (enemyNumber == 0)
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

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
        PlayerPrefs.SetFloat("ClipTime", m_AudioSource.time);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
