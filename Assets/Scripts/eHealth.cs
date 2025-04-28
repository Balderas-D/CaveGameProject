using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;
    public int teamId = 1;

    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(this.gameObject);
        }
    }
}
