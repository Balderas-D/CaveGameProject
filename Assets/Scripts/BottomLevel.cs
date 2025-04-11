using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomLevel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.FindObjectOfType<LevelLoader>().Down();

    }
}
