using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WeaponControl : MonoBehaviour
{
    public GameObject playerCam;
    public ParticleSystem muzzleFlash;

    public float range = 100f;
    public float damage = 30f;

    public int maxAmmo = 10;
    private int currentAmmo;
    public float reloadTime = 1f;
    private bool isReloading = false;

    private UIManager uiManager;

    void Start()
    {
        currentAmmo = maxAmmo;

        uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        return;

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        uiManager.UpdateAmmo(currentAmmo);

        isReloading = false;
    }

    void Shoot()
    {
        muzzleFlash.Play();

        currentAmmo--;

        uiManager.UpdateAmmo(currentAmmo);

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {
            //Debug.Log("Hit");
            ZombieControl zombieControl = hit.transform.GetComponent<ZombieControl>();

            if (zombieControl != null)
            {
                zombieControl.Hit(damage);
                                
            }
        }
    }
}
