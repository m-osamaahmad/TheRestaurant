using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Script.Serialization;
using TheRestaurant.Data.Models.Security;

namespace TheRestaurant.Data.Models
{
    public class Logger
    {
        public DateTime AddedDate { get; set; }

        public string AddedBy { get; set; }

        [ForeignKey("AddedBy")]
        [ScriptIgnore]
        public virtual ApplicationUser AddedByUser { get; set; }

        public DateTime ModifiedDate { get; set; }

        public string ModifiedBy { get; set; }

        [ForeignKey("ModifiedBy")]
        [ScriptIgnore]
        public virtual ApplicationUser ModifiedByUser { get; set; }

    }

    public class DataTable
    {
        public List<DataTableParameters> Parameters { get; set; }
    }

    public class DataTableParameters
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class KeyValuePair
    {
        public int Id { get; set; }
        public string Text { get; set; }
    }

    public class jQueryDataTableInput
    {
        /// <summary>
        /// Request sequence number sent by DataTable,
        /// same value must be returned in response
        /// </summary>
        public string sEcho { get; set; }

        /// <summary>
        /// Text used for filtering
        /// </summary>
        public string sSearch { get; set; }

        /// <summary>
        /// Number of records that should be shown in table
        /// </summary>
        public int iDisplayLength { get; set; }

        /// <summary>
        /// First record that should be shown(used for paging)
        /// </summary>
        public int iDisplayStart { get; set; }

        /// <summary>
        /// Number of columns in table
        /// </summary>
        public int iColumns { get; set; }

        /// <summary>
        /// Number of columns that are used in sorting
        /// </summary>
        public int iSortingCols { get; set; }

        /// <summary>
        /// Comma separated list of column names
        /// </summary>
        public string sColumns { get; set; }


        //1.19 DataTable parameter
        public string sortingOrder { get; set; }
        public string sortingColumn { get; set; }
        public int pageSize { get; set; }
        public int pageNo { get; set; }
    }

    public class JQueryDtaTableOutput<T> where T : class
    {
        public string sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public IEnumerable<T> aaData { get; set; }
    }
}
