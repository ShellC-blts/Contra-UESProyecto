using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject armaActual;

    public void CambiarArma(GameObject nuevaArma)
    {
        armaActual = nuevaArma;
    }

    public GameObject ObtenerArmaActual()
    {
        return armaActual;
    }
}
