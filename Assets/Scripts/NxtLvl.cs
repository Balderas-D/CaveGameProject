using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NxtLvl : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindObjectOfType<LevelLoader>().NextLevel();

    }
}
