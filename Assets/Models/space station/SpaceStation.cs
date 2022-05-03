using System.Collections;
using UnityEngine;


public class SpaceStation : MonoBehaviour
{

	public Transform TargetTransform;
	public Transform StationTransform;
    public SphereCollider PlanetCollider;

    private Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius;
    public float radiusSpeed = 10.5f;
    public float rotationSpeed = 40.3f;

    void Start()
    {
        center = TargetTransform;


        float radius = PlanetCollider.radius * Mathf.Max(TargetTransform.lossyScale.x, TargetTransform.lossyScale.y, TargetTransform.lossyScale.z) + 100;

        transform.position = (transform.position - center.position).normalized * radius + center.position;



    }

    void FixedUpdate()
    {
        transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
    }
}
