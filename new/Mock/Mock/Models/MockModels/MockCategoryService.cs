using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock.Models.Entities;
using Mock.Models.Interfaces;

namespace Mock.Models.MockModels
{
    public class MockCategoryService:ICategoryService
    {
        /// <summary>
        /// 添加分类
        /// </summary>
        /// <param name="category"></param>
        public void Add(CategoryInfo category)
        {
            return;
        }

        /// <summary>
        /// 修改分类名称
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public void ChangeName(int id, string name)
        {
            return;
        }

        /// <summary>
        /// 删除分类
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            return;
        }

        /// <summary>
        /// 取得某个分类详细信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryInfo GetDetail(int id)
        {
            return new CategoryInfo
            {
                ID = id,
                Name = "最新通告",
            };
        }

        /// <summary>
        /// 取得所有分类
        /// </summary>
        /// <returns></returns>
        public List<CategoryInfo> GetAll()
        {
            List<CategoryInfo> categories = new List<CategoryInfo>();
            for (int i = 1; i <= 5; i++)
            {
                CategoryInfo category = new CategoryInfo
                {
                    ID = i,
                    Name = "通告类别" + i,
                };

                categories.Add(category);
            }

            return categories;
        }
    }
}