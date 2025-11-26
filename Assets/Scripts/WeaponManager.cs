using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject armaLaser;
    public GameObject armaFuego;
    private int armaActual = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            armaActual = 1 - armaActual;
        }
    }
        public GameObject ObtenerArmaActual()
    {
        return armaActual == 0 ? armaLaser : armaFuego;
    }
        public string ObtenerNombreArma()
    {
        return armaActual == 0 ? "LASER" : "FIRE";
    }
}
