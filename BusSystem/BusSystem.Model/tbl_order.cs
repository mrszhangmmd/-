using System;
namespace BusSystem.Model
{
    public class tbl_order
    {

        /// <summary>
        /// id_tbl_order
        /// </summary>
        public int id_tbl_order { get; set; }
        /// <summary>
        /// id_tbl_passenger
        /// </summary>
        public int id_tbl_passenger { get; set; }
        /// <summary>
        /// id_tbl_schedule
        /// </summary>
        public int id_tbl_schedule { get; set; }
        /// <summary>
        /// col_take_order_no
        /// </summary>
        public string col_take_order_no { get; set; }
        /// <summary>
        /// col_password
        /// </summary>
        public string col_password { get; set; }
        /// <summary>
        /// col_start_time
        /// </summary>
        public string col_start_time { get; set; }
        /// <summary>
        /// col_order_state
        /// </summary>
        public string col_order_state { get; set; }
        /// <summary>
        /// col_passenger_tel
        /// </summary>
        public string col_passenger_tel { get; set; }
        /// <summary>
        /// col_passenger_num
        /// </summary>
        public string col_passenger_num { get; set; }
        /// <summary>
        /// id_tbl_passenger2
        /// </summary>
        public int id_tbl_passenger2 { get; set; }
        /// <summary>
        /// id_tbl_passenger3
        /// </summary>
        public int id_tbl_passenger3 { get; set; }
        /// <summary>
        /// col_insurence_state
        /// </summary>
        public int col_insurence_state { get; set; }
        /// <summary>
        /// col_price
        /// </summary>
        public decimal col_price { get; set; }

    }
}

