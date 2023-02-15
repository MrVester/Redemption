using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float movingSpeed=5f;
    [SerializeField] private BoxCollider2D camBorders;
    private BoxCollider2D cameraBox;
    private float leftborder;
    private float rightborder;
    private float botborder;
    private float topborder;

    float leftPivot;
    float rightPivot;
    float botPivot;
    float topPivot;
   



    private void Start()
    {
        leftborder = camBorders.bounds.min.x;
        rightborder = camBorders.bounds.max.x;
        botborder = camBorders.bounds.min.y;
        topborder = camBorders.bounds.max.y;

        cameraBox = GetComponent<BoxCollider2D>();
        leftPivot = camBorders.bounds.min.x + cameraBox.size.x / 2;
        rightPivot = camBorders.bounds.max.x - cameraBox.size.x / 2;
        botPivot = camBorders.bounds.min.y + cameraBox.size.y / 2;
        topPivot = camBorders.bounds.max.y - cameraBox.size.y / 2;
        

        
        
    }
    private void Update()
    {
        Follow();
    }
    void Follow()
    {
        Vector3 targetPosition = playerTransform.position;
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, leftPivot, rightPivot),
            Mathf.Clamp(targetPosition.y, botPivot, topPivot  ),
            Camera.main.transform.position.z);

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, movingSpeed * Time.fixedDeltaTime);
        transform.position = smoothPosition;
        
    }
}
