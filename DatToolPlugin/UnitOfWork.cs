//using LinkNavigator.DatToolPlugin.Context;
//using LinkNavigator.DatToolPlugin.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LinkNavigator.DatToolPlugin
//{
//    public class UnitOfWork : IDisposable
//    {
//        MyContext db = new MyContext();

//        private GenericRepository<Navis3dModel> navis3dModelRipository;
//        private GenericRepository<Hyperlink> hyperlinkRipository;

//        public GenericRepository<Navis3dModel> Navis3dModelRipository
//        {
//            get
//            {
//                if (navis3dModelRipository == null)
//                {
//                    navis3dModelRipository = new GenericRepository<Navis3dModel>(db);
//                }
//                return navis3dModelRipository;
//            }
//        }
//        public GenericRepository<Hyperlink> HyperlinkRipository
//        {
//            get
//            {
//                if (hyperlinkRipository == null)
//                {
//                    hyperlinkRipository = new GenericRepository<Hyperlink>(db);
//                }
//                return hyperlinkRipository;
//            }
//        }

//        public void Dispose()
//        {
//            db.Dispose();
//        }
//    }
//}
