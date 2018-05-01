using GuildCarsMastery.Data.Vehicles;
using GuildCarsMastery.Models;
using GuildCarsMastery.Models.Domain.Vehicle;
using GuildCarsMastery.Models.Parcels.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCarsMastery.BLL.Inventory
{
    public class SearchManager
    {
        VehicleRepository repo { get; set; }

        public SearchManager()
        {
            repo = new VehicleRepository();
        }

        public SearchParcel ParcelPackage (SearchQueryPackage package)
        {
            SearchParcel result = new SearchParcel();

            result.MinYear = int.MinValue;
            result.MaxYear = int.MaxValue;
            result.MinPrice = decimal.MinValue;
            result.MaxPrice = decimal.MaxValue;

            if (package.Keyword == null)
            {
                package.Keyword = "";
            }
            if (package.MinYear == null)
            {
                package.MinYear = "";
            }
            if (package.MaxYear == null)
            {
                package.MaxYear = "";
            }
            if (package.MinPrice == null)
            {
                package.MinPrice = "";
            }
            if (package.MaxPrice == null)
            {
                package.MaxPrice = "";
            }

            if (package.Keyword.Length > 0)
                result.HasKeyword();
            if (package.MinYear.Length > 0 || package.MaxYear.Length > 0)
                result.HasYearQuery();
            if (package.MinPrice.Length > 0 || package.MaxPrice.Length > 0)
                result.HasPriceQuery();

            int bottomYear = 0;
            int topYear = int.MaxValue;
            decimal bottomPrice = 0;
            decimal topPrice = decimal.MaxValue;

            if (package.MinYear.Length > 0)
            {
                int.TryParse(package.MinYear, out bottomYear);
            }

            if (package.MaxYear.Length > 0)
            {
                int.TryParse(package.MaxYear, out topYear);
            }
                
            if (package.MinPrice.Length > 0)
            {
                decimal.TryParse(package.MinPrice, out bottomPrice);
            }
                
            if (package.MaxPrice.Length > 0)
            {
                decimal.TryParse(package.MaxPrice, out topPrice);
            }

            result.Keyword = package.Keyword;
            result.MinYear = bottomYear;
            result.MaxYear = topYear;
            result.MinPrice = bottomPrice;
            result.MaxPrice = topPrice;
            result.InventoryType = package.InventoryType;
            
            return result;
        }

        public Courier<List<Vehicle>> GetSearchResult(SearchParcel parcel)
        {
            IEnumerable<Vehicle> list = repo.GetInventory(parcel.InventoryType);
            if (!string.IsNullOrWhiteSpace(parcel.Keyword))
            {
                list = list.Where(v =>
                v.Model.NameplateMarque.ToUpper().Contains(parcel.Keyword.ToUpper()) ||
                v.Model.Manufacturer.ManufacturerName.ToUpper().Contains(parcel.Keyword.ToUpper()) ||
                v.ProductionYear.ToString().Contains(parcel.Keyword));
            }
            list = list.Where(v =>
            v.ProductionYear <= parcel.MaxYear &&
            v.ProductionYear >= parcel.MinYear);
            list = list.Where(v =>
            (v.SalePrice <= parcel.MaxPrice &&
            v.SalePrice >= parcel.MinPrice) ||
            (v.MSRP <= parcel.MaxPrice &&
            v.MSRP >= parcel.MinPrice));

            Courier<List<Vehicle>> courier = new Courier<List<Vehicle>>();
            courier.Package = list.ToList();
            if (courier.Package.Count == 0)
            {
                courier.Success = false;
                courier.Message = "No results found given filter settings.";
            }
            else
            {
                courier.Success = true;
            }
            return courier;

            //switch (parcel.GetParcelDirection())
            //{
            //    case 1:
            //        return ByPrice(parcel.MinPrice, parcel.MaxPrice, parcel.InventoryType);
            //    case 10:
            //        return ByYear(parcel.MinYear, parcel.MaxYear, parcel.InventoryType);
            //    case 11:
            //        return ByYearAndPrice(parcel);
            //    case 100:
            //        return ByKeyword(parcel.Keyword, parcel.InventoryType);
            //    case 101:
            //        return ByKeywordAndPrice(parcel);
            //    case 110:
            //        return ByKeywordAndYear(parcel);
            //    case 111:
            //        return FullSearch(parcel);
            //    default:
            //        return new Courier<SearchResultPackage>() { Success = true, Package = new SearchResultPackage() { Vehicles = repo.GetInventory(parcel.InventoryType).OrderByDescending(v => v.MSRP).Take(20).ToList() } };
            //}
            //if (parcel.PackagedKeyword && parcel.PackagedYearRange && parcel.PackagedPriceRange)
            //{
            //    return FullSearch(parcel);
            //}
            //else if (parcel.PackagedKeyword && parcel.PackagedYearRange || parcel.PackagedKeyword && parcel.PackagedPriceRange)
            //{
            //    if (parcel.PackagedYearRange)
            //    {
            //        return ByKeywordAndYear(parcel);
            //    }
            //    else
            //    {
            //        return ByKeywordAndPrice(parcel);
            //    }
            //}
            //else if (parcel.PackagedYearRange && parcel.PackagedPriceRange)
            //{
            //    return ByYearAndPrice(parcel);
            //}
            //else
            //{
            //    if (parcel.PackagedKeyword)
            //    {
            //        return ByKeyword(parcel.Keyword, parcel.InventoryType);
            //    }
            //    else if (parcel.PackagedYearRange)
            //    {
            //        return ByYear(parcel.MinYear, parcel.MaxYear, parcel.InventoryType);
            //    }
            //    else if (parcel.PackagedPriceRange)
            //    {
            //        return ByPrice(parcel.MinPrice, parcel.MaxPrice, parcel.InventoryType);
            //    }
            //    else
            //    {
            //        return new Courier<SearchResultPackage>() { Success = true, Package = new SearchResultPackage() { Vehicles = repo.GetInventory(parcel.InventoryType).OrderByDescending(v => v.MSRP).Take(20).ToList() } };
            //    }
            //}
        }

        //public Courier<SearchResultPackage> FullSearch(SearchParcel parcel)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var keywordQuery = from v in repo.GetInventory(parcel.InventoryType)
        //                       where v.Model.NameplateMarque.Contains(parcel.Keyword) ||
        //                       v.Model.Manufacturer.ManufacturerName.Contains(parcel.Keyword) ||
        //                       v.ProductionYear.ToString().Contains(parcel.Keyword)
        //                       select v;

        //    var yearQuery = from v in keywordQuery
        //                    where v.ProductionYear > parcel.MinYear
        //                    && v.ProductionYear < parcel.MaxYear
        //                    select v;

        //    var fromRepo = from v in yearQuery
        //                   where v.MSRP > parcel.MinPrice &&
        //                   v.MSRP < parcel.MaxPrice ||
        //                   v.SalePrice > parcel.MinPrice &&
        //                   v.SalePrice < parcel.MaxPrice
        //                   select v;

        //    result.Vehicles = fromRepo.ToList();

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Success = true;
        //    courier.Package = result;
        //    return courier;
        //}

        //public Courier<SearchResultPackage> ByKeywordAndYear(SearchParcel parcel)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var keywordQuery = from v in repo.GetInventory(parcel.InventoryType)
        //                   where v.Model.NameplateMarque.Contains(parcel.Keyword) ||
        //                   v.Model.Manufacturer.ManufacturerName.Contains(parcel.Keyword) ||
        //                   v.ProductionYear.ToString().Contains(parcel.Keyword)
        //                   select v;

        //    var fromRepo = from v in keywordQuery
        //                    where v.ProductionYear > parcel.MinYear
        //                    && v.ProductionYear < parcel.MaxYear
        //                    select v;

        //    result.Vehicles = fromRepo.ToList();

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Success = true;
        //    courier.Package = result;
        //    return courier;
        //}

        //public Courier<SearchResultPackage> ByKeywordAndPrice(SearchParcel parcel)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var keywordQuery = from v in repo.GetInventory(parcel.InventoryType)
        //                       where v.Model.NameplateMarque.Contains(parcel.Keyword) ||
        //                       v.Model.Manufacturer.ManufacturerName.Contains(parcel.Keyword) ||
        //                       v.ProductionYear.ToString().Contains(parcel.Keyword)
        //                       select v;

        //    var fromRepo = from v in keywordQuery
        //                   where v.MSRP > parcel.MinPrice &&
        //                   v.MSRP < parcel.MaxPrice ||
        //                   v.SalePrice > parcel.MinPrice &&
        //                   v.SalePrice < parcel.MaxPrice
        //                   select v;

        //    result.Vehicles = fromRepo.ToList();

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Success = true;
        //    courier.Package = result;
        //    return courier;
        //}

        //public Courier<SearchResultPackage> ByYearAndPrice(SearchParcel parcel)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var yearQuery = from v in repo.GetInventory(parcel.InventoryType)
        //                   where v.ProductionYear > parcel.MinYear
        //                   && v.ProductionYear < parcel.MaxYear
        //                   select v;

        //    var fromRepo = from v in yearQuery
        //                   where v.MSRP > parcel.MinPrice &&
        //                   v.MSRP < parcel.MaxPrice ||
        //                   v.SalePrice > parcel.MinPrice &&
        //                   v.SalePrice < parcel.MaxPrice
        //                   select v;

        //    result.Vehicles = fromRepo.ToList();

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Package = result;
        //    return courier;
        //}

        //public Courier<SearchResultPackage> ByKeyword(string keyword, InventoryType type)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var cars = repo.GetInventory(type);
        //    List<Vehicle> matching = new List<Vehicle>();

        //    foreach(var v in cars)
        //    {
        //        if (v.ProductionYear.ToString().Equals(keyword, StringComparison.CurrentCultureIgnoreCase))
        //        {
        //            matching.Add(v);
        //        }
        //        else if (v.Model.NameplateMarque.ToUpper().Contains(keyword.ToUpper()))
        //        {
        //            matching.Add(v);
        //        }
        //        else if (v.Model.Manufacturer.ManufacturerName.ToUpper().Contains(keyword.ToUpper()))
        //        {
        //            matching.Add(v);
        //        }
        //        else continue;
        //    }

        //    result.Vehicles = matching;

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Success = true;
        //    courier.Package = result;
        //    return courier;
        //}

        //public Courier<SearchResultPackage> ByYear(int minYear, int maxYear, InventoryType type)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var fromRepo = from v in repo.GetInventory(type)
        //                   where v.ProductionYear > minYear
        //                   && v.ProductionYear < maxYear
        //                   select v;

        //    result.Vehicles = fromRepo.ToList();

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Success = true;
        //    courier.Package = result;
        //    return courier;
        //}

        //public Courier<SearchResultPackage> ByPrice(decimal minPrice, decimal maxPrice, InventoryType type)
        //{
        //    Courier<SearchResultPackage> courier = new Courier<SearchResultPackage>();
        //    SearchResultPackage result = new SearchResultPackage();

        //    var fromRepo = from v in repo.GetInventory(type)
        //                   where v.MSRP > minPrice &&
        //                   v.MSRP < maxPrice ||
        //                   v.SalePrice > minPrice &&
        //                   v.SalePrice < maxPrice
        //                   select v;

        //    result.Vehicles = fromRepo.ToList();

        //    if (result.Vehicles.Count == 0)
        //    {
        //        courier.Success = false;
        //        courier.Message = "There is nothing in our inventory that matches the given search parameters. Try broadening your given search to find more available options.";
        //        return courier;
        //    }

        //    courier.Success = true;
        //    courier.Package = result;
        //    return courier;
        //}
    }
}
