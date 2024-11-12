using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float mouseSensitivity = 100f; // Sensibilit� de la souris
    public Transform playerBody; // R�f�rence au corps du joueur

    private float xRotation = 0f; // Rotation sur l'axe X (pour la cam�ra si vous g�rez aussi le pitch)
    private float yRotation = 0f; // Rotation sur l'axe Y (pour le joueur)

    void Start()
    {
        // Verrouiller le curseur de la souris au centre de l'�cran
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Obtenez les mouvements de la souris sur les axes X et Y
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Faites tourner le joueur autour de l'axe Y
        yRotation += mouseX;

        // Appliquez la rotation du joueur autour de l'axe Y
        playerBody.rotation = Quaternion.Euler(0f, yRotation, 0f);

        // Optionnel : Limiter la rotation de la cam�ra pour l'axe X (regarder en haut/bas)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limite � -90 � 90 degr�s pour �viter une rotation compl�te

        // Appliquez la rotation � la cam�ra (Cinemachine s'occupe de la cam�ra si vous l'avez configur�e)
        Camera.main.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
