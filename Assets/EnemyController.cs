using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    private MeshRenderer meshRenderer;
    private Material carMaterial;
    public static Action<EnemyController> OnOutOfBounds;

    private void Awake()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        carMaterial = new Material(meshRenderer.material);
        meshRenderer.material = carMaterial;
    }
    void Update()
    {
        transform.position += speed * Time.deltaTime * Vector3.back;   
        if(transform.position.z < -15)
        {
            OnOutOfBounds?.Invoke(this);
            
        }
    }

    public void SetColor(Color color)
    {
        carMaterial.color = color;
    }
}
