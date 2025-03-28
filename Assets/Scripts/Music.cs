using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioScript : MonoBehaviour
{
    AudioSource m_AudioSource;
    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.time = PlayerPrefs.GetFloat("ClipTime", 0);
        m_AudioSource.Play();
    }



    // Update is called once per frame
    void Update()
    {

    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetFloat("ClipTime", 0);
    }

}