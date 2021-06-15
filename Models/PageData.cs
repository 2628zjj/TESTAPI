using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class PageData
    {
        /// <summary>
        /// 页容量
        /// </summary>
        public int pageSize { set; get; }

        /// <summary>
        /// 页码
        /// </summary>
        public int pageNum { set; get; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int pageCount { set; get; }

        /// <summary>
        /// 总条数
        /// </summary>
        public int totalNumber { set; get; }

        public object data { set; get; }
    }
}
