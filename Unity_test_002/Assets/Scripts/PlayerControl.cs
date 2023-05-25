using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController characterController;
    public float moveSpeed = 5f;
    public float mouseSpeed = 1.0f;

    private float mouseVertical = 0;
    private float mouseHorizontal = 0;
    private float mouseScroll = 0;

    void Start()
    {
        // characterController = GetComponent <characterController>();
    }

    void Update()
    {
        mouseHorizontal += Input.GetAxis("Mouse X") * mouseSpeed;
        mouseVertical += Input.GetAxis("Mouse Y") * mouseSpeed * -1;
        mouseScroll += Input.GetAxis("Mouse ScrollWheel") * mouseSpeed * 5;
        Camera.main.transform.localRotation = Quaternion.Euler(mouseVertical, mouseHorizontal, mouseScroll);

        float forwardMove = Input.GetAxis("Vertical");
        float sideMove = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(sideMove, 0, forwardMove);
        characterController.Move(direction * Time.deltaTime * moveSpeed);
    }
}
