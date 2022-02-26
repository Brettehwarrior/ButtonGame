using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class ButtonMeshUpdater : MonoBehaviour
{
    private MeshFilter _meshFilter;
    [SerializeField] private Mesh initialMesh;
    [SerializeField] private Mesh pressedMesh;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
    }

    public void Hold()
    {
        _meshFilter.mesh = pressedMesh;
    }

    public void Release()
    {
        _meshFilter.mesh = initialMesh;
    }
}
