using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZZLH.PackagingTool.App
{
    interface IControlRenderer<T>
    {
        /// <summary>
        /// 将数据渲染到控件上
        /// </summary>
        /// <param name="info"></param>
        void Render(T info);
        /// <summary>
        /// 从控件上获取数据
        /// </summary>
        /// <returns></returns>
        T Fetch();
        /// <summary>
        /// 校验数据
        /// </summary>
        /// <returns></returns>
        bool Check();
        /// <summary>
        /// 清空控件上的数据
        /// </summary>
        void Clear();
    }
}
