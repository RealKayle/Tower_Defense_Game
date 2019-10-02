﻿using UnityEngine;
using UnityEngine.EventSystems;
public class node : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;
    public Vector3 positionOffset;
    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;
 
    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if(buildManager.GetTurretToBuild() == null)
            return;


        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return; 
        }
        positionOffset = new Vector3(0f, 0.4f, 0f);
        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (buildManager.GetTurretToBuild() == null)
            return;

      //  buildManager.GetTurretToBuild() == null;


        rend.material.color = hoverColor;
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
