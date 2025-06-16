using System.Collections;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{

    #region VARIABLES

    [Header("Parte 1")]
    [Range(0f, 10f)]
    [Tooltip("This is a test float variable.")]
    [SerializeField] private float testfloat = 5f;
    
    [Space]
    
    [Header("Parte 2")]
    [Tooltip("This is another test, but with an int variable.")]
    [SerializeField] private int testint = 10;
    #endregion
    
    #region METHODS
    // Awake is called once before Start when the script instance is being initialized. Used to set up references.
    void Awake()
    {
        
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created.
    void Start()
    {
        
    }
    
    // Update is called once per frame. Used to see what the player does each frame.
    void Update()
    {
        
    }
    
    // FixedUpdate is called at fixed intervals, independently of the frame rate. Used for physics related calculations.
    void FixedUpdate()
    {
        
    }
    
    // LateUpdate is called once per frame, but after all Update functions have completed.
    void LateUpdate()
    {
            
    }
    
    IEnumerator MiCorrutina()
    {
        Debug.Log("Inicio de la corrutina");
        
        yield return new WaitForSeconds(2f); // Espera 2 segundos
        
        Debug.Log("Después de la espera");
    
        yield return null; // Espera hasta el siguiente frame
    
        Debug.Log("Final de la corrutina");
    }
    #endregion

}
