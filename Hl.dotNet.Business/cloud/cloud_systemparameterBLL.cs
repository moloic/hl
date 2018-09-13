using Hl.dotNet.CacheBase;
using Hl.dotNet.DataAccess;
using Hl.dotNet.IBusiness;
using Hl.dotNet.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Business
{
    public class cloud_systemparameterBLL : Icloud_systemparameterBLL
    {

        cloud_systemparameterDal cloud_systemparameterDal = new cloud_systemparameterDal();
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DataTable getPageList(cloud_systemparameter model)
        {

            return cloud_systemparameterDal.getPageList(model);


            #region  缓存用法
            //DataTable dt = null;
            //object obj = CacheHelper.GetCache("cloud_systemparameterBLL_getPageList"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    dt = (DataTable)obj;

            //}
            //else
            //{
            //    dt = cloud_systemparameterDal.getPageList(model);
            //    CacheHelper.SetCacheAbsolute("cloud_systemparameterBLL_getPageList", dt);//写入服务器缓存
            //}
            //return dt;
            #endregion

        }

        /// <summary>
        /// 返回总条数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int GetRecordCount(cloud_systemparameter model)
        {
            return cloud_systemparameterDal.GetRecordCount(model);

            #region  缓存用法
            //int totalItems = 0;
            //object obj = CacheHelper.GetCache("cloud_systemparameterBLL_GetRecordCount"); //key一定要设置的有规律不重复类名+方法名
            //if (obj != null)
            //{
            //    totalItems = (int)obj;

            //}
            //else
            //{
            //    totalItems = cloud_systemparameterDal.GetRecordCount(model);
            //    CacheHelper.SetCacheAbsolute("cloud_systemparameterBLL_GetRecordCount", totalItems);//写入服务器缓存
            //}
            //return totalItems;
            #endregion



        }

        //查询List
        public IList<cloud_systemparameter> getcloud_systemparameterList(cloud_systemparameter model)
        {
            IList<cloud_systemparameter> list = new List<cloud_systemparameter>();
            try
            {
                list = cloud_systemparameterDal.getcloud_systemparameterList(model);
            }
            catch
            {
                list = null;
            }
            return list;
        }

        //获取实体
        public cloud_systemparameter QueryObject(cloud_systemparameter model)
        {
            IList<cloud_systemparameter> list = cloud_systemparameterDal.getcloud_systemparameterList(model);
            if (list.Count > 0)
            {
                return list[0];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(cloud_systemparameter model)
        {
            return cloud_systemparameterDal.Insert(model);

        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(cloud_systemparameter oldmodel, cloud_systemparameter model)
        {
            return cloud_systemparameterDal.Update(oldmodel,model);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Delete(string Id)
        {
            List<cloud_systemparameter> List = new List<cloud_systemparameter>();
            bool isok = false;
            string ID = Id.ToString().TrimEnd(',');
            string[] arry = ID.Split(',');
            if (arry.Length > 0)
            {
                for (int i = 0; i < arry.Length; i++)
                {
                    cloud_systemparameter oldmodel = new cloud_systemparameter();
                    oldmodel = QueryObject(new cloud_systemparameter { Id = arry[i].ToString().Replace("'","") });//用于历史写入原来的值
                    List.Add(oldmodel);
                }
                cloud_systemparameterDal.Delete(List);
                isok = true;
            }
            return isok; //cloud_systemparameterDal.Delete(Id, oldmodel);

        }
    }
}
