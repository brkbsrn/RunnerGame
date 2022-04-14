using System;
using System.Collections.Generic;
using UnityEngine;

public class MeshColors : MonoBehaviour
{
    public MeshFilter mf;
    public float radius = .3f;
    public Color PaintColor;
    private Camera mainCamera;
    public LayerMask LayerMask;

    private void Awake()
    {
        mainCamera = Camera.main;
        ResetColors();
    }

    public void ResetColors()
    {
        Color[] colors = new Color[mf.mesh.vertexCount];
        for (int i = 0; i < colors.Length; i++)
        {
            colors[i] = Color.white;
        }
        mf.mesh.colors = colors;

        mf.mesh.RecalculateBounds();
        mf.mesh.RecalculateNormals();
        mf.mesh.RecalculateTangents();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 50f, LayerMask))
            {
                Paint(hit.point);
            }
        }
    }

    private void Paint(Vector3 worldPos)
    {
        Vector3 localPos = transform.InverseTransformPoint(worldPos);
        Color[] colors = mf.mesh.colors;
        Vector3[] vertices = mf.mesh.vertices;
        for (int i = 0; i < vertices.Length; i++)
        {
            if (Vector3.Distance(vertices[i], localPos) < radius)
            {
                colors[i] = PaintColor;
            }
        }

        mf.mesh.colors = colors;

        mf.mesh.RecalculateBounds();
        mf.mesh.RecalculateNormals();
        mf.mesh.RecalculateTangents();
    }
}
