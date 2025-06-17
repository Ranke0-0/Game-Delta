using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueTest : MonoBehaviour
{

    #region VARIABLES
    [Header("Dialogue Test Variables")]
    [SerializeField, TextArea(2, 4 )] private string[] dialogueLines;
    private bool isPlayerInRange;
    private bool didDialogueStart = false; // Variable para controlar si el diálogo está activo o no.
    private int lineIndex = 0; // Índice de la línea de diálogo actual. 
    private float typingTime = 0.05f;
    public PlayerControllerSimple playerController; // Referencia al controlador del jugador, si es necesario para otras interacciones.

    [Space]

    [Header("Dialogue Test References")]
    [SerializeField] private GameObject dialogueMark; // Referencia al objeto visual que se mostrará al jugador cuando esté en rango.
    [SerializeField] private GameObject dialoguePanel; // Referencia al panel de diálogo que se mostrará al jugador.
    [SerializeField] private TMP_Text dialogueText; // Referencia al cuadro de diálogo que se mostrará al jugador.

    #endregion

    #region METHODS

    // Update is called once per frame. Used to see what the player does each frame.
    void Update()
    {
        if(isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            if (!didDialogueStart)
            {
                StartDialogue();
            }
            else if (dialogueText.text == dialogueLines[lineIndex])
            {
                NextDialogueLine(); // Si el diálogo ya ha comenzado y la línea actual está completa, muestra la siguiente línea.
            }
            else
            {
                StopAllCoroutines(); // Si el jugador presiona F antes de que termine la línea actual, detiene la corrutina de escritura.
                dialogueText.text = dialogueLines[lineIndex]; // Muestra la línea completa inmediatamente.
            }
        }
    }

    private void StartDialogue()
    {
        didDialogueStart = true;
        dialoguePanel.SetActive(true); // Activa el panel de diálogo.
        dialogueMark.SetActive(false); // Desactiva el objeto visual de entrada.
        lineIndex = 0; // Reinicia el índice de la línea de diálogo actual.
        StartCoroutine(ShowLine()); // Inicia la corrutina para mostrar la primera línea de diálogo.
        //Time.timeScale = 0f; // Pausa el juego para que el jugador pueda leer el diálogo sin distracciones.
        playerController.enabled = false; // Desactiva el controlador del jugador para evitar movimientos durante el diálogo.

    }

    private void NextDialogueLine()
    {
        lineIndex++; // Incrementa el índice de la línea de diálogo actual.
        if (lineIndex < dialogueLines.Length)
        {
            StartCoroutine(ShowLine()); // Muestra la siguiente línea de diálogo.
        }
        else
        {
            didDialogueStart = false; // Resetea la variable de control del diálogo.
            dialoguePanel.SetActive(false);
            dialogueMark.SetActive(true); // Reactiva el objeto visual de entrada.
            //Time.timeScale = 1f; // Reanuda el juego una vez que se han mostrado todas las líneas de diálogo.
            playerController.enabled = true; // Reactiva el controlador del jugador para que pueda moverse nuevamente.
        }
    }

    private IEnumerator ShowLine()
    {
        dialogueText.text = string.Empty;

        foreach(char ch in dialogueLines[lineIndex])
        {
            dialogueText.text += ch; // Muestra cada carácter uno por uno.
            yield return new WaitForSecondsRealtime(typingTime); // Espera un poco antes de mostrar el siguiente carácter.
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = true;
            dialogueMark.SetActive(true); // Activa el objeto visual para indicar que el jugador está en rango.
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            dialogueMark.SetActive(false); // Desactiva el objeto visual para indicar que el jugador ya no está en rango.
        }
    }
    #endregion

}
