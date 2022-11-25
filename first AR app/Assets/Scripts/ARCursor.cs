using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;



[RequireComponent(typeof(ARRaycastManager))]
public class ARCursor : MonoBehaviour
{
    public GameObject ObjectToInstanciate;

    private GameObject spawnedObject;
    private ARRaycastManager raycastManager;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool tryGetTouchPosition(out Vector2 touchPosition)
    {
        if(Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(index: 0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }

    void Update()
    {
        if (!tryGetTouchPosition(out Vector2 touchPosition))
            return;
        if(raycastManager.Raycast(touchPosition, hits, trackableTypes: TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;
            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(ObjectToInstanciate, touchPosition, ObjectToInstanciate.transform.rotation);
                spawnedObject.transform.position = hitPose.position;
                FindObjectOfType<Gaze>().UpdateInfosAndPanelsList();
            }
        }
    }
}
