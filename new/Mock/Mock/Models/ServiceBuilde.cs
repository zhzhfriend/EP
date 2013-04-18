using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock.Models.Interfaces;
using Mock.Models.MockModels;



namespace Mock.Models
{
    public class ServiceBuilde
    {
        /// <summary>
        /// 创建分类服务组件
        /// </summary>
        /// <returns>分类服务组件</returns>
        public static ICategoryService BuildCategoryService()
        {
            return new MockCategoryService();
        }

        /// <summary>
        /// 创建公告服务组件
        /// </summary>
        /// <returns>公告服务组件</returns>
        public static IAnnounceService BuildAnnounceService()
        {
            return new MockAnnounceService();
        }
    }
}