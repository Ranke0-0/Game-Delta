using System.Collections;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    #region VARIABLES

    //[SerializeField] private GameObject efecto;
    [SerializeField] private float cantidadPuntos;

    #endregion

    #region METHODS

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            ControladorPuntos.Instance.SumarPuntos(cantidadPuntos);
            //Instantiate(efecto, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    #endregion

}
