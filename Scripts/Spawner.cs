using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cube, sphere;
    public bool cubeObject, sphereObject;

    public Material defultMat, selectedMat;

    private Transform selection;
    public bool isSelected;





    void Update()
    {
        // Object Spwan
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    if (sphereObject) { Instantiate(sphere, hit.point + new Vector3(0f, 0.5f, 0f), Quaternion.identity); }
                    if (cubeObject) { Instantiate(cube, hit.point + new Vector3(0f, 0.5f, 0f), Quaternion.identity); }
                }

                // object selection
                isSelected = !isSelected;
                if (hit.collider.CompareTag("Selected"))
                {
                     selection = hit.transform;
                    
                    if (selection != null && isSelected)
                    {
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        selectionRenderer.material = selectedMat;
                    }

                    if (selection != null && !isSelected) 
                    {
                        var selectionRenderer = selection.GetComponent<Renderer>();
                        selectionRenderer.material = defultMat;
                    }                 
                }
                
            }
        }


        if (Input.GetKeyDown(KeyCode.Delete) && isSelected)
        {
            Destroy(selection.gameObject);
        }
    }


    public void ToggleCube()
    {
        cubeObject = !cubeObject;
        sphereObject = false;
    }

    public void ToggleSphere()
    {
        sphereObject = !sphereObject;
        cubeObject = false;
    }









}
