using UnityEngine;
using System.Collections;

public class ThreeAAPlanesCuttingController : MonoBehaviour {

    public GameObject planeYZ;
    public GameObject planeXZ;
    public GameObject planeXY;
    Material mat;
    public Vector3 positionYZ;
    public Vector3 positionXZ;
    public Vector3 positionXY;
    public Renderer rend;
    // Use this for initialization
    void Start()
    {
        rend = GetComponent<Renderer>();
        UpdateShaderProperties();
    }
    void Update()
    {
        UpdateShaderProperties();
    }

    private void UpdateShaderProperties()
    {
        positionYZ = planeYZ.transform.position;
        positionXZ = planeXZ.transform.position;
        positionXY = planeXY.transform.position;
        for (int i = 0; i < rend.materials.Length; i++)
        {
            if (rend.materials[i].shader.name == "CrossSection/ThreeAAPlanesBSP")
            {
                rend.materials[i].SetVector("_Plane1Position", positionYZ);
                rend.materials[i].SetVector("_Plane2Position", positionXZ);
                rend.materials[i].SetVector("_Plane3Position", positionXY);
            }
        }
      
    }
}
