using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public int bulletsremaining;
    public int Totalbullets = 60;
    public int secondclip = 30;
    public Text Bulletsremain;
    public Text Extrabullets;
    int usedbullets = 0;
    bool CanShoot;
    public Transform ShootP;
    //public AudioSource Bulletshoot;

    void Start()
    {
        //Cursor.visible = false;
        CanShoot = true;
        bulletsremaining = 30;
        Bulletsremain.text = bulletsremaining.ToString();
        Extrabullets.text = secondclip.ToString();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && bulletsremaining > 0 && !chatsystem.IsTalking && CanShoot)
        {
            Instantiate(bulletPrefab, ShootP.position, ShootP.rotation);
            bulletsremaining--;
            //Bulletshoot.Play();
            Bulletsremain.text = bulletsremaining.ToString();
            usedbullets++;
        }
        if (Input.GetMouseButtonDown(0) && bulletsremaining <= 0)
        {
            Bulletsremain.color = Color.red;
            Debug.Log("Reload!!!");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (bulletsremaining < 30)
            {
                Bulletsremain.color = Color.black;
                StartCoroutine(ReloadDelay());
            }
            else
            {
                Debug.Log("Ammo Full");
            }
        }
    }

    IEnumerator ReloadDelay()
    {
        CanShoot = false;
        yield return new WaitForSeconds(3f);
        if (secondclip != 0)
        {
            CanShoot = true;
            if (secondclip >= 0)
            {
                if (usedbullets > secondclip)
                {
                    usedbullets = secondclip;
                }
                bulletsremaining += usedbullets;
                secondclip -= usedbullets;
                usedbullets = 0;
                Bulletsremain.text = bulletsremaining.ToString();
                Extrabullets.text = secondclip.ToString();
                if (secondclip <= 0)
                {
                    Extrabullets.color = Color.red;
                    usedbullets = 0;
                    secondclip = 0;
                    Extrabullets.text = secondclip.ToString();
                }
            }
        }
    }
}
