using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using DVDModels.Interfaces;

namespace DVDData
{
    public class DvdRepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                case "EntityFramework":
                    return new DvdRepositoryEF();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
