using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "NewPlayer")
        {
            GameObject.FindObjectOfType<LevelLoader>().MainMenu();
        }
    }
}
