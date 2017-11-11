using System; 
namespace BusSystem.Model
{
	public class tbl_line
	{
   		     
      	/// <summary>
		/// id_tbl_line
        /// </summary>
        public int id_tbl_line { get; set; }
		/// <summary>
		/// col_line_time
        /// </summary>
        public string  col_line_time { get; set; }
		/// <summary>
		/// col_line_price
        /// </summary>
        public string col_line_price { get; set; }
		/// <summary>
		/// col_definitionid
        /// </summary>
        public int col_definitionid { get; set; }
		/// <summary>
		/// col_startid
        /// </summary>
        public int col_startid { get; set; }
		   
	}
}

