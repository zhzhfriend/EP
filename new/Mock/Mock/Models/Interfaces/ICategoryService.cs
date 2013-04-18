using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock.Models.Entities;

namespace Mock.Models.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="category"></param>
        void Add(CategoryInfo category);

        /// <summary>
        /// 修改分类名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        void ChangeName(int id, string name);

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// 取得某个分类详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryInfo GetDetail(int id);

        /// <summary>
        /// 取得所有分类
        /// </summary>
        /// <returns></returns>
        List<CategoryInfo> GetAll();
    }
}