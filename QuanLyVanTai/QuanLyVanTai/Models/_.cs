using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Test.Models
{
    public class _
    {
        private static QLVanTai_2017 _DB;

        public static QLVanTai_2017 DB
        {
            get
            {
                if (_DB == null)
                {
                    _DB = new QLVanTai_2017();
                }
                return _DB;
            }
        }

        /// <summary>
        /// Tạo mới chuỗi kết nối
        /// </summary>
        public static QLVanTai_2017 DBC
        {
            get
            {
                if (_DB != null) _DB.Dispose();

                _DB = new QLVanTai_2017();
                return _DB;
            }
        }
    }
}