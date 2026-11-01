
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Transform player1;

    public float smoothSpeed = 5f;

    public float minZoom = 8f;
    public float padding = 1.5f;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null || player1 == null || cam == null)
            return;

        // Намираме средната позиция между двамата играчи
        Vector3 middle = (player.position + player1.position) / 2f;

        Vector3 targetPos = new Vector3(
            middle.x,
            middle.y,
            transform.position.z
        );

        transform.position = Vector3.Lerp(
            transform.position,
            targetPos,
            smoothSpeed * Time.deltaTime
        );

        // Разстоянието между играчите по двете оси
        float distanceX = Mathf.Abs(
            player.position.x - player1.position.x
        );

        float distanceY = Mathf.Abs(
            player.position.y - player1.position.y
        );

        // Изчисляваме необходимия зум според размера на екрана
        float requiredHeight = distanceY / 2f + padding;
        float requiredWidth = distanceX / (2f * cam.aspect) + padding;

        float targetZoom = Mathf.Max(
            minZoom,
            requiredHeight,
            requiredWidth
        );

        // Плавна промяна на зума
        cam.orthographicSize = Mathf.Lerp(
            cam.orthographicSize,
            targetZoom,
            smoothSpeed * Time.deltaTime
        );
    }
}
