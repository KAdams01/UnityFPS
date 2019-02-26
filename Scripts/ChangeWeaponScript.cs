using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ChangeWeaponScript : MonoBehaviour
{
    public GameObject currentWeapon;
    private Transform weaponPosition;
    private int positionInArray;

    private GameObject[] allWeapons;
	// Use this for initialization
	void Start () {
        if (allWeapons == null)
        {
            allWeapons = GameObject.FindGameObjectsWithTag("Weapon");
            weaponPosition = currentWeapon.transform;
        }

        foreach (var weapon in allWeapons)
        {
            weapon.transform.SetPositionAndRotation(weaponPosition.position, weaponPosition.rotation);
            weapon.SetActive(false);
        }

        currentWeapon = allWeapons[0];
        currentWeapon.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            allWeapons[positionInArray].SetActive(false);
            
            if (positionInArray == allWeapons.Length - 1)
            {
                positionInArray = 0;
            }
            else
            {
                positionInArray++;
            }
            allWeapons[positionInArray].SetActive(true);
            currentWeapon = allWeapons[positionInArray];
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            allWeapons[positionInArray].SetActive(false);
            if (positionInArray == 0)
            {
                positionInArray = allWeapons.Length - 1;
            }
            else
            {
                positionInArray--;
            }
            allWeapons[positionInArray].SetActive(true);
            currentWeapon = allWeapons[positionInArray];
            
        }

    }
}
