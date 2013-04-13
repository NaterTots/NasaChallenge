using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LunarBaseCore
{
    public class ServiceManager : List<IService>, IService
    {
        private static ServiceManager singleton = new ServiceManager();

        public static ServiceManager Instance
        {
            get
            {
                return singleton;
            }
        }

        public IService GetService(ServiceType type)
        {
            IService retVal = null;

            foreach (IService service in this)
            {
                if (service.GetServiceType() == type)
                {
                    retVal = service;
                    break;
                }
            }

            if (retVal == null)
            {
                throw new Exception("Unable to obtain Service of type: " + type.ToString());
            }

            return retVal;
        }

        public T GetService<T>(ServiceType type)
        {
            return (T)GetService(type);
        }

		/// <summary>
		/// Allows you to retrieve a service based only on the type. This assumes that will only ever be one Service of a given type.
		/// </summary>
		public T GetService<T>() where T : class, IService
		{
			T retService = null;

			foreach (IService service in this)
			{
				retService = service as T;
				if (retService != null)
				{
					break;
				}
			}

			if (retService == null)
			{
				throw new Exception("Unable to obtain Service");
			}

			return retService;
		}

        public void Initialize()
        {
            foreach (IService service in this)
            {
                service.Initialize();
            }
        }

        public void Finalize()
        {
            foreach (IService service in this)
            {
                service.Finalize();
            }
        }

        public ServiceType GetServiceType()
        {
            //Purposely don't implement this method
            throw new NotImplementedException();
        }
    }
}
