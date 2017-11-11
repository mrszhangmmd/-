using System; 
namespace BusSystem.Model
{
	public class tbl_captcha
	{
   		     
      	/// <summary>
		/// id_tbl_captcha
        /// </summary>
        public int id_tbl_captcha { get; set; }
		/// <summary>
		/// col_userid
        /// </summary>
        public int col_userid { get; set; }
		/// <summary>
		/// col_token
        /// </summary>
        public string col_token { get; set; }
		/// <summary>
		/// col_actved
        /// </summary>
        public bool col_actved { get; set; }
		/// <summary>
		/// col_expired
        /// </summary>
        public DateTime col_expired { get; set; }
		   
	}
}

