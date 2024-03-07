using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class gunswitch : MonoBehaviour
{
    int totalWeapon = 1;
    public int weaponCountIndex = 0;
    public GameObject[] gun;
    public GameObject weaponHolder;
    public GameObject currentGun;
    // Start is called before the first frame update
    void Start()
    {
        totalWeapon = weaponHolder.transform.childCount;
        gun= new GameObject[totalWeapon];
        for(int i =0; i < totalWeapon; i++)
        {
            gun[i] = weaponHolder.transform.GetChild(i).gameObject;
            gun[i].SetActive(false);
        }
        gun[0].SetActive(true);
        currentGun = gun[0];
        weaponCountIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Q))
        {
            if (weaponCountIndex < totalWeapon - 1)
            {
                gun[weaponCountIndex].SetActive(false) ;
                weaponCountIndex += 1;
                gun[weaponCountIndex].SetActive(true);
                currentGun = gun[weaponCountIndex];
            }
        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            if (weaponCountIndex >0)
            {
                gun[weaponCountIndex].SetActive(false);
                weaponCountIndex -= 1;
                gun[weaponCountIndex].SetActive(true);
                currentGun = gun[weaponCountIndex];
            }
        }
    }
}
