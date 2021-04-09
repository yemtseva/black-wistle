using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPhys : MonoBehaviour
{

    public float speed = 2f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
    }
     
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Speed_Change());
    }

    IEnumerator Speed_Change()
    {
        yield return new WaitForSeconds(2);
        speed = speed + 0.2f;
        yield return new WaitForSeconds(2);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        Destroy(gameObject);
    }
}
