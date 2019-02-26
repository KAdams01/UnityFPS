using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGunScript : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float cubeLaunchSpeed = 50;
    public bool showCrosshair = true;                   
    public Texture2D crosshairTexture;                 
    public int crosshairLength = 10;                  
    public int crosshairWidth = 4;                   
    public float startingCrosshairSize = 10.0f;         // The gap of space (in pixels) between the crosshair lines (for weapon inaccuracy)
    private float currentCrosshairSize;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray theRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            //GameObject cube = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            //Rigidbody cubeRb = cube.GetComponent<Rigidbody>();
            if (Physics.Raycast(theRay, out hitInfo))
            {
                if (hitInfo.collider.attachedRigidbody != null)
                {
                    if (hitInfo.collider.attachedRigidbody.gameObject.tag == "Box")
                    {
                        Vector3 spawnSpot = hitInfo.collider.transform.position + hitInfo.normal;
                        Instantiate(objectToSpawn, spawnSpot, Quaternion.identity);
                    }
                }


            }

        }

    }
    void OnGUI()
    {
        if (showCrosshair)
        {
            // Hold the location of the center of the screen in a variable
            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);

            // Draw the crosshairs based on the weapon's inaccuracy
            // Left
            Rect leftRect = new Rect(center.x - crosshairLength - currentCrosshairSize, center.y - (crosshairWidth / 2), crosshairLength, crosshairWidth);
            GUI.DrawTexture(leftRect, crosshairTexture, ScaleMode.StretchToFill);
            // Right
            Rect rightRect = new Rect(center.x + currentCrosshairSize, center.y - (crosshairWidth / 2), crosshairLength, crosshairWidth);
            GUI.DrawTexture(rightRect, crosshairTexture, ScaleMode.StretchToFill);
            // Top
            Rect topRect = new Rect(center.x - (crosshairWidth / 2), center.y - crosshairLength - currentCrosshairSize, crosshairWidth, crosshairLength);
            GUI.DrawTexture(topRect, crosshairTexture, ScaleMode.StretchToFill);
            // Bottom
            Rect bottomRect = new Rect(center.x - (crosshairWidth / 2), center.y + currentCrosshairSize, crosshairWidth, crosshairLength);
            GUI.DrawTexture(bottomRect, crosshairTexture, ScaleMode.StretchToFill);
        }
    }
}
