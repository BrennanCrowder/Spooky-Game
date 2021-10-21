using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMoveScript : MonoBehaviour
{
        public bool move = true;
        // The plane the object is currently being dragged on
        private Plane dragPlane;

        // The difference between where the mouse is on the drag plane and 
        // where the origin of the object is on the drag plane
        private Vector3 offset;

        private Camera myMainCamera;

        void Start()
        {
            myMainCamera = Camera.main; // Camera.main is expensive ; cache it here
        }

        void OnMouseDown()
        {
            if (!move) { return; }
            dragPlane = new Plane(myMainCamera.transform.forward, transform.position);
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
        }

        void OnMouseDrag()
        {
            if (!move) { return; }
            Ray camRay = myMainCamera.ScreenPointToRay(Input.mousePosition);

            float planeDist;
            dragPlane.Raycast(camRay, out planeDist);
            transform.position = camRay.GetPoint(planeDist) + offset;
        }
}


