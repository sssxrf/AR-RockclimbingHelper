using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;

namespace UnityEngine.XR.ARFoundation.Samples
{
    /// <summary>
    /// Launches projectiles from a touch point with the specified <see cref="initialSpeed"/>.
    /// </summary>
    ///
    

    [RequireComponent(typeof(Camera))]
    public class IndicatorLauncher : PressInputBase
    {
        

        void Start()
        {
            
        }
        [SerializeField]
        GameObject Indicator;

        [SerializeField]
        private LayerMask layersToInclude;




        protected override void OnPressBegan(Vector3 position)
        {
            if (Indicator == null)
                return;

            var ray = GetComponent<Camera>().ScreenPointToRay(position);

            var hasHit = Physics.Raycast(ray, out var hit, float.PositiveInfinity, layersToInclude);

            if (hasHit)
            {
                Quaternion newObjectRotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                GameObject newObject = GameObject.Instantiate(Indicator, hit.point, newObjectRotation);
                newObject.gameObject.layer = LayerMask.NameToLayer("ignore Raycast");
            }

        }
    }
}
