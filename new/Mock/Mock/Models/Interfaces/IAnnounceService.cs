using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock.Models.Entities;

namespace Mock.Models.Interfaces
{
    public interface IAnnounceService
    {
        /// <summary>
        /// 发布公告
        /// </summary>
        /// <param name="announce"></param>
        void Release(AnnounceInfo announce);

        /// <summary>
        /// 修改公告信息
        /// </summary>
        /// <param name="announce"></param>
        void Notify(AnnounceInfo announce);

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="id"></param>
        void Remove(int id);

        /// <summary>
        /// 取得公告详细内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        AnnounceInfo GetDetail(int id);

        /// <summary>
        /// 取得某个分类下的所有公告
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        List<AnnounceInfo> GetByCategory(CategoryInfo category);
    }
}