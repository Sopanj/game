using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class guns : MonoBehaviour
{
    public Transform gun;
    Vector2 direction;
    public GameObject bullet;
    public float bulletSpeed;
    public Animator gunAnim;
    public Transform shootingPoint;
    public float shootingSpeed;
    public float ReadyForNextShot;
    public float dtime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)gun.position;
        facemouce();
        if(Input.GetMouseButton(0))
        {
            
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time + 1 / shootingSpeed;
                    shot();
            }
        }
    }

    void facemouce()
    {
        gun.transform.right = direction;
    }

    void shot()
    {
        
        GameObject bulletint=Instantiate(bullet,shootingPoint.position,shootingPoint.rotation);
        bulletint.GetComponent<Rigidbody2D>().AddForce(bulletint.transform.right * bulletSpeed);
        gunAnim.SetTrigger("shoot");
        Destroy(bulletint,dtime);
    }
}
