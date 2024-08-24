using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class SlimeInteraction : MonoBehaviour
{
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] originalVertices;

    void Start()
    {
        // Get the MeshFilter component and store the original mesh vertices
        meshFilter = GetComponent<MeshFilter>();
        mesh = meshFilter.mesh;
        originalVertices = mesh.vertices;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hand"))
        {
            Vector3 collisionPoint = collision.contacts[0].point;
            Vector3[] vertices = mesh.vertices;

            // Move vertices based on proximity to the collision point
            for (int i = 0; i < vertices.Length; i++)
            {
                float distance = Vector3.Distance(transform.TransformPoint(vertices[i]), collisionPoint);
                if (distance < 0.5f) // Adjust the radius of effect
                {
                    // Deform the mesh
                    vertices[i] += (collision.impulse.normalized * 0.1f) / distance; 
                }
            }

            // Apply the deformed vertices to the mesh
            mesh.vertices = vertices;
            mesh.RecalculateNormals();
            meshFilter.mesh = mesh;
        }
    }
}
