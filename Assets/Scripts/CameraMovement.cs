using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private float _distance;
    public Transform CharacterTransform;

    private void Start()
    {
        _distance = transform.position.z - CharacterTransform.position.z;
    }


    private void LateUpdate()
    {
        transform.position =
             new  Vector3(transform.position.x, transform.position.y ,CharacterTransform.position.z+_distance);
    }
}
