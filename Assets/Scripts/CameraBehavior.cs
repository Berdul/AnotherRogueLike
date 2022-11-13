using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public float offsetDivider;

    void Update() {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 pointingDirection = (mousePos - PlayerManager.instance.GetPlayerPosition()).normalized;
        float mouseDistanceFromPlayer = (mousePos - PlayerManager.instance.GetPlayerPosition()).magnitude;

        Vector2 camPos = PlayerManager.instance.GetPlayerPosition() + pointingDirection * mouseDistanceFromPlayer / offsetDivider ;
        transform.position = new Vector3(camPos.x, camPos.y, transform.position.z);
    }
}
