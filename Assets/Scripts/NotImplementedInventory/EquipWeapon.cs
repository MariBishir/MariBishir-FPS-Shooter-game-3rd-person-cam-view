using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipWeapon : MonoBehaviour
{
    public GameObject inventory;
    public GameObject[] weapons;
    GameObject currentWeapon;

    void Start()
    {
        inventory.SetActive(false);
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
            inventory.SetActive(true);

        else if (Input.GetKeyUp(KeyCode.Tab))
            inventory.SetActive(false);
    }

    public void SelectWeapon(int choice)
    {
        

        if (currentWeapon != null)
            currentWeapon.SetActive(false);

        currentWeapon = weapons[choice];
        currentWeapon.SetActive(true);
    }

}
