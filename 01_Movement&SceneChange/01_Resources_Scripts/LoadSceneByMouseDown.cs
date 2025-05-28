using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneByMouseDown : MonoBehaviour
{
	public string sceneMouseDown;
	
	void Start()
    {
        Debug.Log("Tete que pasa");
    }
    
	public void OnMouseDown()
	{
		if (sceneMouseDown != null)
		{
			Debug.Log("Ahora cambio la Scene");
			SceneManager.LoadScene(sceneMouseDown);
		}
		else 
		{
			Debug.Log("No me diste una Scene");
        }
    }
}