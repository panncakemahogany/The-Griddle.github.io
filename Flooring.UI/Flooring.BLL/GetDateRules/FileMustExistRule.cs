using Flooring.Models.Interfaces;
using Flooring.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Flooring.Data;

namespace Flooring.BLL.GetDateRules
{
    public class FileMustExistRule : IGetDate
    {
        public GetDateResponse GetDate(string date)
        {
            GetDateResponse response = new GetDateResponse();

            DateTime validate = new DateTime();

            if (DateTime.TryParse(date, out validate))
            {
                string path = validate.ToString("MMddyyyy");

                if (File.Exists(Settings.GetOrderDateFilePath(path)))
                {
                    response.Success = true;
                    response.FilePath = Settings.GetOrderDateFilePath(path);
                    response.Date = path;
                    response.FileExists = true;
                    return response;
                }
                else
                {
                    response.Success = true;
                    response.Message = "The date given does not match any record on file.";
                    response.FileExists = false;
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
