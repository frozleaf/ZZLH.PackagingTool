using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZZLH.PackagingTool.App
{
    interface IControlCollectionRenderer<T,V> where V : new ()
    {
        /// <summary>
        /// 将数据集合渲染到控件上
        /// </summary>
        /// <param name="list"></param>
        void Render(IEnumerable<T> list);
        /// <summary>
        /// 在控件中添加一条数据
        /// </summary>
        /// <param name="info"></param>
        void Add(T info);
        /// <summary>
        /// 从控件上获取数据集合
        /// </summary>
        /// <returns></returns>
        List<T> Fetch();
        /// <summary>
        /// 清空控件上的数据
        /// </summary>
        void Clear();

        /// <summary>
        /// 更新控件上的数据
        /// </summary>
        /// <param name="info">需要更新的信息</param>
        /// <param name="control">从控件的数据集合中找到与info为主键的数据</param>
        void Update(T info, V control);
    }
}
