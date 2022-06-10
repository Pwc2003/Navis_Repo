/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using CodeMonkey.MonoBehaviours;
using GridPathfindingSystem;

public class GameHandler_Setup : MonoBehaviour {

    public static GridPathfinding gridPathfinding;

    [SerializeField] private CameraFollow cameraFollow = null;
    [SerializeField] private float cameraZoom = 50f;
    [SerializeField] private Transform followTransform = null;
    [SerializeField] private bool cameraPositionWithMouse = true;


    private void Start() {
        //Sound_Manager.Init();
        cameraFollow.Setup(GetCameraPosition, () => cameraZoom == -1 ? 60f : cameraZoom, true, true);

        //FunctionPeriodic.Create(SpawnEnemy, 1.5f);
        //for (int i = 0; i < 1000; i++) SpawnEnemy();
        
        gridPathfinding = new GridPathfinding(new Vector3(-400, -400), new Vector3(400, 400), 5f);
        gridPathfinding.RaycastWalkable();
    }

   

   
    private Vector3 GetCameraPosition() {
        if (followTransform == null) {
            return cameraFollow.transform.position;
        }

        if (cameraPositionWithMouse) {
            Vector3 mousePosition = UtilsClass.GetMouseWorldPosition();
            Vector3 playerToMouseDirection = mousePosition - followTransform.position;
            return followTransform.position + playerToMouseDirection * .3f;
        } else {
            return followTransform.position;
        }
    }
}
