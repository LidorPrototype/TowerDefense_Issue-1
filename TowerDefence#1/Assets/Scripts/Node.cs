using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;

    private Renderer rend;
    private Color startColor;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!(buildManager.CanBuild))
        {
            return;
        }

        BuildTurret(buildManager.GetTurretToBuild());

    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStates.Money < blueprint.cost)
        {
            Debug.Log("Not enough money to build that");
            return;
        }

        PlayerStates.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        turretBlueprint = blueprint;

        Debug.Log("Turret Built! ");
    }

    public void UpgradeTurret()
    {
        if (PlayerStates.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enough money to upgrade that");
            return;
        }

        PlayerStates.Money -= turretBlueprint.upgradeCost;

        //Get rid of the old turret
        Destroy(turret);

        //Getting new upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded! ");
    }

    public void SellTurret()
    {
        PlayerStates.Money += turretBlueprint.GetSellAmount();

        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(turret);
        turretBlueprint = null;
    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!(buildManager.CanBuild))
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    void OnMouseExit()
    {
        rend.material.color = startColor;
    }

}
