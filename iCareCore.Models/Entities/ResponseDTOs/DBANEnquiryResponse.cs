using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCareCore.Core.Entities.ResponseDTOs
{
    public class DBANEnquiryResponse
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Data
    {
        public pep pep { get; set; }
    }
    public class pep
    {
        public List<pepData> data { get; set; }
    }
    public class pepData
    {
        public Int64 id { get; set; }
        public int organization_id { get; set; }
        public int pep_category_id { get; set; }
        public int pep_subcategory_id { get; set; }
        public string pep_info_source_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string dob { get; set; }
        public string designation { get; set; }
        public string temp_address { get; set; }
        public string permanent_address { get; set; }
        public string nid_number { get; set; }
        public string citizenship_number { get; set; }
        public string voter_id_number { get; set; }
        public string passport_number { get; set; }
        public string father_name { get; set; }
        public string mother_name { get; set; }
        public string grandfather_name { get; set; }
        public string spouse_name { get; set; }
        public string son_name { get; set; }
        public string daughter_name { get; set; }
        public string remarks { get; set; }
        public string status { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string deleted_at { get; set; }
        public string effective_date { get; set; }
        public string end_date { get; set; }
        public string political_status { get; set; }
        public category pep_category { get; set; }
        public category pep_subcategory { get; set; }
        public pepPosition pep_position { get; set; }
        public class category
        {
            public int id { get; set; }
            public string name { get; set; }
        }
        public class pepPosition
        {
            public Int64 id { get; set; }
            public Int64 pep_id { get; set; }
            public int position_id { get; set; }
            public string effective_date { get; set; }
            public string end_date { get; set; }
            public string removal_date { get; set; }
            public string political_status { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
            public category position { get; set; }
        }
    }

    public class ListData
    {
        public string MATCH_NAME { get; set;}
        public string MATCHED_ID { get; set;}
        public string REMARKS { get; set;}
        public string source { get; set;}
        public string DOB { get; set;}
    }
}
