using UnityEngine;

public class MeshUnwrapper : MonoBehaviour
{
    [ContextMenu("Unwrap Mesh (no shared vertices)")]
    void Unwrap()
    {
        MeshFilter mf = GetComponent<MeshFilter>();
        if (mf == null) return;

        Mesh mesh = mf.sharedMesh;
        if (mesh == null) return;

        Vector3[] oldVerts = mesh.vertices;
        Vector3[] oldNormals = mesh.normals;
        Vector2[] oldUV = mesh.uv;
        int[] oldTris = mesh.triangles;

        Vector3[] newVerts = new Vector3[oldTris.Length];
        Vector3[] newNormals = new Vector3[oldTris.Length];
        Vector2[] newUV = new Vector2[oldTris.Length];
        int[] newTris = new int[oldTris.Length];

        for (int i = 0; i < oldTris.Length; i++)
        {
            newVerts[i] = oldVerts[oldTris[i]];
            if (oldNormals.Length > 0) newNormals[i] = oldNormals[oldTris[i]];
            if (oldUV.Length > 0) newUV[i] = oldUV[oldTris[i]];
            newTris[i] = i;
        }

        Mesh newMesh = new Mesh();
        newMesh.vertices = newVerts;
        if (oldNormals.Length > 0) newMesh.normals = newNormals;
        if (oldUV.Length > 0) newMesh.uv = newUV;
        newMesh.triangles = newTris;

        mf.mesh = newMesh;

        Debug.Log("Mesh unwrapped: no shared vertices.");
    }
}
