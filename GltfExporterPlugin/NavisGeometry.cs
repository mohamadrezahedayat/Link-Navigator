using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using NavisApplication = Autodesk.Navisworks.Api.Application;
using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;
using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;

namespace LinkNavigator
{
    public class NavisGeometry
    {
        private ModelItemCollection oModelColl { get; set; }
        private COMApi.InwOpSelection oSel { get; set; }
        private COMApi.InwOpState oState = ComBridge.State;
        public NavisGeometry()
        {
            // Add Selected Items to oModelColl Property
            oModelColl = NavisApplication.ActiveDocument.CurrentSelection.SelectedItems;
            //convert to COM selection
            oSel = ComBridge.ToInwOpSelection(oModelColl);



        }
        public List<COMApi.InwOaFragment3> getFragments()
        { 
            // create the callback object
            CallbackGeomListener callbkListener = new CallbackGeomListener();
            var fragments = new List<COMApi.InwOaFragment3>();
            foreach (COMApi.InwOaPath3 path in oSel.Paths())

            {

                foreach (COMApi.InwOaFragment3 frag in path.Fragments())

                {

                    fragments.Add(frag);
                    frag.GenerateSimplePrimitives(COMApi.nwEVertexProperty.eNORMAL, callbkListener);
                }

            }
            return fragments;
        }


    }


    class CallbackGeomListener : COMApi.InwSimplePrimitivesCB
    {
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
            float v1_1 = (float)(array_v1.GetValue(1));
            float v1_2 = (float)(array_v1.GetValue(2));
            float v1_3 = (float)(array_v1.GetValue(3));

            Array array_v2 = (Array)(object)v2.coord;
            float v2_1 = (float)(array_v2.GetValue(1));
            float v2_2 = (float)(array_v2.GetValue(2));
            float v2_3 = (float)(array_v2.GetValue(3));

            Array array_v3 = (Array)(object)v3.coord;
            float v3_1 = (float)(array_v3.GetValue(1));
            float v3_2 = (float)(array_v3.GetValue(2));
            float v3_3 = (float)(array_v3.GetValue(3));
        }

    }
}
