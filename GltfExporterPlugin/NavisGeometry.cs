using Autodesk.Navisworks.Api;
using System;
using System.Collections.Generic;
using NavisApplication = Autodesk.Navisworks.Api.Application;
using ComBridge = Autodesk.Navisworks.Api.ComApi.ComApiBridge;
using COMApi = Autodesk.Navisworks.Api.Interop.ComApi;


namespace LinkNavigator.GltfExporter
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
        public CallbackGeomListener getFragments()
        {
            // create the callback object
            CallbackGeomListener callbkListener = new CallbackGeomListener();
            foreach (COMApi.InwOaPath3 path in oSel.Paths())
            {
                foreach (COMApi.InwOaFragment3 frag in path.Fragments())
                {
                    COMApi.InwLTransform3f3 localToWorld = (COMApi.InwLTransform3f3)(object)frag.GetLocalToWorldMatrix();
                   
                    //create Global Cordinate System Matrix
                    Array array_v1 = (Array)(object)localToWorld.Matrix;
                    var elements = ToArray<double>(array_v1);
                    float[] elementsFloat = new float[elements.Length];
                    for (int i = 0; i < elements.Length; i++)
                    {
                        elementsFloat[i] = (float)elements[i];
                    }

                    callbkListener.matrix = elementsFloat;
                    frag.GenerateSimplePrimitives(COMApi.nwEVertexProperty.eNORMAL, callbkListener);
                }
            }
            return callbkListener;
        }
        public T[] ToArray<T>(Array arr)
        {
            T[] result = new T[arr.Length];
            Array.Copy(arr, result, result.Length);

            return result;
        }
    }


   
}
