using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    public Transform LeftSide;
    public Transform RightSide;
    public Transform UpSide;
    public Transform DownSide;

    public int speed = 5;
    public GameObject RedBullet;
    public GameObject GreenBullet;
    public GameObject BlueBullet;

    public int RandomSide;
    public int RandomBullet;

    public float bulletRate = 0.1f;
    float nextBulletTime = 0f;

    // Update is called once per frame

    void Update()
    {
        if (Time.time >= nextBulletTime)
        {
            RandomSide = Random.Range(1, 5);
            Debug.Log(RandomSide);
            RandomBullet = Random.Range(1, 4);

            StartCoroutine(Shoting_Speed());
            nextBulletTime = Time.time + 4f / bulletRate;

        }
    }

    IEnumerator Shoting_Speed()
    {
        yield return new WaitForSeconds(speed);
        Shoot();
        yield return new WaitForSeconds(speed);
        bulletRate = bulletRate + 0.05f;
    }

    void Shoot()
    {
        if (RandomSide == 1)
        {
            if (RandomBullet == 1)
                Instantiate(RedBullet, LeftSide.position, LeftSide.rotation);
            if (RandomBullet == 2)
                Instantiate(GreenBullet, LeftSide.position, LeftSide.rotation);
            if (RandomBullet == 3)
                Instantiate(BlueBullet, LeftSide.position, LeftSide.rotation);
        }
        if (RandomSide == 2)
        {
            if (RandomBullet == 1)
                Instantiate(RedBullet, RightSide.position, RightSide.rotation);
            if (RandomBullet == 2)
                Instantiate(GreenBullet, RightSide.position, RightSide.rotation);
            if (RandomBullet == 3)
                Instantiate(BlueBullet, RightSide.position, RightSide.rotation);
        }
        if (RandomSide == 3)
        {
            if (RandomBullet == 1)
                Instantiate(RedBullet, UpSide.position, UpSide.rotation);
            if (RandomBullet == 2)
                Instantiate(GreenBullet, UpSide.position, UpSide.rotation);
            if (RandomBullet == 3)
                Instantiate(BlueBullet, UpSide.position, UpSide.rotation);
        }
        if (RandomSide == 4)
        {
            if (RandomBullet == 1)
                Instantiate(RedBullet, DownSide.position, DownSide.rotation);
            if (RandomBullet == 2)
                Instantiate(GreenBullet, DownSide.position, DownSide.rotation);
            if (RandomBullet == 3)
                Instantiate(BlueBullet, DownSide.position, DownSide.rotation);
        }
    }

}
