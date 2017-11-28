using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_RunRayCast : MonoBehaviour
{
    string hitTag;
    private GameObject objectHit;

    public GameObject RayStart;


    public string FindWhatIsAtLocation(Vector3 location)
    {
        GameObject newRayStart = Instantiate(RayStart, new Vector3(location.x, 10, location.z), Quaternion.identity);
        Vector3 rayBegin = newRayStart.transform.position;
        Vector3 rayEnd = new Vector3(location.x, -1000, location.z);
        RaycastHit hit;

        Debug.Log(location);

        if (Physics.Raycast(rayBegin, rayEnd, out hit, 10))
        {
            hitTag = hit.transform.gameObject.tag;
            Debug.DrawRay(rayBegin, rayEnd, Color.red, 100);
            Destroy(newRayStart);
        }
        return hitTag;
    }

    public GameObject FindWhatIsAtCursorLocation()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100))
        {
            objectHit = hit.transform.gameObject;
        }
        return objectHit;
    }
}
