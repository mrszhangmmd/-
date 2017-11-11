using System; 
namespace BusSystem.Model
{
	public class tbl_passenger
	{
   		     
      	/// <summary>
		/// id_tbl_passenger
        /// </summary>
        public int id_tbl_passenger { get; set; }
		/// <summary>
		/// col_name
        /// </summary>
        public string col_name { get; set; }
		/// <summary>
		/// col_passenger_state
        /// </summary>
        public int col_passenger_state { get; set; }
		/// <summary>
		/// col_indentity_no
        /// </summary>
        public string col_indentity_no { get; set; }

        public int id_tbl_user { get; set; }

        public int col_ischecked { get; set; }
	}
}

