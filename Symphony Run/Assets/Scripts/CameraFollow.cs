/**
* Created by: Emerson Navarro
* 05/10/2019
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    [SerializeField]
    private GameObject player;

    private float deltaX;
    private float cameraPostionY;
    private float cameraPositionZ;

    [SerializeField]
    private float deltaY; //buffer area where user can move and camera no changes.

    // Start is called before the first frame update
    private void Start()
    {
        // Define the position of the camera programatically
        deltaX = Mathf.Abs(player.transform.position.x - transform.position.x);
        cameraPostionY = transform.position.y;
        cameraPositionZ = transform.position.z;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(player != null)
        {
            SetCameraYPosition();
            SetCameraXPosition();
        }

    }

    private void SetCameraXPosition()
    {
        transform.position = new Vector3(player.transform.position.x + deltaX, cameraPostionY, cameraPositionZ);
    }

    private void SetCameraYPosition()
    {
        if(player.transform.position.y <transform.position.y - deltaY)
        {
            cameraPostionY = player.transform.position.y + deltaY;
        }
        else if (player.transform.position.y > transform.position.y + deltaY)
        {
            cameraPostionY = player.transform.position.y - deltaY;
        }
    }

}
