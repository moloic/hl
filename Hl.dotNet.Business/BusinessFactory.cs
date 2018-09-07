
using Hl.dotNet.Business;
using Hl.dotNet.IBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hl.dotNet.Business
{
    /// <summary>
    /// 业务逻辑创建工厂
    /// </summary>
    public class BusinessFactory
    {
        private static BusinessFactory instance = null;
        private static readonly object syncObj = new object();

        /// <summary>  
        /// 业务逻辑创建工厂实例
        /// </summary>
        public static BusinessFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncObj)
                    {
                        if (instance == null)
                        {
                            instance = new BusinessFactory();
                        }
                    }
                }

                return instance;
            }
        }



        public Ibase_menuBLL Createbase_Base_menuBLL()
        {
            return new base_menuBLL();
        }


        public Ibase_userBLL Createbase_Base_userBLL()
        {
            return new base_userBLL();
        }

        public Ibase_userroleBLL Createbase_Base_userroleBLL()
        {
            return new base_userroleBLL();
        }
        public Ibase_dicsBLL Createbase_dicsBLL()
        {
            return new base_dicsBLL();
        }
        //日志填写
        public IBase_SysLogBll CreateBase_SysLogBll()
        {
            return new Base_SysLogBll();
        }



        public Icloud_equipmentBLL Createcloud_equipmentBLL()
        {
            return new cloud_equipmentBLL();
        }

        /// <summary>
        /// 零件类别管理
        /// </summary>
        /// <returns></returns>
        public Icloud_componentBLL Createcloud_componentBLL()
        {
            return new cloud_componentBLL();
        }
        /// <summary>
        ///  零件清单
        /// </summary>
        /// <returns></returns>
        public Icloud_componentlistBLL Createcloud_componentlistBLL()
        {
            return new cloud_componentlistBLL();
        }

        /// <summary>
        /// 帮助信息
        /// </summary>
        /// <returns></returns>
        public Icloud_helpinfoBLL Createcloud_helpinfoBLL()
        {
            return new cloud_helpinfoBLL();
        }

        /// <summary>
        /// 设备零件关联
        /// </summary>
        /// <returns></returns>
        public Icloud_equipmentcomponenBLL Createcloud_equipmentcomponenBLL()
        {
            return new cloud_equipmentcomponenBLL();
        }

        /// <summary>
        /// 维修保养
        /// </summary>
        /// <returns></returns>
        public Icloud_componentrepairrecordBLL Createcloud_componentrepairrecordBLL()
        {
            return new cloud_componentrepairrecordBLL();
        }

        /// <summary>
        /// 客户维修保养记录
        /// </summary>
        /// <returns></returns>
        public Icloud_componentrepairrecordhistoryBLL Createcloud_componentrepairrecordhistoryBLL()
        {
            return new cloud_componentrepairrecordhistoryBLL();
        }


        
        /// <summary>
        ///  维修保养信息推送
        /// </summary>
        /// <returns></returns>
        public Icloud_componetmessageBLL Createcloud_componetmessageBLL()
        {
            return new cloud_componetmessageBLL();
        }


        public Icloud_userequipmentBLL Createcloud_userequipmentBLL()
        {
            return new cloud_userequipmentBLL();
        }


        public Icloud_repairorderBLL Createcloud_repairorderBLL()
        {
            return new cloud_repairorderBLL();
        }


        public Ibase_fileBLL Createbase_fileBLL()
        {
            return new base_fileBLL();
        }


        public Icloud_ordernodeBLL Createcloud_ordernodeBLL()
        {
            return new cloud_ordernodeBLL();
        }


        public Icloud_workpersonnelBLL Createcloud_workpersonnelBLL()
        {
            return new cloud_workpersonnelBLL();
        }

        /// <summary>
        /// 报警信息
        /// </summary>
        /// <returns></returns>
        public Icloud_alarmBLL Createcloud_alarmBLL()
        {
            return new cloud_alarmBLL();
        }

        /// <summary>
        /// 系统参数类型
        /// </summary>
        /// <returns></returns>
        public Icloud_systemparametertypeBLL Createcloud_systemparametertypeBLL()
        {
            return new cloud_systemparametertypeBLL();
        }

        /// <summary>
        /// 系统参数
        /// </summary>
        /// <returns></returns>
        public Icloud_systemparameterBLL Createcloud_systemparameterBLL()
        {
            return new cloud_systemparameterBLL();
        }

        /// <summary>
        /// 参数日志
        /// </summary>
        /// <returns></returns>
        public Icloud_systemparameterlogBLL Createcloud_systemparameterlogBLL()
        {
            return new cloud_systemparameterlogBLL();
        }

        /// <summary>
        /// 型号管理
        /// </summary>
        /// <returns></returns>
        public Icloud_equipmentmodelBLL Createcloud_equipmentmodelBLL()
        {
            return new cloud_equipmentmodelBLL();
        }


        /// <summary>
        /// 代理设备
        /// </summary>
        /// <returns></returns>
        public Icloud_agentequipmentBLL Createcloud_agentequipmentBLL()
        {
            return new cloud_agentequipmentBLL();
        }

        /// <summary>
        /// 消息列表
        /// </summary>
        /// <returns></returns>
        public Icloud_messageBLL Createcloud_messageBLL()
        {
            return new cloud_messageBLL();
        }

        /// <summary>
        /// 首页地图监控
        /// </summary>
        /// <returns></returns>
        public Icloud_equipmentStatusmodelBLL Createcloud_equipmentStatusmodelBLL()
        {
            return new cloud_equipmentStatusmodelBLL();
        }


        /// <summary>
        /// CRM/技术支持 关联工单
        /// </summary>
        /// <returns></returns>
        public Icloud_crmandsupportorderBLL Createcloud_crmandsupportorderBLL()
        {
            return new cloud_crmandsupportorderBLL();
        }


        public Ibase_departmentBLL Createbase_departmentBLL()
        {
            return new base_departmentBLL();
        }

        /// <summary>
        /// 二维码
        /// </summary>
        /// <returns></returns>
        public Ibase_qrcoderBLL Createbase_qrcoderBLL()
        {
            return new base_qrcoderBLL();
        }
        

    }
}
