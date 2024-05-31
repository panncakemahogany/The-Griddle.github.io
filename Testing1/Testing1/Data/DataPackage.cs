using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing1.Data
{
    internal class DataPackage
    {
        public int Id { get; set; }
        public string sName {  get; set; }
        public int iNumber { get; set; }
        public DateTime dtCreated { get; set; }
        public DataPackage(string sdata) 
        {
            string[] adata = sdata.Split(',');
            this.Id = int.Parse(adata[0]);
            this.sName = adata[2];
            this.dtCreated = DateTime.Parse(adata[1]);
            this.iNumber = int.Parse(adata[3]);
        }
        public override string ToString()
        {
            return $"{Id},{dtCreated.ToString()},{sName},{iNumber}";
        }
    }
}
