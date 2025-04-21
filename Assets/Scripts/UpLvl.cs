using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpLvl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindObjectOfType<LevelLoader>().Up();

    }
}
