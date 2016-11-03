using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class OnePlaneCuttingController : MonoBehaviour {

    public GameObject plane;
    Material mat;
    public Vector3 normal;
    public Vector3 position;
    public Renderer rend;
    // Use this for initialization
    void Start () {
        rend = GetComponent<Renderer>();
        normal = plane.transform.TransformVector(new Vector3(0,0,-1));
        position = plane.transform.position;
        UpdateShaderProperties();
    }
    void Update ()
    {
        UpdateShaderProperties();
    }

    private void UpdateShaderProperties()
    {

        normal = plane.transform.TransformVector(new Vector3(0, 0, -1));
        position = plane.transform.position;
        for(int i=0;i<rend.materials.Length;i++)
        {
            if(rend.materials[i].shader.name== "CrossSection/OnePlaneBSP")
            {
                rend.materials[i].SetVector("_PlaneNormal", normal);
                rend.materials[i].SetVector("_PlanePosition", position);
            }
        }
        
    }
}
