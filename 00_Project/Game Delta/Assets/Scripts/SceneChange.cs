using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public string scene;

    public void OnTriggerEnter2D(Collider2D other)  // Permite detectar cuando un objeto ha entrado en tu área definida
    {
        Debug.Log("Another collider with name " + other.gameObject.name + " HAS ENTERED in my area");
        ChangeScene();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(scene);
    }
}