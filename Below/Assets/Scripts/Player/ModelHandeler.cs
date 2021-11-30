using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelHandeler : MonoBehaviour
{
    [SerializeField] private Transform targetRotationTransform;
    [SerializeField] private float speed;

    private void Update() {
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationTransform.rotation, Time.deltaTime * speed);
    }
}
