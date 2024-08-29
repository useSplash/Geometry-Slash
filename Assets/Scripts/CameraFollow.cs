using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
        public Vector3 offset;
        [SerializeField] private Transform target;
        [SerializeField] private float smoothTime;
    
        [SerializeField] private float zoomSize;
        [SerializeField] private float smoothZoomTime;

        private void LateUpdate()
        {
            Vector3 targetPosition = target.position + offset;
            transform.position = Vector3.Slerp(transform.position, targetPosition, smoothTime);

            this.GetComponent<Camera>().fieldOfView 
                                        = Mathf.Lerp(this.GetComponent<Camera>().fieldOfView,
                                            zoomSize,
                                            smoothZoomTime);
        }
        
        public void ChangeZoom(float newValue){
            zoomSize = newValue;
        }
}
