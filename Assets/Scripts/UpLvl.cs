using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLvl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "NewPlayer")
        {
            GameObject.FindObjectOfType<LevelLoader>().Up();
        }
    }
}
