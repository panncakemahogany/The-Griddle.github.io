using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flooring.Models.Interfaces;
using Flooring.Models.Responses;

namespace Flooring.BLL.GetNameRules
{
    public class EditNameRule : IGetName
    {
        public GetNameResponse GetName(string name)
        {
            GetNameResponse response = new GetNameResponse();

            if (name.Length == 0)
            {
                response.Success = true;
                response.Edited = false;
                return response;
            }
            else
            {
                char[] reader = new char[name.Length];

                for (int i = 0; i < name.Length; i++)
                {
                    reader[i] = char.Parse(name.Substring(i, 1));
                    if (reader[i] < '0' && reader[i] > '9' &&
                        reader[i] < 'A' && reader[i] > 'Z' &&
                        reader[i] < 'a' && reader[i] > 'z' &&
                        reader[i] != '.')
                    {
                        response.Success = false;
                        response.Message = "The name can only contain characters a-z, A-Z, 0-9, and periods.";
                        return response;
                    }
                }
                response.Name = name;
                response.Success = true;
                response.Edited = true;
                return response;
            }
        }
    }
}
