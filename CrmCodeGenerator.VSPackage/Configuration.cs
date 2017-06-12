﻿using CrmCodeGenerator.VSPackage.Helpers;
using System;

namespace CrmCodeGenerator.VSPackage
{
    public class Configuration
    {
        #region Singleton

        private static Configuration _instance;
        private static Object SyncLock = new System.Object();

        public static Configuration Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncLock)
                    {
                        if (_instance == null)
                        {
                            _instance = new Configuration();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion Singleton

        public Configuration()
        {
            Settings = new CrmCodeGenerator.VSPackage.Model.Settings();
            Settings.CrmSdkUrl = @"https://disco.crm.dynamics.com/XRMServices/2011/Discovery.svc";
            Settings.ProjectName = "";
            Settings.Domain = "";
            Settings.T4Path = System.IO.Path.Combine(DteHelper.AssemblyDirectory(), @"Resources\Templates\CrmSvcUtil.tt");
            Settings.Template = "";
            Settings.CrmOrg = "DEV-CRM";
            Settings.EntitiesToIncludeString = "account,contact,lead,opportunity,systemuser";
            Settings.OutputPath = "";
            Settings.Username = "@XXXXX.onmicrosoft.com";
            Settings.Password = "";
            Settings.Namespace = "";
            Settings.Dirty = false;
        }

        public CrmCodeGenerator.VSPackage.Model.Settings Settings { get; set; }
        public EnvDTE80.DTE2 DTE { get; set; }
    }
}