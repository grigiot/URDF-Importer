using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity.Robotics.UrdfImporter
{
    public class UrdfSensors : MonoBehaviour
    {
        /// <summary>
        /// This function calls all `UrdfSensor.Create` function one by
        /// one and puts a camera or a Ray object in the robot gameobject
        /// </summary>
        /// <param name="robot"></param>
        /// <param name="sensors"></param>
        public static void Create(Transform robot, List<Sensor> sensors = null)
        {
            if (sensors == null) return;

            foreach (var sensor in sensors)
            {
                // UrdfSensor.Create(robot, sensor);
            }
        }
    }
}