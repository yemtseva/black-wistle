using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{

    [SerializeField] GameObject RightHitBox;
    [SerializeField] GameObject LeftHitBox;
    [SerializeField] GameObject BackHitBox;

    public float moveSpeed = 0f;
    public Rigidbody2D rb;
    public Animator animator;
    float nextAttackTime = 0f;
    public float attackRate = 2f;

    Vector2 movement;

    // Update is called once per frame


    private void Start()
    {

        RightHitBox.SetActive(false);
        LeftHitBox.SetActive(false);
        BackHitBox.SetActive(false);
    }


    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);

        if (Time.time >= nextAttackTime)
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        FindObjectOfType<AudioManager>().Play("Sword");

        if (movement.x <= -1 && movement.y == 0)
        {
            StartCoroutine(DoAttack(LeftHitBox));

        }

        else if (movement.y >= 1)
        {
            StartCoroutine(DoAttack(BackHitBox));
        }
        else
        {
            StartCoroutine(DoAttack(RightHitBox));
        }
    }

    IEnumerator DoAttack(GameObject HitBox)
    {
        yield return new WaitForSeconds(0.1f);
        HitBox.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        HitBox.SetActive(false);
    }

}
