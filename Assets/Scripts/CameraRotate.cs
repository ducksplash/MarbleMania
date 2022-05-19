using UnityEngine;



[RequireComponent(typeof(Camera))]
public class CameraRotate : MonoBehaviour
{

    private float horizontalMove = 0.0f;

    public GameObject ThisCamera;

    [SerializeField] Transform focus = default;
    [SerializeField, Range(1f, 20f)] float distance = 5f;
    [SerializeField, Min(0f)] float focusRadius = 1f;
    [SerializeField, Range(0f, 1f)] float focusCentering = 0.5f;
    Vector2 orbitAngles = new Vector2(45f, 0f);
    [SerializeField, Range(-89f, 89f)] float minVerticalAngle = -30f, maxVerticalAngle = 60f;

    Vector3 focusPoint, previousFocusPoint;
    float lastManualRotationTime;



    void OnValidate()
    {
        if (maxVerticalAngle < minVerticalAngle)
        {
            maxVerticalAngle = minVerticalAngle;
        }
    }

    void Awake()
    {


        focusPoint = focus.position;
        ThisCamera.transform.localRotation = Quaternion.Euler(orbitAngles);



    }





    void LateUpdate()
    {


        UpdateFocusPoint();
        Quaternion lookRotation;

        if (ManualRotation())
        {
            ConstrainAngles();
            lookRotation = Quaternion.Euler(orbitAngles);
        }
        else
        {
            lookRotation = ThisCamera.transform.localRotation;
        }
        Vector3 lookDirection = lookRotation * Vector3.forward;
        Vector3 lookPosition = focusPoint - lookDirection * distance;
        ThisCamera.transform.SetPositionAndRotation(lookPosition, lookRotation);




    }

    bool ManualRotation()
    {

        if (!PlayerStats.GamePaused)
        {

            if (Input.GetKey(PlayerStats.InputForLEFT) || Input.GetKey(PlayerStats.InputForRIGHT) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                horizontalMove = Input.GetAxis("Horizontal");
            }
            else
            {
                horizontalMove = Input.GetAxis("Mouse X");
            }


            Vector2 input = new Vector2(0, 0);

            input = new Vector2(
                -Input.GetAxis("Mouse Y"),
                horizontalMove
            );

            const float e = 0.001f;
            if (input.x < -e || input.x > e || input.y < -e || input.y > e)
            {
                orbitAngles += PlayerStats.CameraSpeed * Time.smoothDeltaTime * input;
                lastManualRotationTime = Time.smoothDeltaTime;
                return true;
            }
            return false;
        }
        else
        {
            return false;
        }
    }


    void UpdateFocusPoint()
    {
        previousFocusPoint = focusPoint;
        Vector3 targetPoint = focus.position;
        if (focusRadius > 0f)
        {
            float distance = Vector3.Distance(targetPoint, focusPoint);
            if (distance > focusRadius)
            {
                focusPoint = Vector3.Lerp(
                    targetPoint, focusPoint, focusRadius / distance
                );
            }
            if (distance > 0.01f && focusCentering > 0f)
            {
                focusPoint = Vector3.Lerp(
                    targetPoint, focusPoint,
                    Mathf.Pow(0.5f - focusCentering, Time.smoothDeltaTime)
                );
            }
        }
        else
        {
            focusPoint = targetPoint;
        }
    }

    void ConstrainAngles()
    {
        orbitAngles.x =
            Mathf.Clamp(orbitAngles.x, minVerticalAngle, maxVerticalAngle);

        if (orbitAngles.y < 0f)
        {
            orbitAngles.y += 360f;
        }
        else if (orbitAngles.y >= 360f)
        {
            orbitAngles.y -= 360f;
        }
    }

    static float GetAngle(Vector2 direction)
    {
        float angle = Mathf.Acos(direction.y) * Mathf.Rad2Deg;
        return direction.x < 0f ? 360f - angle : angle;
    }
}