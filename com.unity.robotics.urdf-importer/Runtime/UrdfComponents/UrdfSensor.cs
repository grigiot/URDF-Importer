using UnityEngine;

namespace Unity.Robotics.UrdfImporter
{
    public class UrdfSensor : MonoBehaviour
    {
        public static void Create(GameObject linkGameObject, Sensor sensor)
        {
            var go = new GameObject(sensor.name);
            go.AddComponent<UrdfSensor>();
            go.transform.SetParent(linkGameObject.transform);
            go.transform.position = Vector3.zero;

            if (sensor.camera != null)
            {
                Camera camera = go.AddComponent<Camera>();

                camera.transform.position = Vector3.zero;

                camera.farClipPlane = sensor.camera.far;

                var aspect = (float) sensor.camera.width/sensor.camera.height;

                var vfov_radians = 2f * Mathf.Atan(Mathf.Tan(sensor.camera.hfov/2f) / aspect);

                camera.fieldOfView = vfov_radians * Mathf.Rad2Deg;
                
                camera.aspect = aspect;
                
                camera.enabled = false;
            }
            if (sensor.ray != null)
            {
                // TODO: Ray still needs to be implemented
            }
        }
    }

}