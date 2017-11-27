using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_RunRayCast : MonoBehaviour
{
    string hitTag;
    public GameObject RayStart;
    void Start ()
    {
		
	}

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

}
