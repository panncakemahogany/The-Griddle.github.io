using GuildCarsMastery.Data.Contacts;
using GuildCarsMastery.Data.Purchases;
using GuildCarsMastery.Data.Specials;
using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models.Parcels.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCarsMastery.Models
{
    public class ReportsPostmaster
    {
        public static string WrapRowEntry(string data)
        {
            string entry = WrapTop() + data + WrapBottom();

            return entry;
        }

        static string WrapTop()
        {
            return "<tr>";
        }

        static string WrapBottom()
        {
            return "</tr>";
        }

        public static string WrapColumnEntry(string data)
        {
            string column = WrapFront() + data + WrapBack();

            return column;
        }

        static string WrapFront()
        {
            return "<td>";
        }

        static string WrapBack()
        {
            return "</td>";
        }
    }
}