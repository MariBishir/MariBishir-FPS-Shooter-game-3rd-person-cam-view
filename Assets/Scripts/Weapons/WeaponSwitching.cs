using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitching : MonoBehaviour
{
    private UIManager uiManager;
    private int currentAmmo;
    public int selectedWeapon = 0;

    void Start()
    {
        SelectWeapon();

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }


    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
                   
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;
            else
                selectedWeapon--;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }
    }

    void SelectWeapon()
    {
        int i = 0;
        // we will take all the Transforms that are childs in current transform (the weapon holder)
        foreach (Transform weapon in transform)
        {
            if (i == selectedWeapon)
                weapon.gameObject.SetActive(true);
            else 
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
