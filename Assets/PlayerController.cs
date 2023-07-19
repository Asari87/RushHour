using System.Collections;
using System.Collections.Generic;

using UnityEditor.Rendering;

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    void Update()
    {
        float input = Input.GetAxis("Horizontal");
        transform.position += input * speed * Time.deltaTime * Vector3.right;
    }
}
