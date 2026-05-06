using System;
using System.Xml;
using System.Xml.Linq;


namespace Unity.Robotics.UrdfImporter
{
    public class Sensor
    {
        public string name; // required
        public double updateRate; // optional attribute
        public string parent; // required
        public Origin origin; // optional
        public Camera camera; // optional
        public Ray ray; // optional 

        public Sensor(XElement node)
        {
            name = (string)node.Attribute("name"); // required
            updateRate = node.Attribute("update_rate").ReadOptionalDouble();
            parent = (string)node.Element("parent").Attribute("link"); // required
            origin = (node.Element("origin") != null) ? new Origin(node.Element("origin")) : null;
            camera = (node.Element("camera") != null) ? new Camera(node.Element("camera")) : null;
            ray = (node.Element("ray") != null) ? new Ray(node.Element("ray")) : null;
        }

        public Sensor(string name, double updateRate, string parent,
            Origin origin = null, Camera camera = null, Ray ray = null)
        {
            this.name = name;
            this.updateRate = updateRate;
            this.parent = parent;
            this.origin = origin;
            this.camera = camera;
            this.ray = ray;
        }

        // TODO: Not in my scope right now
        public void WriteToUrdf(XmlWriter writer)
        {
            writer.WriteStartElement("sensor");

            writer.WriteAttributeString("name", name);
            writer.WriteAttributeString("update_rate", ((float)updateRate).ToString());

            // origin?.WriteToUrdf(writer);

            // writer.WriteStartElement("parent");
            // writer.WriteAttributeString("link", parent);
            // writer.WriteEndElement();

            // writer.WriteStartElement("child");
            // writer.WriteAttributeString("link", child);
            // writer.WriteEndElement();

            // axis?.WriteToUrdf(writer);
            // calibration?.WriteToUrdf(writer);
            // dynamics?.WriteToUrdf(writer);
            // limit?.WriteToUrdf(writer);
            // mimic?.WriteToUrdf(writer);
            // safetyController?.WriteToUrdf(writer);

            writer.WriteEndElement();
        }

        public class Camera
        {
            public uint width; // pixels
            public uint height; // pixels
            public string format; // TODO: uncertain about what are the encodings
            public double hfov; // radians
            public double near; // m
            public double far; // m

            public Camera(XElement node)
            {
                var image = node.Element("image"); // required
                if (image == null)
                {
                    width = 0;
                    height = 0;
                    format = "";
                    hfov = double.NaN;
                    near = double.NaN;
                    far = double.NaN;
                }
                width = (uint)image.Attribute("width");
                height = (uint)image.Attribute("height");
                format = (string)image.Attribute("format");
                hfov = (double)image.Attribute("hfov");
                near = (double)image.Attribute("near");
                far = (double)image.Attribute("far");
            }

            public Camera(uint width, uint height, string format, double hfov, double near, double far)
            {
                this.width = width;
                this.height = height;
                this.format = format;
                this.hfov = hfov;
                this.near = near;
                this.far = far;
            }
        }
        
        public class Ray
        {
            // TODO: implement if you want the lidar
            public Ray(XElement node)
            {

            }
        }
    }
}