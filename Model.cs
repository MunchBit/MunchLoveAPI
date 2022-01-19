using System;
using System.Collections.Generic;
using System.Text;

namespace RESTApiMLFunction
{
    public class MasterTemplateModel
    {
        public string Branchname { get; set; }
        public int MasterItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal RRP { get; set; }
        public int MasterCategoryId { get; set; }
        public string MasterCategory { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public int CusnLevel { get; set; }
        public int CusnFamily { get; set; }
        public string CusnPath { get; set; }
        public int CuisineId { get; set; }
        public int ItemLevel { get; set; }
        public int Family { get; set; }
        public string Path { get; set; }
        public string PathId { get; set; }
        public DateTime sysCreateDate { get; set; }
        public DateTime sysModifyDate { get; set; }
    }
    public class CreateMasterTemplateModel
    {
        public string Branchname { get; set; }
        public int MasterItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal RRP { get; set; }
        public int MasterCategoryId { get; set; }
        public string MasterCategory { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public int CusnLevel { get; set; }
        public int CusnFamily { get; set; }
        public string CusnPath { get; set; }
        public int CuisineId { get; set; }
        public int ItemLevel { get; set; }
        public int Family { get; set; }
        public string Path { get; set; }
        public string PathId { get; set; }
        public DateTime sysCreateDate { get; set; } = DateTime.UtcNow;
        public DateTime sysModifyDate { get; set; } = DateTime.UtcNow;
    }
    
    public class UpdateMasterTemplateModel
    {

        public string Branchname { get; set; }
        public int MasterItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemDesc { get; set; }
        public decimal RRP { get; set; }
        public int MasterCategoryId { get; set; }
        public string MasterCategory { get; set; }
        public int ItemCategoryId { get; set; }
        public string ItemCategoryName { get; set; }
        public int CusnLevel { get; set; }
        public int CusnFamily { get; set; }
        public string CusnPath { get; set; }
        public int CuisineId { get; set; }
        public int ItemLevel { get; set; }
        public int Family { get; set; }
        public string Path { get; set; }
        public string PathId { get; set; }
        public DateTime sysModifyDate { get; set; } = DateTime.UtcNow;
    }

    public class StoreModel
    {
        public int Storeid { get; set; }
        public int Branchid { get; set; }
        public string Storename { get; set; }
        public string CompanyNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public string sysStatus { get; set; }
        public DateTime sysAppliedDate { get; set; }
        public DateTime sysApprovedDate { get; set; }
        public DateTime sysModifyDate { get; set; }
        public DateTime sysCreateDate { get; set; }
    }
    public class CreateStoreModel
    {
        public int Storeid { get; set; }
        public int Branchid { get; set; }
        public string Storename { get; set; }
        public string CompanyNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public string sysStatus { get; set; }
        public DateTime sysAppliedDate { get; set; }
        public DateTime sysApprovedDate { get; set; }
        public DateTime sysModifyDate { get; set; } = DateTime.UtcNow;
        public DateTime sysCreateDate { get; set; } = DateTime.UtcNow;
    }
    public class UpdateStoreModel
    {
        public int Storeid { get; set; }
        public int Branchid { get; set; }
        public string Storename { get; set; }
        public string CompanyNo { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string District { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public string ContactNumber { get; set; }
        public string ContactNumber2 { get; set; }
        public string sysStatus { get; set; }
        public DateTime sysAppliedDate { get; set; }
        public DateTime sysApprovedDate { get; set; }
        public DateTime sysModifyDate { get; set; } = DateTime.UtcNow;
    }


}
