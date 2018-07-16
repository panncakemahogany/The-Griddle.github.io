using Flooring.Data;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flooring.BLL.GetDateRules
{
    public class FileExistenceOptionalRule : IGetDate
    {
        public GetDateResponse GetDate(string date)
        {
            GetDateResponse response = new GetDateResponse();

            DateTime validate = new DateTime();

            if (DateTime.TryParse(date, out validate))
            {
                if (validate > DateTime.Now)
                {
                    string path = validate.ToString("MMddyyyy");
                    response.Success = true;
                    response.FilePath = Settings.GetOrderDateFilePath(path);
                    response.Date = path;

                    if (File.Exists(Settings.GetOrderDateFilePath(path)))
                    {
                        response.FileExists = true;
                        return response;
                    }
                    else
                    {
                        response.FileExists = false;
                        return response;
                    }
                }
                else
                {
                    response.Success = false;
                    response.Message = "The given date was not in the future.";
                    return response;
                }
            }
            else
            {
                response.Success = false;
                response.Message = "That was not a date in MM/DD/YYYY format.";
                return response;
            }
        }
    }
}
