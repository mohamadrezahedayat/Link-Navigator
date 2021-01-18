using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;
using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;

namespace LinkNavigator.GltfExporter
{
    public class CallbackGeomListener : COMApi.InwSimplePrimitivesCB
    {
        public List<float> Coords { get; set; }
        public float[] matrix { get; set; }
        public CallbackGeomListener()
        {
            Coords = new List<float>();
        }
        public void Line(COMApi.InwSimpleVertex v1,
                         COMApi.InwSimpleVertex v2)

        {

        }
        public void Point(COMApi.InwSimpleVertex v1)
        {

        }
        public void SnapPoint(COMApi.InwSimpleVertex v1)
        {

        }

        public void Triangle(COMApi.InwSimpleVertex v1,
                             COMApi.InwSimpleVertex v2,
                             COMApi.InwSimpleVertex v3)
        {

           

            Array array_v1 = (Array)(object)v1.coord;
            float v1_x = (float)(array_v1.GetValue(1));
            float v1_y = (float)(array_v1.GetValue(2));
            float v1_z = (float)(array_v1.GetValue(3));

            Array array_v2 = (Array)(object)v2.coord;
            float v2_x = (float)(array_v2.GetValue(1));
            float v2_y = (float)(array_v2.GetValue(2));
            float v2_z = (float)(array_v2.GetValue(3));

            Array array_v3 = (Array)(object)v3.coord;
            float v3_x = (float)(array_v3.GetValue(1));
            float v3_y = (float)(array_v3.GetValue(2));
            float v3_z = (float)(array_v3.GetValue(3));

            //Matrix

            float w1 = matrix[3] * v1_x + matrix[7] * v1_y + matrix[11] * v1_z + matrix[15];

            var v1__x = (matrix[0] * v1_x + matrix[4] * v1_y + matrix[8] * v1_z + matrix[12]) / w1;
            var v1__y = (matrix[1] * v1_x + matrix[5] * v1_y + matrix[9] * v1_z + matrix[13]) / w1;
            var v1__z = (matrix[2] * v1_x + matrix[6] * v1_y + matrix[10] * v1_z + matrix[14]) / w1;


            float w2 = matrix[3] * v2_x + matrix[7] * v2_y + matrix[11] * v2_z + matrix[15];

            var v2__x = (matrix[0] * v2_x + matrix[4] * v2_y + matrix[8] * v2_z + matrix[12]) / w2;
            var v2__y = (matrix[1] * v2_x + matrix[5] * v2_y + matrix[9] * v2_z + matrix[13]) / w2;
            var v2__z = (matrix[2] * v2_x + matrix[6] * v2_y + matrix[10] * v2_z + matrix[14]) / w2;

            float w3 = matrix[3] * v3_x + matrix[7] * v3_y + matrix[11] * v3_z + matrix[15];

            var v3__x = (matrix[0] * v3_x + matrix[4] * v3_y + matrix[8] * v3_z + matrix[12]) / w3;
            var v3__y = (matrix[1] * v3_x + matrix[5] * v3_y + matrix[9] * v3_z + matrix[13]) / w3;
            var v3__z = (matrix[2] * v3_x + matrix[6] * v3_y + matrix[10] * v3_z + matrix[14]) / w3;



            Coords.Add((float)v1__x);
            Coords.Add((float)v1__y);
            Coords.Add((float)v1__z);

            Coords.Add((float)v2__x);
            Coords.Add((float)v2__y);
            Coords.Add((float)v2__z);

            Coords.Add((float)v3__x);
            Coords.Add((float)v3__y);
            Coords.Add((float)v3__z);
        }

    }
}
