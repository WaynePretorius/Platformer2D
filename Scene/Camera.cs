using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        AwakeFunctions();
    }

    private void AwakeFunctions()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        CameraMovement();
    }

    private void CameraMovement()
    {
        Vector2 playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
        transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
    }
}
