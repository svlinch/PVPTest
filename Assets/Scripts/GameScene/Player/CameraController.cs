using UnityEngine;
using Mirror;

namespace GameScene
{
    public class CameraController : NetworkBehaviour
    {
        public override void OnStartLocalPlayer()
        {
            var camera = Camera.main;
            camera.orthographic = false;
            camera.transform.SetParent(transform);
            camera.transform.localPosition = new Vector3(0f, 2f, -6f);
            camera.transform.localEulerAngles = new Vector3(10f, 0f, 0f);
        }
    }
}