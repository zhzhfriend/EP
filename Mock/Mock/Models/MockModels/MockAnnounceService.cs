using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mock.Models.Entities;
using Mock.Models.Interfaces;



namespace Mock.Models.MockModels
{
    public class MockAnnounceService:IAnnounceService
    {
        /// <summary>
        /// 发布公告
        /// </summary>
        /// <param name="announce"></param>
        public void Release(AnnounceInfo announce)
        {
            //throw new Exception("发布公告失败了！原因？没有原因！我是业务组件，我说失败就失败！");
            return;
        }

        /// <summary>
        /// 修改公告信息
        /// </summary>
        /// <param name="announce"></param>
        public void Notify(AnnounceInfo announce)
        {
            return;
        }

        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="id"></param>
        public void Remove(int id)
        {
            return;
        }

        /// <summary>
        /// 取得公告详细内容
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AnnounceInfo GetDetail(int id)
        {
            return new AnnounceInfo
            {
                ID = id,
                Title = "第" + id + "则公告",
                Content = "全体同学明早九点集体做俯卧撑！",
            };
        }

        /// <summary>
        /// 取得某个分类下的所有公告
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public List<AnnounceInfo> GetByCategory(CategoryInfo category)
        {
            List<AnnounceInfo> announces = new List<AnnounceInfo>();
            for (int i = 1; i <= 10; i++)
            {
                AnnounceInfo announce = new AnnounceInfo
                {
                    ID = i,
                    Title = category.Name + "的第" + i + "则公告",
                    Content = "全体同学明早九点集体做俯卧撑！",
                };

                announces.Add(announce);
            }

            return announces;
        }
    }
}