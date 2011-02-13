﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace CprBroker.EventBroker.Backend
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            string s = CprBroker.Config.Properties.Settings.Default.CprBrokerConnectionString;
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
			{ 
				new BackendService() 
			};
            ServiceBase.Run(ServicesToRun);
        }
    }
}
