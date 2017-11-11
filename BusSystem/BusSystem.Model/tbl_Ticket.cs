using System;
namespace BusSystem.Model
{
    public class tbl_Ticket
    {

        /// <summary>
        /// col_ticket_time
        /// </summary>
        public string col_ticket_time { get; set; }
        /// <summary>
        /// id_tbl_ticket
        /// </summary>
        public int id_tbl_ticket { get; set; }
        /// <summary>
        /// id_tbl_order
        /// </summary>
        public int id_tbl_order { get; set; }
        /// <summary>
        /// col_ticket_entrance
        /// </summary>
        public string col_ticket_entrance { get; set; }
        /// <summary>
        /// col_ticket_State
        /// </summary>
        public int col_ticket_State { get; set; }
        /// <summary>
        /// col_seatno
        /// </summary>
        public int col_seatno { get; set; }
        /// <summary>
        /// id_tbl_passenger
        /// </summary>
        public int id_tbl_passenger { get; set; }

    }
}

