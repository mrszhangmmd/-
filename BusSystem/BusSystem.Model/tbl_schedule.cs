using System; 
namespace BusSystem.Model
{
	public class tbl_schedule
	{
   		     
      	/// <summary>
		/// id_tbl_line
        /// </summary>
        public int id_tbl_line { get; set; }
		/// <summary>
		/// id_tbl_coach
        /// </summary>
        public int id_tbl_coach { get; set; }
		/// <summary>
		/// id_tbl_schedule
        /// </summary>
        public int id_tbl_schedule { get; set; }
		/// <summary>
		/// col_start_date
        /// </summary>
        public string  col_start_date { get; set; }
		/// <summary>
		/// col_remainticket
        /// </summary>
        public int col_remainticket { get; set; }
		   
	}
}

