using GLTF_Generator;
using LinkNavigator.GltfExporter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;






namespace LinkNavigator.Ctr
{
    /// <summary>
    /// Interaction logic for GltfExporterCtr.xaml
    /// </summary>
    public partial class GltfExporterCtr : UserControl
    {
        public GltfExporterCtr()
        {
            InitializeComponent();
        }

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            //get coordinates
            var navisGeometry = new NavisGeometry();
            var cb = navisGeometry.getFragments();

            // create mesh list
            var meshes = new List<Mesh>();
            var rand = new Random();
            int matNameIndex = 1;
            foreach (var callback in cb)
            {
                
                //create Material
                var basecolorFactor = new float[] { (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble() };
                var pbrMetallicRoughness = new pbrMetallicRoughness(basecolorFactor, (float)rand.NextDouble(), (float)rand.NextDouble());
                var material = new Material(pbrMetallicRoughness, true, $"Random Material{matNameIndex}");
                matNameIndex++;


                var coords = callback.Coords;
                var mesheCount = coords.Count / 131004;
                var mesheCountRem = coords.Count % 131004;
                for (int j = 0; j < mesheCount; j++)
                {
                    var triangles = new List<Triangle>();
                    for (int i = 0; i < 131004; i += 9)
                    {
                        var vertex1 = new Vertex(coords[i + (131004 * j)], coords[i + (131004 * j) + 1], coords[i + (131004 * j) + 2]);
                        var vertex2 = new Vertex(coords[i + (131004 * j) + 3], coords[i + (131004 * j) + 4], coords[i + (131004 * j) + 5]);
                        var vertex3 = new Vertex(coords[i + (131004 * j) + 6], coords[i + (131004 * j) + 7], coords[i + (131004 * j) + 8]);
                        var triangle = new Triangle(vertex1, vertex2, vertex3);
                        triangles.Add(triangle);
                    }
                    var mesh = new Mesh(triangles);
                    mesh.Material = material;
                    meshes.Add(mesh);
                }
                var triangles2 = new List<Triangle>();
                for (int i = mesheCount * 131004; i < mesheCount * 131004 + mesheCountRem; i += 9)
                {
                    var vertex1 = new Vertex(coords[i], coords[i + 1], coords[i + 2]);
                    var vertex2 = new Vertex(coords[i + 3], coords[i + 4], coords[i + 5]);
                    var vertex3 = new Vertex(coords[i + 6], coords[i + 7], coords[i + 8]);
                    var triangle = new Triangle(vertex1, vertex2, vertex3);
                    triangles2.Add(triangle);
                }
                var mesh2 = new Mesh(triangles2);
                mesh2.Material = material;
                meshes.Add(mesh2);
            }

            //create a gltf generator
            var gltf = new GltfGenerator();

          

            

            var node = new Node(meshes);
            gltf.Scene.Nodes.Add(node);
            var result = gltf.createGltf();

            File.WriteAllText(@"C:\pdms2.gltf", result);
        }
    }
}


namespace GLTF_Generator
{
    public class GltfGenerator
    {
        public Scene Scene { get; set; }
        private string ScenesValue { get; set; }
        private string NodesValue { get; set; }
        private string MeshesValue { get; set; }
        private string BuffersValue { get; set; }
        private string BufferViewsValue { get; set; }
        private string AccessorsValue { get; set; }
        private string MaterialsValue { get; set; }
        private string AssetValue { get; set; }
        public GltfGenerator()
        {
            ScenesValue = "\"scenes\" : [";
            NodesValue = ",\"nodes\" : [";
            MeshesValue = ",\"meshes\" :[";
            BuffersValue = ",\"buffers\" :[";
            BufferViewsValue = ",\"bufferViews\" :[";
            AccessorsValue = ",\"accessors\" :[";
            MaterialsValue = ",\"materials\" :[";
            AssetValue = ",\"asset\" : {\"version\" : \"2.0\"}";
            CreateScene();
        }
        private void CreateScene()
        {
            Scene = new Scene();
        }
        public string createGltf()
        {
            //Scenes Value
            ScenesValue += getScenesValue(Scene.Nodes);
            ScenesValue += "]";
            // Node Value--->"nodes" : [{"mesh" : 0 }]
            NodesValue += getNodesValue(Scene.Nodes);
            NodesValue += "]";
            // meshes Value --->"meshes" : [ { "primitives" : [ { "attributes" : { "POSITION" : 1  }, "indices" : 0  } ] } ],
            MeshesValue += getMeshValues(Scene.Nodes);
            MeshesValue += "]";
            // buffer value--->"buffers" : [{"uri" : "data:application/gltf-buffer;base64,AAABAAIAAAAAAAAAAAAAAAAAAAAAAAAAAACQQQAAAAAAAGBBAAAAAAAAAAA=","byteLength" : 44}],
            BuffersValue += getBufferValues(Scene.Nodes);
            BuffersValue += "]";
            // bufferview value---->"bufferViews" : [ {"buffer" : 0,"byteOffset" : 0,"byteLength" : 72,"target" : 34963 }, {"buffer" : 0,"byteOffset" : 72,   "byteLength" : 168  }, { "buffer" : 0,"byteOffset" : 240,"byteLength" : 6 }, {"buffer" : 0,"byteOffset" : 248,"byteLength" : 36 } ],
            BufferViewsValue += getBufferViewValue(Scene.Nodes);
            BufferViewsValue += "]";
            //Material Value
            MaterialsValue += getMaterialsValue(Scene.Nodes);
            MaterialsValue += "]";
            // Accessor Value
            AccessorsValue += getAccessorValue(Scene.Nodes);
            AccessorsValue += "]";

            string GltfString = "{";
            GltfString += ScenesValue;
            GltfString += NodesValue;
            GltfString += MeshesValue;
            GltfString += BuffersValue;
            GltfString += BufferViewsValue;
            GltfString += AccessorsValue;
            GltfString += MaterialsValue;
            GltfString += AssetValue;
            GltfString += "}";
            return GltfString;
        }

        private string getMaterialsValue(List<Node> nodes)
        {
            string result = string.Empty;
            int matNameIndex = 1;
            var rand = new Random();
            foreach (var node in nodes)
            {
                if (node.Type == "mesh")
                {
                    foreach (var mesh in node.Meshes)
                    {
                        if (mesh.Material == null)
                        {

                            var basecolorFactor = new float[] { (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble(), (float)rand.NextDouble() };
                            var pbrMetallicRoughness = new pbrMetallicRoughness(basecolorFactor, (float)rand.NextDouble(), (float)rand.NextDouble());
                            var material = new Material(pbrMetallicRoughness, true, $"Random Material{matNameIndex}");
                            mesh.Material = material;
                            matNameIndex++;
                        }
                        result += $"{{\"name\": \"{mesh.Material.Name}\",";
                        result += "\"pbrMetallicRoughness\": {\"baseColorFactor\": [";
                        result += $"{mesh.Material.pbrMetallicRoughness.baseColorFactor[0].ToString().Replace('/', '.')},";
                        result += $"{mesh.Material.pbrMetallicRoughness.baseColorFactor[1].ToString().Replace('/', '.')},";
                        result += $"{mesh.Material.pbrMetallicRoughness.baseColorFactor[2].ToString().Replace('/', '.')},";
                        result += $"{mesh.Material.pbrMetallicRoughness.baseColorFactor[3].ToString().Replace('/', '.')}],";
                        result += $"\"metallicFactor\": {mesh.Material.pbrMetallicRoughness.metallicFactor.ToString().Replace('/', '.')},";
                        result += $"\"roughnessFactor\": {mesh.Material.pbrMetallicRoughness.roughnessFactor.ToString().Replace('/', '.')}";
                        result += " },";
                        result += $"\"doubleSided\": {mesh.Material.DoubleSided.ToString().ToLower()}}},";
                    }

                }
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        private string getScenesValue(List<Node> nodes)
        {
            string result = string.Empty;
            int i = 0;
            result += "{\"nodes\" : [";
            foreach (var node in nodes)
            {
                foreach (var mesh in node.Meshes)
                {
                    result += $"{i++},";
                }
            }
            result = result.Remove(result.Length - 1);
            result += "]}";

            return result;

        }

        private string getAccessorValue(List<Node> nodes)
        {
            string result = string.Empty;
            int bufferViewindex = 0;
            foreach (var node in nodes)
            {
                if (node.Type == "mesh")
                {
                    foreach (var mesh in node.Meshes)
                    {

                        result += "{\"bufferView\" :" + bufferViewindex + ",";
                        result += $"\"byteOffset\" : 0,";
                        result += $"\"componentType\" : { mesh.Buffer.Accessors[0].componentType },";
                        result += $"\"count\" : { mesh.Buffer.Accessors[0].count} ,";
                        result += $" \"type\" : \"{mesh.Buffer.Accessors[0].type}\",";
                        result += $"\"max\" : [{ mesh.Buffer.Accessors[0].max }],";
                        result += $"\"min\" : [{ mesh.Buffer.Accessors[0].min }]" + " },";

                        bufferViewindex++;

                        result += "{\"bufferView\" :" + bufferViewindex + ",";
                        result += $"\"byteOffset\" : 0,";
                        result += $"\"componentType\" : { mesh.Buffer.Accessors[1].componentType },";
                        result += $"\"count\" : {mesh.Buffer.Accessors[1].count / 3} ,";
                        result += $" \"type\" : \"{mesh.Buffer.Accessors[1].type}\",";
                        result += $"\"max\" : { mesh.Buffer.Accessors[1].max },";
                        result += $"\"min\" : { mesh.Buffer.Accessors[1].min }" + " },";
                        bufferViewindex++;
                    }

                }
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        private string getBufferViewValue(List<Node> nodes)
        {
            string result = string.Empty;
            int meshIndex = 0;
            foreach (var node in nodes)
            {
                if (node.Type == "mesh")
                {
                    foreach (var mesh in node.Meshes)
                    {
                        result += "{" + $"\"buffer\" : {meshIndex},";
                        result += $"\"byteOffset\" : 0,\"byteLength\" : {mesh.Buffer.BufferViews[0].byteLength},";
                        result += $"\"target\" : { mesh.Buffer.BufferViews[0].target }" + "},";
                        result += "{" + $"\"buffer\" : { meshIndex} ,";
                        result += $" \"byteOffset\" : {mesh.Buffer.BufferViews[1].byteOffset },";
                        result += $"\"byteLength\" : { mesh.Buffer.BufferViews[1].byteLength }" + " },";
                        meshIndex++;
                    }

                }
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        private string getBufferValues(List<Node> nodes)
        {
            string result = string.Empty;
            foreach (var node in nodes)
            {
                if (node.Type == "mesh")
                {
                    foreach (var mesh in node.Meshes)
                    {
                        //foreach (var buffer in mesh.Buffer)
                        //{
                        result += "{" + $" {mesh.Buffer.URI}\",\"byteLength\" : {mesh.Buffer.byteLength}" + "},";

                        //}
                    }

                }
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        private string getMeshValues(List<Node> nodes)
        {

            string result = string.Empty;
            int i = 0;
            int materialindex = 0;
            foreach (var node in nodes)
            {
                if (node.Type == "mesh")
                {
                    foreach (var mesh in node.Meshes)
                    {
                        result += $"{{ \"primitives\": [ {{ \"attributes\" : {{ \"POSITION\" : { i + 1} }}, \"indices\" : { i } ,\"material\":{materialindex} }} ] }},";
                        materialindex++;
                        i += 2;
                    }

                }
            }
            result = result.Remove(result.Length - 1);
            return result;
        

        }

        private string getNodesValue(List<Node> nodes)
        {
            string result = string.Empty;
            int i = 0;
            foreach (var node in nodes)
            {
                if (node.Type == "mesh")
                {
                    foreach (var mesh in node.Meshes)
                    {
                        result += "{" + $"\"mesh\":{i++}" + "},";
                    }
                }
                else
                {
                    result += $"\"children\":[";
                    foreach (var childNode in node.Nodes)
                    {
                        result += $"{i++},";

                    }
                    result += getNodesValue(node.Nodes);
                }
            }
            result = result.Remove(result.Length - 1);
            return result;
        }

        public static List<Triangle> createCubeRectangles(float l, float h, float d, float x = 0, float y = 0, float z = 0)
        {

            //front
            var tr1 = new Triangle(new Vertex(x, y, z), new Vertex(x + l, y, z), new Vertex(x + l, y + h, z));
            var tr2 = new Triangle(new Vertex(x, y, z), new Vertex(x, y + h, z), new Vertex(x + l, y + h, z));
            //left
            var tr3 = new Triangle(new Vertex(x, y, z), new Vertex(x, y + h, z), new Vertex(x, y + h, z - d));
            var tr4 = new Triangle(new Vertex(x, y, z), new Vertex(x, y, z - d), new Vertex(x, y + h, z - d));
            //right
            var tr5 = new Triangle(new Vertex(x + l, y, z), new Vertex(x + l, y, z - d), new Vertex(x + l, y + h, z - d));
            var tr6 = new Triangle(new Vertex(x + l, y, z), new Vertex(x + l, y + h, z), new Vertex(x + l, y + h, z - d));
            //top
            var tr7 = new Triangle(new Vertex(x, y + h, z), new Vertex(x, y + h, z - d), new Vertex(x + l, y + h, z));
            var tr8 = new Triangle(new Vertex(x + l, y + h, z), new Vertex(x + l, y + h, z - d), new Vertex(x, y + h, z - d));
            //bottom
            var tr9 = new Triangle(new Vertex(x, y, z), new Vertex(x, y, z - d), new Vertex(x + l, y, z));
            var tr10 = new Triangle(new Vertex(x + l, y, z), new Vertex(x + l, y, z - d), new Vertex(x, y, z - d));
            //back
            var tr11 = new Triangle(new Vertex(x, y, z - d), new Vertex(x, y + h, z - d), new Vertex(x + l, y + h, z - d));
            var tr12 = new Triangle(new Vertex(x, y, z - d), new Vertex(x + l, y, z - d), new Vertex(x + l, y + h, z - d));

            var tris = new List<Triangle> { tr1, tr2, tr3, tr4, tr5, tr6, tr7, tr8, tr9, tr10, tr11, tr12 };
            return tris;
        }
    }

    public class Scene
    {
        public List<int> nodesArrayIndexes { get; set; }
        public List<Node> Nodes { get; set; }
        public Scene()
        {
            nodesArrayIndexes = new List<int>();
            Nodes = new List<Node>();
        }

        public override string ToString()
        {
            string indexes = "\"scenes\" : [ { ";
            if (nodesArrayIndexes.Count != 0)
            {
                indexes += "\"nodes\" : [";
                int i = 0;
                foreach (var index in nodesArrayIndexes)
                {
                    indexes += i++;
                }
                indexes += "]";
            }
            indexes += " } ],";
            return indexes;
        }
    }
    public class Node
    {
        public string Type { get; set; }
        public List<Node> Nodes { get; set; }
        public List<Mesh> Meshes { get; set; }
        public Node(List<Mesh> Meshes)
        {
            Type = "mesh";
            this.Meshes = new List<Mesh>();
            this.Meshes = Meshes;
        }
        public Node(Mesh mesh)
        {
            Meshes = new List<Mesh>();
            Meshes.Add(mesh);
            Type = "mesh";
        }
        public Node(List<Node> nodes)
        {
            Nodes = new List<Node>();
            Nodes = nodes;
        }
        public Node(string type = "mesh")
        {
            Meshes = new List<Mesh>();
            Type = type;
        }

    }
    public class Mesh
    {
        public Buffer Buffer { get; set; }
        private List<int> Indices { get; set; }
        private List<float> vertices { get; set; }
        public Material Material { get; set; }
        public List<Triangle> Triangles { get; set; }
        public Mesh(List<Triangle> Triangles)
        {
            this.Triangles = new List<Triangle>();
            this.Triangles = Triangles;

            //Add indices and vertices
            Indices = new List<int>();
            vertices = new List<float>();
            int indice = 0;

            //create buffer, bufferViews and accessors 
            Buffer = new Buffer();
            Buffer.Accessors = new List<Accessor>();
            Buffer.BufferViews = new List<BufferView>();
            var offset = 0;


            //create indices and vertices lists

            foreach (var triangle in Triangles)
            {
                Indices.Add(indice++);
                Indices.Add(indice++);
                Indices.Add(indice++);
                vertices.Add(triangle.Vertex1.X);
                vertices.Add(triangle.Vertex1.Y);
                vertices.Add(triangle.Vertex1.Z);
                vertices.Add(triangle.Vertex2.X);
                vertices.Add(triangle.Vertex2.Y);
                vertices.Add(triangle.Vertex2.Z);
                vertices.Add(triangle.Vertex3.X);
                vertices.Add(triangle.Vertex3.Y);
                vertices.Add(triangle.Vertex3.Z);
            }

            //to get max and min coords
            var verXs = new List<float>();
            var verYs = new List<float>();
            var verZs = new List<float>();
            for (int i = 0; i < vertices.Count(); i++)
            {
                if (i % 3 == 0)
                {
                    verXs.Add(vertices[i]);
                }
                else if (i % 3 == 1)
                {
                    verYs.Add(vertices[i]);
                }
                else
                {
                    verZs.Add(vertices[i]);
                }
            }
            //create accessors
            //accessor indices
            var accessor1 = new Accessor(0, 5123, Indices.Count(), "SCALAR", Convert.ToString(Indices.Count() - 1), "0");
            var max = $"[{verXs.Max()},{verYs.Max()},{verZs.Max()}]".Replace('/', '.');
            var min = $"[{verXs.Min()},{verYs.Min()},{verZs.Min()}]".Replace('/', '.');

            //accessor vertices
            var accessor2 = new Accessor(0, 5126, vertices.Count(), "VEC3", max, min);
            Buffer.Accessors.Add(accessor1);
            Buffer.Accessors.Add(accessor2);

            //create buffer byte array
            var Bytes = new List<byte>();
            foreach (var i in Indices)
            {
                if (i < 256)
                {
                    Bytes.Add(Convert.ToByte(i));
                    Bytes.Add(Convert.ToByte(0));
                }
                else
                {
                    Bytes.Add(Convert.ToByte(i % 256));
                    Bytes.Add(Convert.ToByte(i / 256));
                }
            }
            var indicesByteLength = Bytes.Count();
            var BufferView = new BufferView(0, indicesByteLength, 34963);
            Buffer.BufferViews.Add(BufferView);
            if (indicesByteLength % 4 != 0)
            {
                Bytes.Add(Convert.ToByte(0));
                Bytes.Add(Convert.ToByte(0));
                offset = 2;
            }
            foreach (var v in vertices)
            {
                var bytes = BitConverter.GetBytes(v);
                Bytes.AddRange(bytes);
            }
            Buffer.byteLength = Bytes.Count();

            var verticesByteLength = Buffer.byteLength - (BufferView.byteLength + offset);
            var BufferView2 = new BufferView(indicesByteLength + offset, verticesByteLength, 34962);
            Buffer.BufferViews.Add(BufferView2);

            //create buffer URI String
            string base64 = Convert.ToBase64String(Bytes.ToArray());
            var BufferPrefix = " \"uri\" : \"data:application/gltf-buffer;base64,";
            Buffer.URI = BufferPrefix + base64;

        }
    }
    public class Material
    {
        public bool DoubleSided { get; set; }
        public string Name { get; set; }
        public float[] emissiveFactor { get; set; }
        public string alphaMode { get; set; }
        public float alphaCutoff { get; set; }
        public pbrMetallicRoughness pbrMetallicRoughness { get; set; }
        public Material(pbrMetallicRoughness pbrMetallicRoughness, bool DoubleSided, string name = "new material")
        {
            this.pbrMetallicRoughness = pbrMetallicRoughness;
            this.DoubleSided = DoubleSided;
            this.Name = name;
            this.emissiveFactor = new float[3];

        }
    }
    public class pbrMetallicRoughness
    {
        public float[] baseColorFactor { get; set; }
        public float metallicFactor { get; set; }
        public float roughnessFactor { get; set; }
        public pbrMetallicRoughness(float[] baseColorFactor, float metallicFactor, float roughnessFactor)
        {
            this.baseColorFactor = new float[4];
            this.baseColorFactor = baseColorFactor;

            this.metallicFactor = metallicFactor;
            this.roughnessFactor = roughnessFactor;
        }
    }

    public class Buffer
    {
        public string URI { get; set; }
        public int byteLength { get; set; }
        public List<BufferView> BufferViews { get; set; }
        public List<Accessor> Accessors { get; set; }
    }
    public class BufferView
    {
        public int buffer { get; set; }
        public int byteOffset { get; set; }
        public int byteLength { get; set; }
        public int target { get; set; }
        public BufferView(int byteOffset, int byteLength, int target)
        {
            this.byteOffset = byteOffset;
            this.byteLength = byteLength;
            this.target = target;
        }
    }
    public class Accessor
    {
        public int byteOffset { get; set; }
        public int componentType { get; set; }
        public int count { get; set; }
        public string type { get; set; }
        public string max { get; set; }
        public string min { get; set; }
        public Accessor(int byteOffset, int componentType, int count, string type, string max, string min)
        {
            this.byteOffset = byteOffset;
            this.componentType = componentType;
            this.count = count;
            this.type = type;
            this.max = max;
            this.min = min;
        }
    }

    public class Triangle
    {
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }
        public Vertex Vertex3 { get; set; }
        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            Vertex1 = v1;
            Vertex2 = v2;
            Vertex3 = v3;
        }
    }
    public class Vertex
    {
        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
    }


}

//namespace GLTF
//{
//    public class GltfGenerator
//    {
//        public Scene Scene { get; set; }
//        private string ScenesValue { get; set; }
//        private string NodesValue { get; set; }
//        private string MeshesValue { get; set; }
//        private string BuffersValue { get; set; }
//        private string BufferViewsValue { get; set; }
//        private string AccessorsVallue { get; set; }
//        private string AssetValue { get; set; }
//        public GltfGenerator()
//        {
//            ScenesValue = "\"scenes\" : [";
//            NodesValue = ",\"nodes\" : [";
//            MeshesValue = ",\"meshes\" :[";
//            BuffersValue = ",\"buffers\" :[";
//            BufferViewsValue = ",\"bufferViews\" :[";
//            AccessorsVallue = ",\"accessors\" :[";
//            AssetValue = ",\"asset\" : {\"version\" : \"2.0\"}";
//            CreateScene();
//        }
//        public void CreateScene()
//        {
//            //Scenes = new List<Scene>();
//            Scene = new Scene();
//            //Scenes.Add(Scene);

//        }
//        public string createGltf()
//        {
//            //Scenes Value
//            ScenesValue += getScenesValue(Scene.Nodes);
//            ScenesValue += "]";
//            // Node Value--->"nodes" : [{"mesh" : 0 }]
//            NodesValue += getNodesValue(Scene.Nodes);
//            NodesValue += "]";
//            // meshes Value --->"meshes" : [ { "primitives" : [ { "attributes" : { "POSITION" : 1  }, "indices" : 0  } ] } ],
//            MeshesValue += getMeshValues(Scene.Nodes);
//            MeshesValue += "]";
//            // buffer value--->"buffers" : [{"uri" : "data:application/gltf-buffer;base64,AAABAAIAAAAAAAAAAAAAAAAAAAAAAAAAAACQQQAAAAAAAGBBAAAAAAAAAAA=","byteLength" : 44}],
//            BuffersValue += getBufferValues(Scene.Nodes);
//            BuffersValue += "]";
//            // bufferview value---->"bufferViews" : [ {"buffer" : 0,"byteOffset" : 0,"byteLength" : 72,"target" : 34963 }, {"buffer" : 0,"byteOffset" : 72,   "byteLength" : 168  }, { "buffer" : 0,"byteOffset" : 240,"byteLength" : 6 }, {"buffer" : 0,"byteOffset" : 248,"byteLength" : 36 } ],
//            BufferViewsValue += getBufferViewValue(Scene.Nodes);
//            BufferViewsValue += "]";
//            // Accessor Value
//            AccessorsVallue += getAccessorValue(Scene.Nodes);
//            AccessorsVallue += "]";

//            string GltfString = "{";
//            GltfString += ScenesValue;
//            GltfString += NodesValue;
//            GltfString += MeshesValue;
//            GltfString += BuffersValue;
//            GltfString += BufferViewsValue;
//            GltfString += AccessorsVallue;
//            GltfString += AssetValue;
//            GltfString += "}";
//            return GltfString;
//        }

//        private string getScenesValue(List<Node> nodes)
//        {
//            string result = string.Empty;
//            int i = 0;
//            result += "{\"nodes\" : [";
//            foreach (var node in nodes)
//            {
//                foreach (var mesh in node.Meshes)
//                {
//                    result += $"{i++},";

//                }
//            }
//            result = result.Remove(result.Length - 1);
//            result += "]}";

//            return result;

//        }

//        private string getAccessorValue(List<Node> nodes)
//        {
//            string result = string.Empty;
//            int bufferViewindex = 0;
//            foreach (var node in nodes)
//            {
//                if (node.Type == "mesh")
//                {
//                    foreach (var mesh in node.Meshes)
//                    {

//                        result += "{\"bufferView\" :" + bufferViewindex + ",";
//                        result += $"\"byteOffset\" : 0,";
//                        result += $"\"componentType\" : { mesh.Buffer.Accessors[0].componentType },";
//                        result += $"\"count\" : { mesh.Buffer.Accessors[0].count} ,";
//                        result += $" \"type\" : \"{mesh.Buffer.Accessors[0].type}\",";
//                        result += $"\"max\" : [{ mesh.Buffer.Accessors[0].max }],";
//                        result += $"\"min\" : [{ mesh.Buffer.Accessors[0].min }]" + " },";

//                        bufferViewindex++;

//                        result += "{\"bufferView\" :" + bufferViewindex + ",";
//                        result += $"\"byteOffset\" : 0,";
//                        result += $"\"componentType\" : { mesh.Buffer.Accessors[1].componentType },";
//                        result += $"\"count\" : {mesh.Buffer.Accessors[1].count / 3} ,";
//                        result += $" \"type\" : \"{mesh.Buffer.Accessors[1].type}\",";
//                        result += $"\"max\" : { mesh.Buffer.Accessors[1].max },";
//                        result += $"\"min\" : { mesh.Buffer.Accessors[1].min }" + " },";
//                        bufferViewindex++;
//                    }

//                }
//            }
//            result = result.Remove(result.Length - 1);
//            return result;
//        }

//        private string getBufferViewValue(List<Node> nodes)
//        {
//            string result = string.Empty;
//            int meshIndex = 0;
//            foreach (var node in nodes)
//            {
//                if (node.Type == "mesh")
//                {
//                    foreach (var mesh in node.Meshes)
//                    {
//                        result += "{" + $"\"buffer\" : {meshIndex},";
//                        result += $"\"byteOffset\" : 0,\"byteLength\" : {mesh.Buffer.BufferViews[0].byteLength},";
//                        result += $"\"target\" : { mesh.Buffer.BufferViews[0].target }" + "},";
//                        result += "{" + $"\"buffer\" : { meshIndex} ,";
//                        result += $" \"byteOffset\" : {mesh.Buffer.BufferViews[1].byteOffset },";
//                        result += $"\"byteLength\" : { mesh.Buffer.BufferViews[1].byteLength }" + " },";
//                        meshIndex++;
//                    }

//                }
//            }
//            result = result.Remove(result.Length - 1);
//            return result;
//        }

//        private string getBufferValues(List<Node> nodes)
//        {
//            string result = string.Empty;
//            foreach (var node in nodes)
//            {
//                if (node.Type == "mesh")
//                {
//                    foreach (var mesh in node.Meshes)
//                    {
//                        //foreach (var buffer in mesh.Buffer)
//                        //{
//                        result += "{" + $" {mesh.Buffer.URI}\",\"byteLength\" : {mesh.Buffer.byteLength}" + "},";

//                        //}
//                    }

//                }
//            }
//            result = result.Remove(result.Length - 1);
//            return result;
//        }

//        private string getMeshValues(List<Node> nodes)
//        {
//            string result = string.Empty;
//            int i = 0;
//            foreach (var node in nodes)
//            {
//                if (node.Type == "mesh")
//                {
//                    foreach (var mesh in node.Meshes)
//                    {
//                        result += "{ \"primitives\": [ { \"attributes\" : { \"POSITION\" :" + (i + 1) + "  }, \"indices\" : " + i + "  } ] },";
//                        i += 2;
//                    }

//                }
//            }
//            result = result.Remove(result.Length - 1);
//            return result;
//        }

//        private string getNodesValue(List<Node> nodes)
//        {
//            string result = string.Empty;
//            int i = 0;
//            foreach (var node in nodes)
//            {
//                if (node.Type == "mesh")
//                {
//                    foreach (var mesh in node.Meshes)
//                    {
//                        result += "{" + $"\"mesh\":{i++}" + "},";

//                    }
//                }
//                else
//                {
//                    result += $"\"children\":[";
//                    foreach (var childNode in node.Nodes)
//                    {
//                        result += $"{i++},";

//                    }
//                    result += getNodesValue(node.Nodes);
//                }
//            }
//            result = result.Remove(result.Length - 1);
//            return result;
//        }
//    }


//    public class Scene
//    {
//        public List<int> nodesArrayIndexes { get; set; }
//        public List<Node> Nodes { get; set; }
//        public Scene()
//        {
//            nodesArrayIndexes = new List<int>();
//            Nodes = new List<Node>();
//        }

//        public override string ToString()
//        {
//            string indexes = "\"scenes\" : [ { ";
//            if (nodesArrayIndexes.Count != 0)
//            {
//                indexes += "\"nodes\" : [";
//                int i = 0;
//                foreach (var index in nodesArrayIndexes)
//                {
//                    indexes += i++;
//                }
//                indexes += "]";
//            }
//            indexes += " } ],";
//            return indexes;
//        }
//    }
//    public class Node
//    {
//        public string Type { get; set; }
//        public List<Node> Nodes { get; set; }
//        public List<Mesh> Meshes { get; set; }
//        public Node(List<Mesh> Meshes)
//        {
//            Type = "mesh";
//            this.Meshes = new List<Mesh>();
//            this.Meshes = Meshes;
//        }
//        public Node(Mesh mesh)
//        {
//            Meshes = new List<Mesh>();
//            Meshes.Add(mesh);
//            Type = "mesh";
//        }
//        public Node(List<Node> nodes)
//        {
//            Nodes = new List<Node>();
//            Nodes = nodes;
//        }
//        public Node(string type = "mesh")
//        {
//            Meshes = new List<Mesh>();
//            Type = type;
//        }

//    }
//    public class Mesh
//    {
//        public Buffer Buffer { get; set; }
//        public List<int> Indices { get; set; }
//        public List<float> vertices { get; set; }
//        public List<Triangle> Triangles { get; set; }
//        public Mesh(List<Triangle> Triangles)
//        {
//            this.Triangles = new List<Triangle>();
//            this.Triangles = Triangles;

//            //Add indices and vertices
//            Indices = new List<int>();
//            vertices = new List<float>();
//            int indice = 0;
//            //create buffer
//            Buffer = new Buffer();
//            Buffer.Accessors = new List<Accessor>();
//            Buffer.BufferViews = new List<BufferView>();
//            var offset = 0;
//            var BufferPrefix = " \"uri\" : \"data:application/gltf-buffer;base64,";
//            var Bytes = new List<byte>();
//            foreach (var triangle in Triangles)
//            {
//                Indices.Add(indice++);
//                Indices.Add(indice++);
//                Indices.Add(indice++);
//                vertices.Add(triangle.Vertex1.X);
//                vertices.Add(triangle.Vertex1.Y);
//                vertices.Add(triangle.Vertex1.Z);
//                vertices.Add(triangle.Vertex2.X);
//                vertices.Add(triangle.Vertex2.Y);
//                vertices.Add(triangle.Vertex2.Z);
//                vertices.Add(triangle.Vertex3.X);
//                vertices.Add(triangle.Vertex3.Y);
//                vertices.Add(triangle.Vertex3.Z);
//            }
//            var verXs = new List<float>();
//            var verYs = new List<float>();
//            var verZs = new List<float>();
//            for (int i = 0; i < vertices.Count(); i++)
//            {
//                if (i % 3 == 0)
//                {
//                    verXs.Add(vertices[i]);
//                }
//                else if (i % 3 == 1)
//                {
//                    verYs.Add(vertices[i]);
//                }
//                else
//                {
//                    verZs.Add(vertices[i]);
//                }
//            }
//            var accessor1 = new Accessor(0, 5123, Indices.Count(), "SCALAR", Convert.ToString(Indices.Count() - 1), "0");
//            var max = $"[{verXs.Max()},{verYs.Max()},{verZs.Max()}]".Replace('/', '.');
//            var min = $"[{verXs.Min()},{verYs.Min()},{verZs.Min()}]".Replace('/', '.');

//            var accessor2 = new Accessor(0, 5126, vertices.Count(), "VEC3", max, min);
//            Buffer.Accessors.Add(accessor1);
//            Buffer.Accessors.Add(accessor2);
//            foreach (var i in Indices)
//            {
//                if (i < 256)
//                {
//                    Bytes.Add(Convert.ToByte(i));
//                    Bytes.Add(Convert.ToByte(0));
//                }
//                else
//                {
//                    Bytes.Add(Convert.ToByte(i % 256));
//                    Bytes.Add(Convert.ToByte(i / 256));
//                }
//            }
//            var indicesByteLength = Bytes.Count();
//            var BufferView = new BufferView(0, indicesByteLength, 34963);
//            Buffer.BufferViews.Add(BufferView);
//            if (indicesByteLength % 4 != 0)
//            {
//                Bytes.Add(Convert.ToByte(0));
//                Bytes.Add(Convert.ToByte(0));
//                offset = 2;
//            }
//            foreach (var v in vertices)
//            {
//                var bytes = BitConverter.GetBytes(v);
//                Bytes.AddRange(bytes);
//            }
//            Buffer.byteLength = Bytes.Count();

//            var verticesByteLength = Buffer.byteLength - (BufferView.byteLength + offset);
//            var BufferView2 = new BufferView(indicesByteLength + offset, verticesByteLength, 34962);
//            Buffer.BufferViews.Add(BufferView2);


//            string base64 = Convert.ToBase64String(Bytes.ToArray());
//            //plus prefix
//            Buffer.URI = BufferPrefix + base64;

//        }
//    }

//public class Buffer
//{
//    public string URI { get; set; }
//    public int byteLength { get; set; }
//    public List<BufferView> BufferViews { get; set; }
//    public List<Accessor> Accessors { get; set; }
//}
//public class BufferView
//{
//    public int buffer { get; set; }
//    public int byteOffset { get; set; }
//    public int byteLength { get; set; }
//    public int target { get; set; }
//    public BufferView(int byteOffset, int byteLength, int target)
//    {
//        this.byteOffset = byteOffset;
//        this.byteLength = byteLength;
//        this.target = target;
//    }
//}
//public class Accessor
//{
//    public int byteOffset { get; set; }
//    public int componentType { get; set; }
//    public int count { get; set; }
//    public string type { get; set; }
//    public string max { get; set; }
//    public string min { get; set; }
//    public Accessor(int byteOffset, int componentType, int count, string type, string max, string min)
//    {
//        this.byteOffset = byteOffset;
//        this.componentType = componentType;
//        this.count = count;
//        this.type = type;
//        this.max = max;
//        this.min = min;
//    }
//}

//public class Triangle
//{
//    public Vertex Vertex1 { get; set; }
//    public Vertex Vertex2 { get; set; }
//    public Vertex Vertex3 { get; set; }
//    public Triangle(Vertex v1, Vertex v2, Vertex v3)
//    {
//        Vertex1 = v1;
//        Vertex2 = v2;
//        Vertex3 = v3;
//    }
//}
//public class Vertex
//{
//    public Vertex(float x, float y, float z)
//    {
//        X = x;
//        Y = y;
//        Z = z;
//    }
//    public float X { get; set; }
//    public float Y { get; set; }
//    public float Z { get; set; }
//}
//}
