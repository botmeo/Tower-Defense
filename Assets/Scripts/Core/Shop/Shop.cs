using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private TurretBlueprint standardTurret;
    [SerializeField] private TurretBlueprint laserTurret;
    [SerializeField] private TurretBlueprint missileTurret;

    public void SelectStandardTurret()
    {
        Debug.Log("StandardTurret");
        BuildManager.Instance.SelectTurretToBuild(standardTurret);
    }

    public void SelectLaserTurret()
    {
        Debug.Log("LaserTurret");
        BuildManager.Instance.SelectTurretToBuild(laserTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("MissileTurret");
        BuildManager.Instance.SelectTurretToBuild(missileTurret);
    }
}

