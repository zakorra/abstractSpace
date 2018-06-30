using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class _RTSCamera : MonoBehaviour {
 
    [Header("Camera Movement")]
    public int MovementSpeed = 1;
    [Header("Zoom")]
    [Tooltip("Start distance of the camera!")]
    public int ZoomSize = 35;
    public int MinZoomSize = 20;
    public int MaxZoomSize = 40;
    [Header("Boundaries")]
    [Tooltip("Turn Boundaries on or off!")]
    public bool LimitMap = true;
    public float LimitX = 50f;
    public float LimitY = 50f;
    [Header("Camera Start Position")]
    [Tooltip("Cordinates of the start position of the camera!")]
    public Vector2 CameraStartPos;
    
    private int _nearCpNear = 0;  
    private Transform _transform;
    
    private void Start()
    {
        GetComponent<Camera>().nearClipPlane = _nearCpNear;
        _transform = transform; 
        transform.position = new Vector2(CameraStartPos.x, CameraStartPos.y);
    }

    void Update()
    {
        Movement();
        Zoom();
        LimitPosition();
        
    }

    private void Movement()
    {
        float xAxisValue = Input.GetAxis("Horizontal") * MovementSpeed;
        float yAxisValue = Input.GetAxis("Vertical") * MovementSpeed;
 
        transform.position = new Vector2(transform.position.x + xAxisValue, transform.position.y + yAxisValue);
    }

    private void Zoom()
    {
        GetComponent<Camera>().orthographicSize = ZoomSize;
        
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (ZoomSize > MinZoomSize)
                ZoomSize -= 1;
        }
        
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (ZoomSize < MaxZoomSize)
                ZoomSize += 1;
        }
    }

    private void LimitPosition()
    {
        if (!LimitMap)
            return;
                
        _transform.position = new Vector2(Mathf.Clamp(_transform.position.x, -LimitX, LimitX),
            Mathf.Clamp(_transform.position.y, -LimitY, LimitY));
    }
}
