using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5.0f;
    public float bulletLife = 3.0f;
    public Vector3 bulletDirection;
    public Quaternion bulletRotation;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = bulletDirection * bulletSpeed;
        StartCoroutine(BulletLife());
    }

    public void SetRotation(Quaternion rotation)
    {
        //rotation.eulerAngles.z; 
        gameObject.transform.rotation = rotation;
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator BulletLife()
    {
        yield return new WaitForSeconds(bulletLife);
        Destroy(gameObject);
    }


}
