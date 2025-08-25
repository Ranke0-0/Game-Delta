using System.Collections;
using UnityEngine;

public class ControladorPuntos : MonoBehaviour
{

    #region VARIABLES

    public static ControladorPuntos Instance;
    public int cantidadPuntos;

    #endregion
    
    #region METHODS
    // Awake is called once before Start when the script instance is being initialized. Used to set up references.
    void Awake()
    {
        if (ControladorPuntos.Instance == null)
        {
            ControladorPuntos.Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int puntos)
    {
        cantidadPuntos += puntos;
    }

    #endregion

}
