using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class NxtLvl : MonoBehaviour
{
        private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "NewPlayer")
        {
            GameObject.FindObjectOfType<LevelLoader>().NextLevel();
        }
    }
}
