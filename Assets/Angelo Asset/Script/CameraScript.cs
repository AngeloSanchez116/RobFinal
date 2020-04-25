using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform camPositionOnStart;

    public float mouseSensitivity = 100;
    public float xRotataion = 0f;

    private GameObject player;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotataion -= mouseY;
        xRotataion = Mathf.Clamp(xRotataion, -90f , 90f);

        transform.localRotation = Quaternion.Euler(xRotataion, 0f, 0f);
        player.transform.Rotate(Vector3.up * mouseX);
    }
}
