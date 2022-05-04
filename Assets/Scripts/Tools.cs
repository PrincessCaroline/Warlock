using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tools : MonoBehaviour
{
    /// <summary>
    /// Return the position of the clic
    /// </summary>
    /// <param name="position"></param>
    /// <returns></returns>
    static public Vector3 GetMousePosition()
    {
        Vector3 position = Vector3.zero;

        MeshFilter PlaneTransform = GameObject.Find("Ground").GetComponent<MeshFilter>();

        Plane plane = new Plane(PlaneTransform.transform.position, PlaneTransform.transform.position + PlaneTransform.transform.forward, PlaneTransform.transform.position + PlaneTransform.transform.right);

        float distance;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            position = ray.GetPoint(distance);
        }

        return position;
    }
}
